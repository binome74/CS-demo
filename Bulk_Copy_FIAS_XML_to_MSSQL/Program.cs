using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace BulkCopy
{
    class Program
    {
        private const int m_NotifyAfter = 10000;
        private const int m_BatchSize = 5000;

        internal static object ToGuid(XAttribute input)
        {
            if (input == null) return null;
            if (string.IsNullOrEmpty(input.Value) == true) return null;
            return new Guid(input.Value);
        }

        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS2012;Initial Catalog=FIAS;Integrated Security=True";
            string addrobjFile = @"d:\Project\FIAS_XML\AS_ADDROBJ_20150212_747e1b4b-1ad6-4cdb-8294-541b4607c006.XML";
            string houseIntFile = @"d:\Project\FIAS_XML\AS_HOUSEINT_20150212_4f2dfd8a-cb46-4cd3-b63e-647a556479d2.XML";

            using (XmlTextReader xmlTextReader = new XmlTextReader(addrobjFile))
            {
                using (SqlBulkCopy bulkCopy =  new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock)) {                                      
                    SetupBulkCopyAddrobj(bulkCopy);

                    var reader = new AddrobjReader(xmlTextReader);
                    bulkCopy.WriteToServer(reader);
                }
            }

            using (XmlTextReader xmlTextReader = new XmlTextReader(houseIntFile))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock))
                {
                    SetupBulkCopyHouseInt(bulkCopy);

                    var reader = new HouseIntReader(xmlTextReader);
                    bulkCopy.WriteToServer(reader);
                }
            }
            Console.WriteLine("Ready");
            Console.ReadLine();
        }

        private static void OnSqlRowsTransfer(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine("Copied {0} so far...", e.RowsCopied);
        }

        private static void SetupBulkCopyAddrobj(SqlBulkCopy bulkCopy)
        {
            bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsTransfer);
            bulkCopy.NotifyAfter = m_NotifyAfter;
            bulkCopy.BatchSize = m_BatchSize;

            bulkCopy.ColumnMappings.Add(0, "AOID");
            bulkCopy.ColumnMappings.Add(1, "AOGUID");
            bulkCopy.ColumnMappings.Add(2, "FORMALNAME");
            bulkCopy.ColumnMappings.Add(3, "OFFNAME");
            bulkCopy.ColumnMappings.Add(4, "SHORTNAME");
            bulkCopy.ColumnMappings.Add(5, "REGIONCODE");
            bulkCopy.ColumnMappings.Add(6, "AUTOCODE");
            bulkCopy.ColumnMappings.Add(7, "AREACODE");
            bulkCopy.ColumnMappings.Add(8, "CITYCODE");
            bulkCopy.ColumnMappings.Add(9, "CTARCODE");
            bulkCopy.ColumnMappings.Add(10, "PLACECODE");
            bulkCopy.ColumnMappings.Add(11, "STREETCODE");
            bulkCopy.ColumnMappings.Add(12, "EXTRCODE");
            bulkCopy.ColumnMappings.Add(13, "SEXTCODE");
            bulkCopy.ColumnMappings.Add(14, "POSTALCODE");
            bulkCopy.ColumnMappings.Add(15, "UPDATEDATE");
            bulkCopy.ColumnMappings.Add(16, "AOLEVEL");
            bulkCopy.ColumnMappings.Add(17, "PARENTGUID");
            bulkCopy.ColumnMappings.Add(18, "PREVID");
            bulkCopy.ColumnMappings.Add(19, "NEXTID");
            bulkCopy.ColumnMappings.Add(20, "ACTSTATUS");
            bulkCopy.ColumnMappings.Add(21, "OPERSTATUS");
            bulkCopy.ColumnMappings.Add(22, "LIVESTATUS");
            bulkCopy.ColumnMappings.Add(23, "STARTDATE");
            bulkCopy.ColumnMappings.Add(24, "ENDDATE");
            bulkCopy.ColumnMappings.Add(25, "CODE");

            bulkCopy.DestinationTableName = "ADDROBJ";
        }

        private static void SetupBulkCopyHouseInt(SqlBulkCopy bulkCopy)
        {
            bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsTransfer);
            bulkCopy.NotifyAfter = m_NotifyAfter;
            bulkCopy.BatchSize = m_BatchSize;

            bulkCopy.ColumnMappings.Add(0, "HOUSEINTID");
            bulkCopy.ColumnMappings.Add(1, "INTGUID");
            bulkCopy.ColumnMappings.Add(2, "AOGUID");
            bulkCopy.ColumnMappings.Add(3, "INTSTATUS");
            bulkCopy.ColumnMappings.Add(4, "INTSTART");
            bulkCopy.ColumnMappings.Add(5, "INTEND");
            bulkCopy.ColumnMappings.Add(6, "POSTALCODE");
            bulkCopy.ColumnMappings.Add(7, "STARTDATE");
            bulkCopy.ColumnMappings.Add(8, "ENDDATE");
            bulkCopy.ColumnMappings.Add(9, "UPDATEDATE");

            bulkCopy.DestinationTableName = "HOUSEINT";
        }

    }
}
