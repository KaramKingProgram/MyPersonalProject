using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessesLayer
{
   public  class clsCurrencyData
    {
       
        public static DataTable GetAllData() {

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "Select * from Currencies";

            SqlCommand command  = new SqlCommand(Query, connection);

            DataTable data = new DataTable("Currencies");

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();
            }
        
        return data;
        
        }




    }
}
