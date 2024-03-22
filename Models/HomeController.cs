using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDVwebApplication.Models
{
    public class userTable
    {
        public static string con_String = "Server=tcp:cldvdev.database.windows.net,1433;Initial Catalog=cldvdatabase.D8;Persist Security Info=False;User ID=ST10254164;Password=Knight72$2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_String);

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int insert_user(userTable n)
        {
try
            {
                string sql = "INSERT INTO HomeController (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", n.Name);
                cmd.Parameters.AddWithValue("@Surname", n.Surname);
                cmd.Parameters.AddWithValue("@Email", n.Email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;

            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
