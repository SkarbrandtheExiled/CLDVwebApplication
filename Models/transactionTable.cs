using System.Data.SqlClient;
namespace CLDVwebApplication.Models
{
    public class transactionTable
    {
        public static string con_string = "Server=tcp:cldvdev.database.windows.net,1433;Initial Catalog=cldvdatabase.D8;Persist Security Info=False;User ID=ST10254164;Password=Knight72$2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection Con = new(con_string);

        public int transactionID { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public DateTime transactionDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        // Retrieve orders
        public static List<transactionTable> GetAllOrders()
        {
            var transactions = new List<transactionTable>();

            using var con = new SqlConnection(con_string);
            const string sql = "SELECT * FROM transactionTable";
            var cmd = new SqlCommand(sql, con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var transaction = new transactionTable
                {
                    transactionID = Convert.ToInt32(rdr["transactionTableID"]),
                    userId = Convert.ToInt32(rdr["userID"]),
                    productId = Convert.ToInt32(rdr["productID"]),
                    transactionDate = Convert.ToDateTime(rdr["transactionDate"]),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalAmount = Convert.ToDecimal(rdr["totalAmount"])
                };
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
