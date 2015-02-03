using System.Collections.Generic;
using System.Data.OleDb;

namespace DownloadAudioGoogleTranslate
{
    public class ExcelProvider
    {
        public List<string> ReadColumn(string path)
        {
            using (var connection = new OleDbConnection(GetConnection(path)))
            {
                connection.Open();
                var reads = new List<string>();
                var command = new OleDbCommand("select * from [Palavras$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                    while (dr.Read())
                        reads.Add(dr[0].ToString());
                return reads;
            }
        }

        private static string GetConnection(string path)
        {
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;'";
            return con;
        }
    }
}
