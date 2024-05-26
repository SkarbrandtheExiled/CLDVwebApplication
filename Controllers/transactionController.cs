﻿using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDVwebApplication.Controllers
{
    public class transactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userId, int productId)
        {
            try
            {
                // Create a new instance of SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(productTable.con_string))
                {
                    // Define the SQL query to insert a new record into the transactionTable
                    string sql = "INSERT INTO transactionTable (userID, productID) VALUES (@userID, @productID)";

                    // Create a new instance of SqlCommand with the SQL query and SqlConnection
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Add parameters to the SqlCommand for userID and productID
                        cmd.Parameters.AddWithValue("@userID", userId);
                        cmd.Parameters.AddWithValue("@productID", productId);

                        // Open the SqlConnection
                        con.Open();

                        // Execute the SqlCommand to insert the record into the transactionTable
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Close the SqlConnection
                        con.Close();

                        // Check if the insert operation was successful
                        if (rowsAffected > 0)
                        {
                            // Redirect the user to the home page after placing the order
                            return RedirectToAction("Orders", "Home");
                        }
                        else
                        {
                            // If the insert operation failed, return an error view or message
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, return an error view or message
                return View("Error");
            }
        }
    }
}