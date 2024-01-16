using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGateCircuitMakerMenu
{
    public partial class Form3 : Form
    {
        const string CONN_STRING = $"Server=localhost;Database=master;Trusted_Connection=True;";

        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private bool ContainsSpecialCharacter(string input)
        {
            // Define a regular expression pattern to match special characters
            string pattern = @"[^a-zA-Z0-9]";

            // Use Regex.IsMatch to check if the input string contains any special characters
            return Regex.IsMatch(input, pattern);
        }

        private bool CheckPasswordAndUsernameValidity()
        {
            if (usernameTextBox.Text.Length < 2 || usernameTextBox.Text.Length > 16)
            {
                MessageBox.Show("Username Must Between 2 and 16 Characters Long (Inclusive)\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return false;
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                MessageBox.Show("Password Must At Least 8 Characters Long (Inclusive)\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return false;
            }
            else if (passwordTextBox.Text == passwordTextBox.Text.ToLower())
            {
                MessageBox.Show("Password Must Have At Least 1 Uppercase Letter\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return false;
            }
            else if (passwordTextBox.Text == passwordTextBox.Text.ToUpper())
            {
                MessageBox.Show("Password Must Have At Least 1 Lowercase Letter\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return false;
            }
            else if (!ContainsSpecialCharacter(passwordTextBox.Text))
            {
                MessageBox.Show("Password Must Have At Least 1 Special Character\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return false;
            }
            return true;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            int userId;

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords Do Not Match\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            SqlConnection conn = new(CONN_STRING);
            try { conn.Open(); }
            catch
            {
                MessageBox.Show("Connection Failed\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            if (!CheckPasswordAndUsernameValidity())
                return;

            try
            {
                SqlCommand cmd = new("INSERT INTO Users (UserName, Pswrd) OUTPUT INSERTED.ID Values(@usrName, @pswrd)", conn);

                cmd.Parameters.AddWithValue("@usrName", usernameTextBox.Text);
                cmd.Parameters.AddWithValue("@pswrd", passwordTextBox.Text);

                var reader = cmd.ExecuteReader();
                reader.Read();
                userId = reader.GetInt32(0);
                reader.Close();

                conn.Close();
            }
            catch
            {
                MessageBox.Show("That Username Is Already Taken\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            //Open Form2
            this.Hide();
            var f2 = new Form2();
            f2.SetUserID(userId);
            f2.ShowDialog();
            Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            Close();
        }
    }
}
