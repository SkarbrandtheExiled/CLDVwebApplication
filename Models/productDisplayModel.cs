using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CLDVwebApplication.Models
{
    public class productDisplayModel
    {
        public int productID {get; set;}
        public string productName {get; set;}
        public decimal productPrice {get; set;}
        public string productCategory {get; set;}
        public bool productAvailability {get; set;}

        public productDisplayModel() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public productDisplayModel(int ID, string name, decimal price, string category, bool availability)
        {
            productID = ID;
            productName = name;
            productPrice = price;
            productCategory = category;
            productAvailability = availability;
        }

        public static List<productDisplayModel> SelectProducts()
        {
            List<productDisplayModel> products = new List<productDisplayModel>();

            string con_string = "Server=tcp:cldvdev.database.windows.net,1433;Initial Catalog=cldvdatabase.D8;Persist Security Info=False;User ID=ST10254164;Password=Knight72$2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productDisplayModel product = new productDisplayModel();
                    product.productID = Convert.ToInt32(reader["productID"]);
                    product.productName = Convert.ToString(reader["productName"]);
                    product.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.productCategory = Convert.ToString(reader["productCategory"]);
                    product.productAvailability = Convert.ToBoolean(reader["productAvailability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}