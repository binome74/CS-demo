using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BulkCopy
{
    public class HouseIntReader : XmlDataReader {
        private const string XmlTagRow = "HouseInterval";
 
        private const int ciFieldCount = 12;
        private const int InvalidItemId = -1;
 
        public HouseIntReader(XmlReader xmlReader) : base(xmlReader, ciFieldCount, XmlTagRow){ }

        public override object GetValue(int i)
        {
            switch (i)
            {
                case 0: return Program.ToGuid(CurrentElement.Attribute("HOUSEINTID"));
                case 1: return Program.ToGuid(CurrentElement.Attribute("INTGUID"));
                case 2: return Program.ToGuid(CurrentElement.Attribute("AOGUID"));
                case 3: return Convert.ToInt32(CurrentElement.Attribute("INTSTATUS").Value);
                case 4: return Convert.ToInt32(CurrentElement.Attribute("INTSTART").Value);
                case 5: return Convert.ToInt32(CurrentElement.Attribute("INTEND").Value);
                case 6: return (CurrentElement.Attribute("POSTALCODE") == null) ? null : CurrentElement.Attribute("POSTALCODE").Value;
                case 7: return Convert.ToDateTime(CurrentElement.Attribute("STARTDATE").Value);
                case 8: return Convert.ToDateTime(CurrentElement.Attribute("ENDDATE").Value);
                case 9: return Convert.ToDateTime(CurrentElement.Attribute("UPDATEDATE").Value);
                default:
                    throw new InvalidOperationException("Column count mismatch.");
            }
        }


    }
}
