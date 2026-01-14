using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessesLayer
{
    public class clsUserData
    {

        public static bool AddNewUser(string username, string passwordHash, string Email, int PersonID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "insert into Users (User_Name,PasswordHash,PersonID,Email) " +
                "values (@username,@passwordHash,@PersonID,@Email);";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@passwordHash", passwordHash);

            command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {

                    return true;
                }



            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return (rowAffected > 0);

        }

        public static bool CheckIsUserExsit(string username, string passwordHash)
        {
            bool IsExsit = false;
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "Select Found = 1 from Users where User_Name = @UserName and PasswordHash = @passwordHash";

            

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName",username);
            command.Parameters.AddWithValue ("@passwordHash", passwordHash);

            try
            {
                connection.Open();

                 SqlDataReader reader = command.ExecuteReader();

                  IsExsit  = reader.HasRows;
                  
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return IsExsit;

        }

        public static int FindPerson(string username, string passwordHash) {

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            int PersonID = 0;

            string Query = "Select PersonID from Users where User_Name = @UserName and PasswordHash = @PasswordHash";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@PasswordHash",passwordHash);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                PersonID = (int)Result;

            }catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return PersonID;
        
        }
    }
}
