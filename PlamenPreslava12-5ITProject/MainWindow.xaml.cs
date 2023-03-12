using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PlamenPreslava12_5ITProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=Plamkata123;database=student_records";

            try
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM student WHERE StudentID=@StudentID AND Surname=@Surname AND Pasword=@Pasword";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentID", textBoxStudentID.Text);
                cmd.Parameters.AddWithValue("@Surname", textBoxUsername.Text);
                cmd.Parameters.AddWithValue("@Pasword", password.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    HomePage homePage = new HomePage();
                    homePage.Show();
                    this.Close();
                    MessageBox.Show($"Welcome, {textBoxUsername.Text} ");
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage register = new RegisterPage();
            register.Show();
            this.Close();
        }
    }
}
