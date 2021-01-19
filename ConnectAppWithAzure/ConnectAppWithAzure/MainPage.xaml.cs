using Plugin.Toast;
using System;
using System.Data.SqlClient;
using Xamarin.Forms;
namespace ConnectAppWithAzure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        private void Button_Clicked(object sender, EventArgs e)
        {

            FirstName = firstNameEntry.Text;
            LastName = lastNameEntry.Text;
            Email = emailEntry.Text;
            Password = passwordEntry.Text;
            PhoneNumber = phoneNumberEntry.Text;

            string connectionString = "Server=tcp:oliverserver.database.windows.net,1433;Initial Catalog=SQLcollectUsers;Persist Security Info=False;User ID=OliverServer;Password=Oliver8677;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO MYTABLE(FIRSTNAME,LASTNAME,EMAIL,PASSWORD,PHONENUMBER) VALUES(@FIRSTNAME,@LASTNAME,@EMAIL,@PASSWORD,@PHONENUMBER)";
                    cmd.Parameters.AddWithValue("@FIRSTNAME", FirstName);
                    cmd.Parameters.AddWithValue("@LASTNAME", LastName);
                    cmd.Parameters.AddWithValue("@EMAIL", Email);
                    cmd.Parameters.AddWithValue("@PASSWORD", Password);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", PhoneNumber);
                    conn.Open();

                     cmd.ExecuteScalar();
                    CrossToastPopUp.Current.ShowToastMessage("inserted data");
                }
            }
        }
    }
}
