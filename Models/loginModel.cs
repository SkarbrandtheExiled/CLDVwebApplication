
using System.Data.SqlClient;

namespace CLDVwebApplication.Models
{
    public class loginModel
    {
        public static string con_string = "Server = tcp:cldvdev.database.windows.net,1433;Initial Catalog = cldvdatabase.D8; Persist Security Info=False;User ID = ST10254164; Password={your_password}; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        public static SqlConnection con = new SqlConnection(con_string);
        public int SelectUser(string email, string name)
        {
            int userId = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new(sql, con);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name); //method to  capture the user login information 
                try
                {
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) userId = Convert.ToInt32(result);
                    
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return userId;
        }

    }
}