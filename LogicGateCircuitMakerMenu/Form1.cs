using System.Data.SqlClient;

namespace LogicGateCircuitMakerMenu
{
    public partial class Form1 : Form
    {
        const string CONN_STRING = $"Server=localhost;Database=master;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            int userId;

            //Check database for user and if password is correct
            SqlConnection conn = new(CONN_STRING);
            try { conn.Open(); }
            catch
            {
                MessageBox.Show("Connection Failed\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            var cmd = new SqlCommand("SELECT ID FROM Users WHERE UserName = @usrName AND pswrd = @pswrd;", conn);
            cmd.Parameters.AddWithValue("@usrName", usernameTextBox.Text);
            cmd.Parameters.AddWithValue("@pswrd", passwordTextBox.Text);
            
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try { userId = reader.GetInt32(0); }
            catch
            {
                MessageBox.Show("Username Or Password Is Inncorect\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            //Open Form2
            this.Hide();
            var f2 = new Form2();
            f2.SetUserID(userId);
            f2.ShowDialog();
            Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //If user is made go to Form2
            this.Hide();
            new Form3().ShowDialog();
            Close();
        }
    }
}