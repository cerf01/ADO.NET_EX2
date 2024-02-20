using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp12
{
    internal class Program
    {

        public static string connectionStr => "Data Source=DESKTOP-BRQ9LQE\\SQLEXPRESS;Initial Catalog=Storage;Integrated Security=True;Connect Timeout=30;";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Connected!");
                string q = "";
                while (q != "e")
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Navigation:exit, ex1,  ex2, ex3,  ex4, ex5, ex6, ex7, ex8, ex9, ex10, ex11, ex12, ex13, ex14, ex15,  ex16, ex17,  ex18, ex19, ex20, ex21, ex22, ex23, ex24");
                    q = Console.ReadLine();
                    Console.WriteLine();
                    switch (q.ToLower())
                    {
                        default:
                            Console.WriteLine("wrong input!");
                            break;
                        case "exit":
                            {

                                q = "e";
                                connection.Close();
                                Console.WriteLine("goodbye!");
                                break;
                            }
                            break;
                        case "1":
                        case "ex1":
                            {
                                string query = "SELECT * FROM Ware";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "2":
                        case "ex2":
                            {
                                string query = "SELECT * FROM WareType";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "3":
                        case "ex3":
                            {
                                string query = "SELECT * FROM Supplier";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "4":
                        case "ex4":
                            {
                                string query = "SELECT [Name], WareCount FROM Ware WHERE WareCount = (SELECT MAX(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "5":
                        case "ex5":
                            {
                                string query = "SELECT [Name], WareCount FROM Ware WHERE WareCount = (SELECT MIN(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "6":
                        case "ex6":
                            {
                                string query = "SELECT [Name], Cost FROM Ware WHERE Cost = (SELECT MIN(Cost) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "7":
                        case "ex7":
                            {
                                string query = "SELECT [Name], Cost FROM Ware WHERE Cost = (SELECT MAX(Cost) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "8":
                        case "ex8":
                            {
                                Console.WriteLine("Enter category: ");
                                string inputCategory = Console.ReadLine();
                                string query = $"SELECT * FROM Ware,WareType WHERE WareType.Id = Ware.WareTypeId AND LOWER(WareType.TypeName) = '{inputCategory.ToLower()}'";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "9":
                        case "ex9":
                            {
                                Console.WriteLine("Enter supplier: ");
                                string inputSupplier = Console.ReadLine();
                                string query = $"SELECT * FROM Ware,Supplier WHERE Supplier.Id = Ware.SupplierId AND LOWER(Supplier.[Name]) = '{inputSupplier.ToLower()}'";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "10":
                        case "ex10":
                            {
                                string query = $"SELECT AVG(WareCount) FROM Ware INNER JOIN WareType ON Ware.WareTypeID = WareType.Id";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "11":
                        case "ex11":
                            {
                                Console.WriteLine("Enter wares name");
                                string wareName = Console.ReadLine();
                                int supplierId = 0, wareTypeId = 0, wareCount = 0, cost = 0;
                                if (string.IsNullOrEmpty(wareName))
                                    return;

                                Console.WriteLine("Enter suppliers id");
                                supplierId = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter wares type id");
                                wareTypeId = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter wares count");
                                wareCount = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter wares cost");
                                cost = setLineDigit(Console.ReadLine());

                                string query = $"INSERT INTO Ware VALUES ('{wareName}',{supplierId}, {wareTypeId}, {wareCount}, {cost})";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "12":
                        case "ex12":
                            {

                                Console.WriteLine("Enter suppliers name");
                                string supplierName = Console.ReadLine();
                                if (string.IsNullOrEmpty(supplierName))
                                    return;

                                Console.WriteLine("Enter supplers country");
                                string supplierCountry =Console.ReadLine() ;
                                if (string.IsNullOrEmpty(supplierCountry))
                                    return;

                                string query = $"INSERT INTO Supplier VALUES ('{supplierName}','{supplierCountry}')";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "13":
                        case "ex13":
                            {

                                Console.WriteLine("Enter wares type");
                                string wareType = Console.ReadLine();
                                if (string.IsNullOrEmpty(wareType))
                                    return;
                            

                                string query = $"INSERT INTO WareType VALUES ('{wareType}')";
                                changeTableInfo(query, connection);
                                Console.ReadKey();

                            }
                            break;                      
                        case "14":
                        case "ex14":
                            {
                                Console.WriteLine("Enter wares id ");
                                int wareTOUpadte = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new wares name");
                                string wareName = Console.ReadLine();                          
                                int supplierId = 0, wareTypeId = 0, wareCount = 0, cost = 0;
                                if (string.IsNullOrEmpty(wareName))
                                    return;

                                Console.WriteLine("Enter new suppliers id");
                                supplierId = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new wares type id");
                                wareTypeId = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new wares count");
                                wareCount = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new wares cost");
                                cost = setLineDigit(Console.ReadLine());

                                string query = $"UPDATE Ware SET [Name] = '{wareName}', SupplierId = {supplierId}, WareTypeId = {wareTypeId}, WareCount = {wareCount}, Cost = {cost} WHERE Id = {wareTOUpadte}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "15":
                        case "ex15":
                            {
                                Console.WriteLine("Enter suppliers id ");
                                int supplierTOUpadte = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new suppliers name");
                                string supplierName = Console.ReadLine();
                                if (string.IsNullOrEmpty(supplierName))
                                    return;

                                Console.WriteLine("Enter new supplers country");
                                string supplierCountry = Console.ReadLine();
                                if (string.IsNullOrEmpty(supplierCountry))
                                    return;

                                string query = $"UPDATE Supplier SET [Name] ='{supplierName}', SupplierCountry = '{supplierCountry}' WHERE Id = {supplierTOUpadte}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "16":
                        case "ex16":
                            {

                                Console.WriteLine("Enter  wares type id ");
                                int typeTOUpadte = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter new wares type");
                                string wareType = Console.ReadLine();
                                if (string.IsNullOrEmpty(wareType))
                                    return;


                                string query = $"UPDATE WareType SET TypeName = '{wareType}',WHERE Id = {typeTOUpadte}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();

                            }
                            break;
                        case "17":
                        case "ex17":
                            {
                                Console.WriteLine("Enter wares id ");
                                int idTODelete= setLineDigit(Console.ReadLine());

                                string query = $"Delete FROM Ware WHERE Id = {idTODelete}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "18":
                        case "ex18":
                            {

                                Console.WriteLine("Enter wares id ");
                                int idTODelete = setLineDigit(Console.ReadLine());

                                string query = $"Delete FROM Supplier WHERE Id = {idTODelete}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "19":
                        case "ex19":
                            {
                                Console.WriteLine("Enter wares id ");
                                int idTODelete = setLineDigit(Console.ReadLine());

                                string query = $"Delete FROM WareType WHERE Id = {idTODelete}";
                                changeTableInfo(query, connection);
                                Console.ReadKey();

                            }
                            break;
                        case"20":
                        case "ex20": 
                        {
                                string query = $"SELECT Supplier.Id, Supplier.Name, Supplier.SupplierCountry FROM Supplier, Ware WHERE Ware.SupplierId = Supplier.Id AND Ware.WareCount = (SELECT MAX(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "21":
                        case "ex21":
                            {
                                string query = $"SELECT Supplier.Id, Supplier.Name, Supplier.SupplierCountry FROM Supplier, Ware WHERE Ware.SupplierId = Supplier.Id AND Ware.WareCount = (SELECT MIN(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "22":
                        case "ex22":
                            {
                                string query = $"SELECT WareType.Id, WareType.TypeName FROM WareType, Ware WHERE Ware.WareTypeId = WareType.Id AND Ware.WareCount = (SELECT MAX(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "23":
                        case "ex23":
                            {
                                string query = $"SELECT WareType.Id, WareType.TypeName FROM WareType, Ware WHERE Ware.WareTypeId = WareType.Id AND Ware.WareCount = (SELECT MIN(WareCount) FROM Ware)";
                                showTableInfo(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "24":
                        case "ex24":
                            {
                               
                            }
                            break;

                    }
                }
              

                Console.ReadKey();
            }
        }
        public static void showTableInfo(string query, SqlConnection connctinon)
        {
            using (var cmd = new SqlCommand(query, connctinon))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i] + "    ");
                    Console.WriteLine();
                }
                reader.Close();
            }
        }

        public static void changeTableInfo(string query, SqlConnection connctinon)
        {
            using (var cmd = new SqlCommand(query, connctinon))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Executed!");
            }
        }

        public static int setLineDigit(string str)
        {
            string numLine = str;
            if (numLine.All(c => char.IsDigit(c)))
                return Convert.ToInt32(numLine);

            Console.WriteLine("is not a digit! try again");

            setLineDigit(Console.ReadLine());
            return 0;
        }

    }
}