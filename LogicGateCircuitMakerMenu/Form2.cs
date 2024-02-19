using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGateCircuitMakerMenu
{
    public partial class Form2 : Form
    {
        private const string CONN_STRING = $"Server=localhost;Database=master;Trusted_Connection=True;";
        private List<string> _userDatabaseCircuits = new();
        private int _userId;
        private List<String> _dateCreated;
        private List<String> _alphabetizeUp;
        private List<String> _alphabetizeDown;
        private List<String> _lastUpdatedUp;
        private List<String> _lastUpdatedDown;

        public void SetUserID(int userId) { _userId = userId; }
        //Gets all the circuits of the user
        private void GetCircuitsOfUser()
        {
            SqlConnection conn = new(CONN_STRING);
            try { conn.Open(); }
            catch
            {
                MessageBox.Show("Connection Failed\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                return;
            }

            SqlCommand cmd = new($"SELECT CircuitName FROM Circuits WHERE UserID = @userId", conn);
            cmd.Parameters.AddWithValue("@userId", _userId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
                _dateCreated.Add(reader.GetString(0));
            conn.Close();

            ChangeDatabaseDropDown(_dateCreated);
        }
        private void ChangeDatabaseDropDown(List<string> listToChangeTo)
        {
            datbaseOpenComboBox.Items.Clear();
            for (int i = 0; i < listToChangeTo.Count; i++)
                datbaseOpenComboBox.Items.Add(listToChangeTo[i]);
        }
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            AutoScroll = true;
            _dateCreated = new List<string>();
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            GetCircuitsOfUser();
        }

        private void openLocal_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Filter = "Only .vcb|*.vcb"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Start Circuit Board sending it the file location
                ProcessStartInfo startInfo = new();
                startInfo.FileName = "C:\\Users\\archi\\Coding\\Project\\!(OLD) Logic Gate Circuit Maker\\GUI Stf\\bin\\Debug\\net6.0-windows\\LogicGateCircuitMaker.exe";
                startInfo.UseShellExecute = true;
                startInfo.Arguments = $"{_userId} \"{ofd.FileName}\"";
                Process.Start(startInfo);
                Close();
            }
        }

        private void createNewCircuit_Click(object sender, EventArgs e)
        {
            //Starts Circuit Board
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:\\Users\\archi\\Coding\\Project\\!(OLD) Logic Gate Circuit Maker\\GUI Stf\\bin\\Debug\\net6.0-windows\\LogicGateCircuitMaker.exe";
            startInfo.Arguments = _userId.ToString();
            Process.Start(startInfo);
            Close();
        }

        private void databaseOpenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Identify which button was clicked based on its text
            string buttonText = datbaseOpenComboBox.Items[datbaseOpenComboBox.SelectedIndex].ToString()!;

            //Start connection to database
            SqlConnection conn = new(CONN_STRING);
            conn.Open();

            //Run the select command to find the correct circuit
            SqlCommand cmd = new($"SELECT Circuit FROM Circuits WHERE CircuitName = @circuitName", conn);
            cmd.Parameters.AddWithValue("@circuitName", buttonText);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //Create the temp file of the selceted circuit
            var filename = "./temp.vcb";
            Stream stream = File.Create(filename);
            using BinaryWriter bw = new BinaryWriter(stream);
            bw.Write(reader.GetSqlBytes(0).Value);

            //Start Circuit Board sending it the temp file location
            ProcessStartInfo startInfo = new();
            startInfo.FileName = "C:\\Users\\archi\\Coding\\Project\\!(OLD) Logic Gate Circuit Maker\\GUI Stf\\bin\\Debug\\net6.0-windows\\LogicGateCircuitMaker.exe";
            startInfo.UseShellExecute = true;
            startInfo.Arguments = $"{_userId} {filename} {buttonText}";
            Process.Start(startInfo);

            conn.Close();
            Close();
        }

        private void dateCreatedRadio_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDatabaseDropDown(_dateCreated);
        }

        private void lastUpdatedDownRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_lastUpdatedDown == null)
            {
                _lastUpdatedDown = new List<string>();
                SqlConnection conn = new(CONN_STRING);
                try { conn.Open(); }
                catch
                {
                    MessageBox.Show("Connection Failed\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    return;
                }

                SqlCommand cmd = new($"SELECT CircuitName FROM Circuits WHERE UserID = @userId ORDER BY DateUpdated DESC", conn);
                cmd.Parameters.AddWithValue("@userId", _userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    _lastUpdatedDown.Add(reader.GetString(0));
                conn.Close();
            }
            ChangeDatabaseDropDown(_lastUpdatedDown);
        }

        private void lastUpdatedUpRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_lastUpdatedUp == null)
            {
                _lastUpdatedUp = new List<string>();
                SqlConnection conn = new(CONN_STRING);
                try { conn.Open(); }
                catch
                {
                    MessageBox.Show("Connection Failed\nPlease Try Again", "Circuit Board", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    return;
                }

                SqlCommand cmd = new($"SELECT CircuitName FROM Circuits WHERE UserID = @userId ORDER BY DateUpdated ASC", conn);
                cmd.Parameters.AddWithValue("@userId", _userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    _lastUpdatedUp.Add(reader.GetString(0));
                conn.Close();
            }
            ChangeDatabaseDropDown(_lastUpdatedUp);
        }

        private void alphabetizeDownRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_alphabetizeDown == null)
            {
                _alphabetizeDown = new List<string>();
                _alphabetizeDown = _dateCreated;

                //Insertion sort (As bubble is less efficent, and a merge is less efficent for small sizes)
                for (int i = 1; i < _alphabetizeDown.Count; ++i)
                {
                    string key = _alphabetizeDown[i];
                    int j = i - 1;

                    while (j >= 0 && _alphabetizeDown[j].CompareTo(key) == 1)
                    {
                        _alphabetizeDown[j + 1] = _alphabetizeDown[j];
                        j--;
                    }
                    _alphabetizeDown[j + 1] = key;
                }
            }
            ChangeDatabaseDropDown(_alphabetizeDown);
        }

        private void alphabetizeUpRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_alphabetizeUp == null)
            {
                _alphabetizeUp = new List<string>();
                _alphabetizeUp = _dateCreated;

                //Insertion Sort (As bubble is less efficent, and a merge is less efficent for small sizes)
                for (int i = 1; i < _alphabetizeUp.Count; ++i)
                {
                    string key = _alphabetizeUp[i];
                    int j = i - 1;

                    while (j >= 0 && _alphabetizeUp[j].CompareTo(key) == -1)
                    {
                        _alphabetizeUp[j + 1] = _alphabetizeUp[j];
                        j--;
                    }
                    _alphabetizeUp[j + 1] = key;
                }
            }
            ChangeDatabaseDropDown(_alphabetizeUp);
        }
    }
}
