using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Http;

namespace Haxwaves_master.Models
{
    public class Contact
    {
        public ClientInfo ClientInfo { get; set; } = new ClientInfo();
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        // Method to handle GET operation (display form)
        public void OnGet()
        {
            // Optionally initialize any data needed for the form
        }

        // Method to handle POST operation (process form submission)
        public void OnPost(HttpContext context)
        {
            ClientInfo.FullName = context.Request.Form["ClientInfo.FullName"];
            ClientInfo.Email = context.Request.Form["ClientInfo.Email"];
            ClientInfo.PhoneNumber = context.Request.Form["ClientInfo.PhoneNumber"];
            ClientInfo.Subject = context.Request.Form["ClientInfo.Subject"];


            if (string.IsNullOrEmpty(ClientInfo.FullName) || string.IsNullOrEmpty(ClientInfo.Email) || string.IsNullOrEmpty(ClientInfo.PhoneNumber) || string.IsNullOrEmpty(ClientInfo.Subject) || string.IsNullOrEmpty(ClientInfo.Message))
            {
                ErrorMessage = "All fields are required.";
                return; // Exit the method if any field is empty
            }
            try
            {
                string connectionString = "Data Source=LAPTOP-S9QPQDAD\\MSSQLSERVER01;Initial Catalog=HexaContact;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Contacts (FullName, Email, PhoneNumber, Subject, Message) VALUES (@FullName, @Email, @PhoneNumber, @Subject, @Message)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", ClientInfo.FullName );
                        command.Parameters.AddWithValue("@Email", ClientInfo.Email) ;
                        command.Parameters.AddWithValue("@PhoneNumber", ClientInfo.PhoneNumber );
                        command.Parameters.AddWithValue("@Subject", ClientInfo.Subject );
                        command.Parameters.AddWithValue("@Message", ClientInfo.Message );
                        command.ExecuteNonQuery();
                    }
                }

                ClientInfo.FullName = "";
                ClientInfo.Email = "";
                ClientInfo.PhoneNumber = "";
                ClientInfo.Subject = "";
                ClientInfo.Message = "";

                // Clear the form fields after successful submission
                
                SuccessMessage = "Client information saved successfully!";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }

    public class ClientInfo
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
