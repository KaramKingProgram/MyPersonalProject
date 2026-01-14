using DataAccessesLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuisnessLayer
{
    public class clsPersonData
    {

        public static int AddNewPerson(string FirstName, string LastName, DateTime DateOfBirth, string Country, string Phone)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "insert into Persons (FirstName,LastName,DateOfBirth,Country,Phone) " +
                "values (@FirstName,@LastName,@DateOfBirth,@Country,@Phone);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            if (LastName != null)
            {
                command.Parameters.AddWithValue("@LastName", LastName);
            }
            else
            {
                command.Parameters.AddWithValue("@LastName", DBNull.Value);
            }

                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                       

            if (Country != null)
            {
                command.Parameters.AddWithValue("@Country", Country);
            }
            else
            {
                command.Parameters.AddWithValue("@Country", DBNull.Value);
            }
            if (Phone != null)
            {
                command.Parameters.AddWithValue("@Phone", Phone);
            }
            else
            {
                command.Parameters.AddWithValue("@Phone", DBNull.Value);
            }



            try
            {
                connection.Open();

               object Result = command.ExecuteScalar();

                if (Result != DBNull.Value) {

                    PersonID = Convert.ToInt32(Result);

                }
               



            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return (PersonID);





        }


    }
}
