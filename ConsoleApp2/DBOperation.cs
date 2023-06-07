using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class DBOperation
    {
        public void ReadData()
        {
            string connectionString =
                "Data Source=(local);Initial Catalog=Book;"
                + "Integrated Security=true";


            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from dbo.MMABook ";
            using (SqlConnection connection =
           new SqlConnection(connectionString))
            {
     
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //create a list of retrived data.
                    while (reader.Read())
                    {
                        
                        // you can create a object and store single row in that object.
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        public void InsertData()
        {
            Product product = new Product();
            Console.WriteLine("Please enter product code");
            product.ProductCode= Console.ReadLine();

            Console.WriteLine("Please enter Description");
            product.Description = Console.ReadLine();

            Console.WriteLine("Please enter Unit Price");
            product.UnitPrice = Convert.ToDecimal(Console.ReadLine());

            string connectionString =
               "Data Source=(local);Initial Catalog=Book;"
               + "Integrated Security=true";


            // Provide the query string with a parameter placeholder.               

            string queryString =
               "INSERT into dbo.MMABook(ProductCode, Description, UnitPrice) " +
                "VALUES (@ProductCode, @Description, @UnitPrice) ";
            using (SqlConnection connection =
           new SqlConnection(connectionString))
            {

                SqlCommand insertCommand = new SqlCommand(queryString, connection);
                insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                // simply Parameters property returns a SqlParameterCollection object that contains all the parameters for the command.
                // add parameters to parameters collection
                // for this use parameters properties of command object and use AddWithValue() method of parameters collection.
                insertCommand.Parameters.AddWithValue("@Description", product.Description);
                insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);



                try
                {
                    connection.Open();
                    int productCount = insertCommand.ExecuteNonQuery();
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        public void DeleteData()
        {
            Product product = new Product();
            Console.WriteLine("Please enter product code you want to delete");
            product.ProductCode = Console.ReadLine();

            string connectionString = "Data Source=(local);Initial Catalog=Book;"
               + "Integrated Security=true";

            string queryString = "DELETE from dbo.MMABook where ProductCode=@ProductCode";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand deleteCommand = new SqlCommand(queryString, connection);
                deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);

                try
                {
                    connection.Open();
                    int deleteCount = deleteCommand.ExecuteNonQuery();

                    connection.Close();
                    Console.WriteLine("Successfully deleted." + deleteCount + "items");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        public void UpdateData()
        {
            Product obj = new Product();
            Console.WriteLine("Please enter a product code you want to update.");
            obj.ProductCode= Console.ReadLine();

            Product updateObj = new Product();
            Console.WriteLine("Please enter new Product Code");
            updateObj.ProductCode = Console.ReadLine();
            Console.WriteLine("Please enter new description Code");
            updateObj.Description = Console.ReadLine();
            Console.WriteLine("Please enter new UnitPrice Code");
            updateObj.UnitPrice =Convert.ToDecimal( Console.ReadLine());

            string connectionString= "Data Source=(local);Initial Catalog=Book;"
               + "Integrated Security=true";
            string queryString = "update dbo.MMABook set ProductCode=@ProductCodeU, Description=@Description, UnitPrice=@UnitPrice where ProductCode=@ProductCode";

            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand updateCommand = new SqlCommand(queryString, connection);
                updateCommand.Parameters.AddWithValue("@ProductCode", obj.ProductCode);
                updateCommand.Parameters.AddWithValue("@ProductCodeU", updateObj.ProductCode);
                updateCommand.Parameters.AddWithValue("@Description", updateObj.Description);
                updateCommand.Parameters.AddWithValue("@UnitPrice", updateObj.UnitPrice);
               

                try
                {
                    connection.Open();
                    int updateCount = updateCommand.ExecuteNonQuery();

                    connection.Close();
                    Console.WriteLine("Successfully updated." + updateCount + "items");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
