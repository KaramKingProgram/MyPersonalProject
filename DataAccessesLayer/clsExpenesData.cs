using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessesLayer;
using System.Configuration;
using System.Runtime.InteropServices;
namespace DataAccessesLayer
{
    public class clsExspensesData
    {
        public static bool GetExpensesInfoByID(ref int ExpensesID, ref string Expenses_Name, ref decimal Exchgange_Amount, ref DateTime ExpenseDate, ref int ExpenseType,
         ref int PaymentMethod, ref string Description_ex, ref int PersonID, ref int CurrencyID)
        {
            bool IsFound = false;

            string Quere = "Select * from Expenses where ExpensesID = @ExpenID";

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            SqlCommand Command = new SqlCommand(Quere, connection);

            Command.Parameters.AddWithValue("@ExpenID", ExpensesID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["ExpensesName"] != DBNull.Value)
                    {
                        Expenses_Name = (string)reader["ExpensesName"];

                    }
                    else
                    {
                        Expenses_Name = "";
                    }


                    Exchgange_Amount = (decimal)reader["Exchgange_Amount"];
                    ExpenseDate = (DateTime)reader["ExpenseDate"];
                    ExpenseType = (int)reader["ExpensesTypes"];
                    PaymentMethod = (int)reader["PaymentMethod"];
                    PersonID = (int)reader["PersonID"];
                    CurrencyID = (int)reader["CurrencyID"];

                    if (reader["Description_ex"] != DBNull.Value)
                    {
                        Description_ex = (string)reader["Description_ex"];
                    }
                    else
                    {
                        Description_ex = "";
                    }

                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static bool GetExpensesInfoByName(ref int ExpensesID, ref string Expenses_Name, ref decimal Exchgange_Amount, ref DateTime ExpenseDate, ref int ExpenseType,
         ref int PaymentMethod, ref string Description_ex, ref int PersonID, ref int CurrencyID)
        {
            bool IsFound = false;

            string Quere = "Select * from Expinses where ExpensesName = @ExpenName";

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            SqlCommand Command = new SqlCommand(Quere, connection);

            Command.Parameters.AddWithValue("@ExpenName", Expenses_Name);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    if (reader["ExpensesName"] != DBNull.Value)
                    {
                        Expenses_Name = (string)reader["ExpensesName"];

                    }
                    else
                    {
                        Expenses_Name = "";
                    }

                    Exchgange_Amount = (decimal)reader["Exchgange_Amount"];
                    ExpenseDate = (DateTime)reader["ExpensesDate"];
                    ExpenseType = (int)reader["ExpensesTyped"];
                    PaymentMethod = (int)reader["PaymentMethod"];
                    PersonID = (int)reader["PersonID"];
                    CurrencyID = (int)reader["CurrencyID"];

                    if (reader["Description_ex"] != DBNull.Value)
                    {
                        Description_ex = (string)reader["Description_ex"];
                    }
                    else
                    {
                        Description_ex = "";
                    }

                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNew( string Expenses_Name,  decimal Exchgange_Amount,  DateTime ExpenseDate, int ExpenseType,
          int PaymentMethod,  string Description_ex,  int PersonID,  int CurrencyID)
        {
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "insert into Expenses ([ExpensesName] ,[Exchgange_Amount],[ExpenseDate] ,[ExpensesTypes],[PaymentMethod],[Description_ex],[PersonID],[CurrencyID])" +
                "values ( @Expenses_Name ,@Exchgange_Amount,@ExpenseDate,@ExpensesTypes,@PaymentMethod,@Description_ex,@PersonID,@CurrencyID);Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Quere, connection);

            if (Expenses_Name != "")
               command.Parameters.AddWithValue("@Expenses_Name", Expenses_Name);
            else
                command.Parameters.AddWithValue("@Expenses_Name", System.DBNull.Value);

            


            command.Parameters.AddWithValue("@Exchgange_Amount", Exchgange_Amount);
            command.Parameters.AddWithValue("@ExpenseDate", ExpenseDate);
            command.Parameters.AddWithValue("@ExpensesTypes", ExpenseType);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);

            if (Description_ex!="")
            command.Parameters.AddWithValue("@Description_ex", Description_ex);
            else
            command.Parameters.AddWithValue("@Description_ex", System.DBNull.Value);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


            int ID = -1;


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
             

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }


        public static bool DeleteExpenses(int ExpensesID)
        {
            int RowAffected = 0; ;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "Delete From Expenses where ExpensesID = @ExpensesID";



            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ExpensesID", ExpensesID);

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();
            }
            return (RowAffected > 0);
        }

        //public static bool DeleteExpenses(string ExpensesName)
        //{
        //    int RowAffected = 0; ;

        //    SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

        //    string Quere = "Delete From Expenses where ExpensesName = @ExpensesName";



        //    SqlCommand command = new SqlCommand(Quere, connection);

        //    command.Parameters.AddWithValue("@ExpensesName", ExpensesName);

        //    try
        //    {
        //        connection.Open();

        //        RowAffected = command.ExecuteNonQuery();

        //    }
        //    catch (Exception ex) { }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return (RowAffected > 0);
        //}


        public static bool UpdateExpenses(int ExpensesID, string Expenses_Name,  decimal Exchgange_Amount,  DateTime ExpenseDate, int ExpenseType,
        int PaymentMethod,  string Description_ex,  int PersonID, int CurrencyID)
        {
            int RowAffected = 0; ;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "Update Expenses " +
                "set ExpensesName = @Expenses_Name , Exchgange_Amount = @Exchgange_Amount ,ExpenseDate = @ExpenseDate , ExpensesTypes = @ExpenseType," +
                "PaymentMethod =@PaymentMethod , Description_ex = @Description_ex , PersonID= @PersonID , CurrencyID = @CurrencyID where ExpensesID = @ExpensesID";



            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ExpensesID", ExpensesID);
            command.Parameters.AddWithValue("@Expenses_Name", Expenses_Name);
            command.Parameters.AddWithValue("@Exchgange_Amount", Exchgange_Amount);
            command.Parameters.AddWithValue("@ExpenseDate", ExpenseDate);
            command.Parameters.AddWithValue("@ExpenseType", ExpenseType);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
            command.Parameters.AddWithValue("@Description_ex", Description_ex);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);




            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();
            }
            return (RowAffected > 0);
        }

        public static bool IsExist(int ExpenseID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "Select Found = 1 from Expenses where ExpensesID = @ExpenseID";

            SqlCommand command = new SqlCommand(Quere, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();

            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }



        public static DataTable GetAllExpenses(int PersonID)    
        {
            DataTable table = new DataTable("Expenses");

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "Select * from Expenses where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);
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
            catch (Exception ex) {
            throw;
            }
            finally
            {
                connection.Close();
            }

            return table;


        }

        public static DataTable GetAllExpensesData(int PersonID)
        {
            DataTable table = new DataTable("Expenses");

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Quere = "Select ExpensesID,ExpensesName,Exchgange_Amount,ExpenseDate,ExpenseType,PaymentMethod,Currency_Name,Description_ex" +
                " from AllExpensesData where PersonID = @PersonID Order by ExpenseDate DESC";



            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);

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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return table;


        }


    }
}