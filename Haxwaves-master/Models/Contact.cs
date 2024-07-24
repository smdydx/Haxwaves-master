using System.Data.SqlClient;
using System.Windows.Input;

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
            ClientInfo.Message = context.Request.Form["ClientInfo.Message"];

            if (string.IsNullOrEmpty(ClientInfo.FullName) || string.IsNullOrEmpty(ClientInfo.Email) || string.IsNullOrEmpty(ClientInfo.PhoneNumber) || string.IsNullOrEmpty(ClientInfo.Subject) || string.IsNullOrEmpty(ClientInfo.Message))
            {
                ErrorMessage = "All fields are required.";
                return; // Exit the method if any field is empty
            }

            try
            {
                string connectionString = "Data Source=LAPTOP-S9QPQDAD\\MSSQLSERVER01;Initial Catalog=HexaContact;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Clients (FullName, Email, PhoneNumber,Subject,Message) VALUES (@FullName, @Email, @PhoneNumber, @Subject,@Message)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", ClientInfo.FullName);
                        command.Parameters.AddWithValue("@Email", ClientInfo.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", ClientInfo.PhoneNumber);
                        command.Parameters.AddWithValue("@Subject", ClientInfo.Subject);
                        command.Parameters.AddWithValue("@Message", ClientInfo.Message);
                        command.ExecuteNonQuery();
                    }
                }

                // Clear the form fields after successful submission
                ClientInfo.FullName = "";
                ClientInfo.Email = "";
                ClientInfo.PhoneNumber = "";
                ClientInfo.Subject = "";
                ClientInfo.Message = "";

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
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}

