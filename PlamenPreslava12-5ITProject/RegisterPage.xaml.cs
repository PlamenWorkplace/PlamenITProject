using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace PlamenPreslava12_5ITProject
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=Plamkata123;database=student_records";

            try
            {
                sqlCon.Open();
                string query = "INSERT INTO student VALUES (@StudentID, @Surname, @FirstNames, @Class, @Pasword)";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentID", textBoxStudentID.Text);
                cmd.Parameters.AddWithValue("@Surname", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@FirstNames", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@Class", textBoxClass.Text);
                cmd.Parameters.AddWithValue("@Pasword", passwordBox.Password);
                cmd.ExecuteNonQuery();
                string query2 = "INSERT INTO Student_Additional_Information VALUES (@StudentID, @Gender, @Email, @Telephone, @ParentSurname, @ParentFirstNames, @ParentPhone)";
                MySqlCommand cmd2 = new MySqlCommand(query2, sqlCon);
                cmd2.Parameters.AddWithValue("@StudentID", textBoxStudentID.Text);
                cmd2.Parameters.AddWithValue("@Gender", textBoxGender.Text);
                cmd2.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                cmd2.Parameters.AddWithValue("@Telephone", textBoxTelephone.Text);
                cmd2.Parameters.AddWithValue("@ParentSurname", textBoxParentLastName.Text);
                cmd2.Parameters.AddWithValue("@ParentFirstNames", textBoxParentFirstName.Text);
                cmd2.Parameters.AddWithValue("@ParentPhone", textBoxParentTelephone.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                sqlCon.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
