
using System.Data.SqlClient;

namespace CLDVwebApplication.Models
{
    public class userTable
    {
        public static string con_String = "Server=tcp:cldvdev.database.windows.net,1433;Initial Catalog=cldvdatabase.D8;Persist Security Info=False;User ID=ST10254164;Password=Knight72$2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }


        public bool insert_user(userTable n)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con_String))
                {
                    string sql = "INSERT INTO userTable (userID, userName, userSurname, userEmail) VALUES (@userID, @Name, @Surname, @Email)";
                    //add a password option to use in loginModel and a userID for the loginModel
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    var random = new Random();
                    var randomNumber = random.Next(1, 1000);

                    cmd.Parameters.AddWithValue("userID", randomNumber);
                    cmd.Parameters.AddWithValue("@Name", n.Name);
                    cmd.Parameters.AddWithValue("@Surname", n.Surname);
                    cmd.Parameters.AddWithValue("@Email", n.Email);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                // Handle specific SQL errors (e.g., connection failures, duplicate key violations)
                Console.WriteLine("Error inserting user: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
