using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace User_Registration
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source = DESKTOP-N7GTNP7\SQLEXPRESS; Initial Catalog = UserRegistrationDB; Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "" || TxtPassword.Text == "")
                MessageBox.Show("Please fill mandatory fields");
            else if (TxtPassword.Text != TxtConfirmPassword.Text)
                MessageBox.Show("Password do not match");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName",TxtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", TxtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Contact", TxtContact.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Address", TxtAddress.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Username", TxtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", TxtPassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Registration is successfull");
                Clear();

            }
        }
        void Clear()
        {
            TxtFirstName.Text = TxtLastName.Text = TxtContact.Text = TxtAddress.Text = TxtUsername.Text = TxtPassword.Text
                = TxtConfirmPassword.Text = "";
        }
    }
}
