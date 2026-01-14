using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessesLayer
{
    public class clsIncomeSourceData

    {

        public static DataTable GetIncomeSources()
        {
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            DataTable table = new DataTable();

            string Query = "Select * from IncomeSources ";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return table;




        }

    }
}
