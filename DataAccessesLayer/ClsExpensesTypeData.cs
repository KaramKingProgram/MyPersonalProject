using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessesLayer
{
    public class ClsExpensesTypeData
    {

        public static DataTable GetAllExpensesTypeData()
        {
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            DataTable Data = new DataTable("ExpensesType");

            string Query = "Select * from ExpensesTypes";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Data.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();
            }

            return Data;

        }
    }
}
