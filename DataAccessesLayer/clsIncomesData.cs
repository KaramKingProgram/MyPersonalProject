using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessesLayer
{
    public class clsIncomesData
    {


        public static int AddNew(decimal IncomeAmount, DateTime IncomeDate, int IncomeSource,
            int PaymentMethod, string Description_Income, int PersonID, int CurrencyID)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings))
            {
                string query =
                    @"INSERT INTO Incomes
              (Amount, IncomeSourceID, PaymentMethodID, PersonID, IncomeDate, Description_Incomes, CurrencyID)
              VALUES
              ( @IncomeAmount, @IncomeSource, @PaymentMethod,@PersonID ,@IncomeDate , @Description_Income, @CurrencyID);
              SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@IncomeAmount", IncomeAmount);

                command.Parameters.AddWithValue("@IncomeDate", IncomeDate);

                command.Parameters.AddWithValue("@IncomeSource", IncomeSource);

                command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);

                command.Parameters.AddWithValue("@Description_Income",
                    string.IsNullOrWhiteSpace(Description_Income) ? (object)DBNull.Value : Description_Income);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        ID = Convert.ToInt32(result);
                }
                catch
                {
                    throw;
                }
                finally { connection.Close(); }
            }


            return ID;


        }

        public static bool Update(int IncomeId,decimal IncomeAmount, DateTime IncomeDate, int IncomeSource,
           int PaymentMethod, string Description_Income, int PersonID, int CurrencyID)
        {
            int RowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings))
            {
                string query =
                    @"Update Incomes
             set Amount = @Amount,IncomeSourceID= @IncomeSourceID,PaymentMethodID= @PaymentMethodID,PersonID = @PersonID,IncomeDate= @IncomeDate,Description_Incomes= @Description_Incomes,CurrencyID= @CurrencyID
             where IncomesID = @IncomeID;
             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@IncomeID", IncomeId);
                command.Parameters.AddWithValue("@Amount", IncomeAmount);
                command.Parameters.AddWithValue("@IncomeDate", IncomeDate);
                command.Parameters.AddWithValue("@IncomeSourceID", IncomeSource);
                command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethod);

                command.Parameters.AddWithValue("@Description_Incomes",
                    string.IsNullOrWhiteSpace(Description_Income) ? (object)DBNull.Value : Description_Income);

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

                try
                {
                    connection.Open();
                    RowAffected = command.ExecuteNonQuery();
                    
                }
                catch
                {
                    throw;
                }
                finally { connection.Close(); }
            }


            return (RowAffected > 0);


        }

        public static bool GetIncomeByID(ref int incomeID,ref decimal Amount,ref DateTime IncomeDate,ref int IncomeSource,ref int PaymentMethod,ref string Description_Income,
                ref int PersonID,ref int CurrencyID)
            {
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            bool isFound = false;

            string Query = "select * from Incomes where IncomesID = @IncomeID";

            SqlCommand command =  new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@IncomeID", incomeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    Amount = (decimal)reader["Amount"];
                    IncomeDate = (DateTime)reader["IncomeDate"];
                    IncomeSource = (int)reader["IncomeSourceID"];
                    PaymentMethod = (int)reader["PaymentMethodID"];
                    Description_Income = reader["Description_Incomes"] == DBNull.Value ? "" : reader["Description_Incomes"].ToString();
                    PersonID = (int)reader["PersonID"];
                    CurrencyID = (int)reader["CurrencyID"];


                }

            }catch (Exception ex) { throw; } finally { connection.Close(); }

            return isFound;


            }

       public static DataTable AllIncomesData(int PersonID)
            {
                SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

                DataTable data = new DataTable();

                string Query = "Select * from Incomes where PersonID = @PersonID";

                SqlCommand command = new SqlCommand(Query, connection);
                 
                command.Parameters.AddWithValue("@PersonID",PersonID);
  
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

        public static DataTable AllIncomesRealData(int PersonID) {

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            DataTable data = new DataTable();

            string Query = "Select IncomesID,Amount,IncomeDate,Name_Source,Currency_Name,Description_Incomes " +
                "from AllIncomesData where ID =@PersonID Order by IncomeDate DESC";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);
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

        public static bool IsExsit(int IncomeID)
        {
            bool isExsit = false;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "select Found = 1 from Incomes where IncomesID = @IncomeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@IncomeID",IncomeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

             isExsit = reader.HasRows;

            }
            catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return isExsit;
        }

        public static bool Delete(int IncomeID) {

            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "Delete from Incomes where IncomesID = @IncomesID";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@IncomesID", IncomeID);

            try
            {
                connection.Open();


                RowAffected =  command.ExecuteNonQuery();



            }catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return (RowAffected > 0 );
            


        }


    }
}
