using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Configuration;

namespace DataAccessesLayer
{
    public class clsDashboardData
    {
        public static DataTable GetAllDashboardData(int PersonID)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "SELECT TOP 10 TransDate, Type, Amount, PaymentMethod " +
                "FROM Dashboard WHERE PersonID = @PersonID ORDER BY TransDate DESC;";

            SqlCommand command = new SqlCommand(Query, connection);
             
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
            finally { connection.Close(); }

            return data;

        }

        public static decimal GetTotalIncomes(int PersonID)
        {
            decimal totalIncomes = 0;
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "Select Sum(Amount) from Dashboard where Type = 'Income' and PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();

                object Object = cmd.ExecuteScalar();

                totalIncomes = (Object == DBNull.Value) ? 0 : (Convert.ToDecimal(Object.ToString()));



            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return totalIncomes;

        }

        public static decimal GetTotalExpenses(int PersonID)
        {
            decimal totalExpenses = 0;
            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "Select Sum(Amount) from Dashboard where Type = 'Expense'and PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@PersonID",PersonID);
            try
            {
                connection.Open();

                object Object = cmd.ExecuteScalar();

                totalExpenses = (Object == DBNull.Value) ? 0 : (Convert.ToDecimal(Object.ToString()));



            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return totalExpenses;

        }

        public static decimal GetExpensesInThisDay(int PersonID)
        {
            decimal expensesInThisDay = 0;
            using (SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings))
            {
                string query = "SELECT SUM(Amount) FROM Dashboard WHERE Type = 'Expense' AND TransDate = @date and PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        expensesInThisDay = (result == DBNull.Value) ? 0 : Convert.ToDecimal(result);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return expensesInThisDay;
        }

        public static decimal GetIncomesThisMonth(int PersonID)
        {
            decimal incomesThisMonth = 0;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "SELECT SUM(Amount) FROM Dashboard WHERE Type = 'Income' AND MONTH(TransDate) = MONTH(GETDATE()) AND YEAR(TransDate) = YEAR(GETDATE()) " +
                "and PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                incomesThisMonth = (result == DBNull.Value) ? 0 : Convert.ToDecimal(result);

            }catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return incomesThisMonth;

        }

        public static decimal GetExpensesThisMonth(int PersonID)
        {
            decimal ExpensesThisMonth = 0;

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            string Query = "SELECT SUM(Amount) FROM Dashboard WHERE Type = 'Expense' AND MONTH(TransDate) = MONTH(GETDATE()) AND YEAR(TransDate) = YEAR(GETDATE())" +
                "and PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID );
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                ExpensesThisMonth = (result == DBNull.Value) ? 0 : Convert.ToDecimal(result);

            }
            catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return ExpensesThisMonth;

        }

        public static DataTable GetExpenseTypesPerc(int PersonID) {

            SqlConnection connection = new SqlConnection(clsPersonalDataSettings.DataAccsessSettings);

            DataTable table = new DataTable();

            string query = "SELECT    ExpensesTypes.Name_Type ,   SUM(Expenses_1.Exchgange_Amount) / (SELECT SUM(Exchgange_Amount) AS Expr1 FROM Expenses where PersonID = @PersonID) * 100 AS TypesPerc FROM  " +
                "Expenses AS Expenses_1 INNER JOIN ExpensesTypes ON Expenses_1.ExpensesTypes = ExpensesTypes.ExpensesTypesID " +
                "where PersonID = @PersonID " +
                "GROUP BY ExpensesTypes.Name_Type " +
                "ORDER BY TypesPerc DESC ";

            SqlCommand command = new SqlCommand(query, connection);

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
            }catch (Exception ex) { throw; }
            finally { connection.Close(); }

            return table;



        }


    }
}

