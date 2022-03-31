using System.Data;
using Microsoft.Data.SqlClient;

namespace KartSkills.Lib
{
    public class SqlHelper
    {
        static SqlConnection connection =
            new SqlConnection(@"Data Source=DESKTOP-K89VHT4;Initial Catalog=Karting;Integrated Security=True");

        private static SqlDataAdapter dataAdapter;

        public static DataTable GetTableFromSql(string querry)
        {
            connection.Open();
            dataAdapter = new SqlDataAdapter(querry, connection);
            DataSet data = new DataSet();
            DataTable table = new DataTable();
            dataAdapter.Fill(data);
            if (data.Tables.Count>0 && data.Tables[0].Rows.Count > 0)
            {
                table = data.Tables[0];
            }

            connection.Close();

            return table;
        }
    }
}