using System;
using System.Data.Sql;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;

namespace Shipregs2.Conv {

    public class RegularExpressions {
		
		private class PowerFields {
			public decimal? power = null;
			public byte? unit = null;
			public byte? count = null;
		}

        public static readonly RegexOptions Options =
			RegexOptions.CultureInvariant |
			RegexOptions.Singleline;
			
		private static readonly string splitFioPattern = 
			"^(?:ИП\\s|ип\\s|Ип\\s)?([А-ЯЁё][А-Яа-яЁё]{1,24})\\s(([А-Яа-яЁё])(?:\\.|\\.\\s|\\s)([А-Яа-яЁё])\\.?|([А-ЯЁё][А-Яа-яЁё]{0,29})\\s([А-ЯЁё][А-Яа-яЁё]{0,34}))$";
			
		private static readonly string engineCountPattern = "(\\d+)\\s*(?:[*XХ]|по|шт|шт.{0,5}по)\\s*\\d|^(\\d+)[;\\/]|(\\d+)[- ]?шт";
		private static readonly string enginePowerPattern1 = 
			"(?:(\\d+)\\s*(?:[*XХ]|по|шт|шт.{0,5}по)\\s*|^(\\d+)[;\\/]\\s*|(\\d+)[- ]?шт\\s*)(\\d+(?:[\\.,]\\d*)?)\\s*(к.?в.?т?|кило|л.?с.?|лош|W)?";
		private static readonly string enginePowerPattern2 = 
			"(\\d+(?:[\\.,]\\d*)?)\\s*(к.?в.?т?|кило|л.?с.?|лош|W)";

		[SqlFunction(FillRowMethodName = "SplitFio_FillRow")]
		public static IEnumerable SplitFio(SqlChars input)
		{
			Regex regex = new Regex( splitFioPattern, Options );
			Match match = regex.Match( new string( input.Value ) );
			return match.Success ? new GroupCollection[] { match.Groups } : null;
		}
		
		public static void SplitFio_FillRow(Object obj, out SqlString f, out SqlString i, out SqlString o)
		{			
			if (obj == null) {
				f = i = o = SqlString.Null;
			} else {
				GroupCollection groups = (GroupCollection)obj;
				
				f = new SqlString(groups[1].Value);
				i = new SqlString(groups[5].Value);
				if (String.IsNullOrEmpty(i.Value))
					i = new SqlString(groups[3].Value);
				o = new SqlString(groups[6].Value);
				if (String.IsNullOrEmpty(o.Value))
					o = new SqlString(groups[4].Value);
			}
		}
		
		private static byte? convertToUnit(string input)
		{
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(input, "к", CompareOptions.IgnoreCase) >= 0)
				return 1;
			else if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(input, "w", CompareOptions.IgnoreCase) >= 0)
				return 1;
			else if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(input, "л", CompareOptions.IgnoreCase) >= 0)
				return 2;
			return null;
		}
		
		[SqlFunction(FillRowMethodName = "GuessEnginePower_FillRow")]
		public static IEnumerable GuessEnginePower(SqlChars input) 
		{
			if (input.IsNull) return null;
			decimal power; string powGroupVal = ""; string unitGroupVal = "";
			PowerFields pf = new PowerFields();
			string value = new string( input.Value );
			
			value = value.Replace(" ", "<>").Replace("><", "").Replace("<>", " ").Trim().Replace(",", ".");
			
			if (Decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out power)) {
				pf.power = power;
				return new PowerFields[] { pf };
			}
			
			Regex regex = new Regex( enginePowerPattern1, Options  | RegexOptions.IgnoreCase );
			Match match = regex.Match( value );
			if (match.Success) {
				powGroupVal = match.Groups[4].Value;
				unitGroupVal = match.Groups[5].Value;
			} else {
				regex = new Regex( enginePowerPattern2, Options  | RegexOptions.IgnoreCase );
				match = regex.Match( value );
				if (match.Success) {
					powGroupVal = match.Groups[1].Value;
					unitGroupVal = match.Groups[2].Value;
				}
			}
			
			if (!String.IsNullOrEmpty(powGroupVal) || !String.IsNullOrEmpty(unitGroupVal)) {
				if (Decimal.TryParse(powGroupVal, NumberStyles.Number, CultureInfo.InvariantCulture, out power))
					pf.power = power;
				
				pf.unit =  convertToUnit(unitGroupVal);
				
				pf.count = GuessEngineCountString(value);
				if (pf.count > 1 && pf.power != null) pf.power *= pf.count;
				
				return new PowerFields[] { pf };
			}
			return null;
		}
		
		public static void GuessEnginePower_FillRow(Object obj, out byte? count, out decimal? power, out byte? unit)
		{			
			if (obj == null) {
				power = null; unit = null; count = null;
			} else {
				PowerFields pf = (PowerFields)obj;
				count = pf.count;
				power = pf.power;
				unit = pf.unit;
			}
		}
		
		public static byte? GuessEngineCount(SqlChars input) {
			if (input.IsNull) return null;
			return GuessEngineCountString(new string(input.Value));
		}
		
		public static byte? GuessEngineCountString(string value) {
			byte temp;

			value = value.Replace(" ", "<>").Replace("><", "").Replace("<>", " ").Trim();
			
			if (String.IsNullOrEmpty(value)) return null;
			if (byte.TryParse(value, out temp)) return temp;
			
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "нет", CompareOptions.IgnoreCase) >= 0) return 0;
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "один", CompareOptions.IgnoreCase) >= 0) return 1;
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "два", CompareOptions.IgnoreCase) >= 0) return 2;
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "три", CompareOptions.IgnoreCase) >= 0) return 3;
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "четыре", CompareOptions.IgnoreCase) >= 0) return 4;
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(value, "пять", CompareOptions.IgnoreCase) >= 0) return 5;
			
			Regex regex = new Regex( engineCountPattern, Options | RegexOptions.IgnoreCase );
			Match match = regex.Match( value );
			if (match.Success) {
				foreach(Group group in match.Groups) {
					value = group.Value.Trim();
					if (group.Success == true && byte.TryParse(value, out temp)) {
						return temp;
					}
				}
			}
			return null;
		}
		
		[SqlFunction]
		public static SqlChars Match(SqlChars input, SqlString pattern, bool caseSensitive)
		{
			RegexOptions ro = Options;
			if (caseSensitive == false) ro = ro | RegexOptions.IgnoreCase;
			Regex regex = new Regex( pattern.Value, ro );
			Match match = regex.Match( new string( input.Value ) );
			return match.Success ? new SqlChars( match.Groups[0].Value ) : SqlChars.Null;
		}		
		
	}
}