using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BulkCopy
{
    public class AddrobjReader : XmlDataReader {
        private const string XmlTagRow = "Object";
 
        private const int ciFieldCount = 26;
        private const int InvalidItemId = -1;
 
        public AddrobjReader(XmlReader xmlReader) : base(xmlReader, ciFieldCount, XmlTagRow){ }


        public override object GetValue(int i)
        {
            switch (i)
            {
                case 0: return Program.ToGuid(CurrentElement.Attribute("AOID"));
                case 1: return Program.ToGuid(CurrentElement.Attribute("AOGUID"));
                case 2: return CurrentElement.Attribute("FORMALNAME").Value;
                case 3: return (CurrentElement.Attribute("OFFNAME") == null) ? null : CurrentElement.Attribute("OFFNAME").Value;
                case 4: return CurrentElement.Attribute("SHORTNAME").Value;
                case 5: return Convert.ToByte(CurrentElement.Attribute("REGIONCODE").Value);
                case 6: return Convert.ToByte(CurrentElement.Attribute("AUTOCODE").Value);
                case 7: return Convert.ToInt16(CurrentElement.Attribute("AREACODE").Value);
                case 8: return Convert.ToInt16(CurrentElement.Attribute("CITYCODE").Value);
                case 9: return Convert.ToInt16(CurrentElement.Attribute("CTARCODE").Value);
                case 10: return Convert.ToInt16(CurrentElement.Attribute("PLACECODE").Value);
                case 11: return Convert.ToInt16(CurrentElement.Attribute("STREETCODE").Value);
                case 12: return Convert.ToInt16(CurrentElement.Attribute("EXTRCODE").Value);
                case 13: return Convert.ToInt16(CurrentElement.Attribute("SEXTCODE").Value);
                case 14: 
                    return (CurrentElement.Attribute("POSTALCODE") == null) ? (object)null : Convert.ToInt32(CurrentElement.Attribute("POSTALCODE").Value);
                case 15: return Convert.ToDateTime(CurrentElement.Attribute("UPDATEDATE").Value);
                case 16: return Convert.ToInt32(CurrentElement.Attribute("AOLEVEL").Value);
                case 17: return Program.ToGuid(CurrentElement.Attribute("PARENTGUID"));
                case 18: return Program.ToGuid(CurrentElement.Attribute("PREVID"));
                case 19: return Program.ToGuid(CurrentElement.Attribute("NEXTID"));
                case 20: return Convert.ToInt32(CurrentElement.Attribute("ACTSTATUS").Value);
                case 21: return Convert.ToInt32(CurrentElement.Attribute("OPERSTATUS").Value);
                case 22: return Convert.ToByte(CurrentElement.Attribute("LIVESTATUS").Value);
                case 23: return Convert.ToDateTime(CurrentElement.Attribute("STARTDATE").Value);
                case 24: return Convert.ToDateTime(CurrentElement.Attribute("ENDDATE").Value);
                case 25: return (CurrentElement.Attribute("CODE") == null) ? null : CurrentElement.Attribute("CODE").Value;
                default:

                    throw new InvalidOperationException("Column count mismatch.");
            }
        }


    }
}
