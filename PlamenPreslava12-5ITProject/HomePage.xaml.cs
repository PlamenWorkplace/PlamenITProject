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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public string StudentID;

        string sqlConnectionString = "server=localhost;uid=root;pwd=Plamkata123;database=student_records";

        private void class_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = sqlConnectionString;

            try
            {
                
                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query
                string query1 = " SELECT Class FROM Student where StudentID = '" + StudentID + "'";
                MySqlCommand cmd1 = new MySqlCommand(query1, sqlCon);
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@StudentID", query1);
                cmd1.ExecuteNonQuery();
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                string a = "";
                while (reader1.Read())
                {

                    a = reader1["Class"].ToString();


                }
                reader1.Close();
                Class clazz = new Class();
                string query2 = $"SELECT Class,Class_Representative_ID,Profile_Subject FROM Class WHERE Class = '{a}'";
                MySqlCommand cmd2 = new MySqlCommand(query2, sqlCon);
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = query2;
                cmd2.Parameters.AddWithValue("@Class", query2);
                cmd2.ExecuteNonQuery();
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                
                string profile = "";

                while (reader2.Read())
                {

                    clazz.textBlockClass.Text = reader2["Class"].ToString();
                    clazz.textBlockClassRepresentative.Text = reader2["Class_Representative_ID"].ToString();
                    clazz.textBlockProfile.Text = reader2["Profile_Subject"].ToString();
                    profile = reader2["Profile_Subject"].ToString();

                }
                reader2.Close();

                string query3 = $"SELECT Profile_Subject,Hours_Per_Year,Teachers FROM Profile_Subject WHERE Profile_Subject = '{profile}'";
                //Establish a sql command

                MySqlCommand cmd3 = new MySqlCommand(query3, sqlCon);

                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = query3;
                cmd3.Parameters.AddWithValue("@Profile_Subject", query3);
                cmd3.ExecuteNonQuery();
                MySqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {

                    clazz.textBlockProfileSubject.Text = reader3["Profile_Subject"].ToString();
                    clazz.textBlockHoursPerYear.Text = reader3["Hours_Per_Year"].ToString();
                    clazz.textBlockTeacher.Text = reader3["Teachers"].ToString();

                }
                reader3.Close();
                clazz.StudentID = StudentID;
                clazz.Show();
                this.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }
        }

        private void grades_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = sqlConnectionString;
            try
            {
                
                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query
                string query = " SELECT Math, Informatics, Biology, English, World_History FROM Grades_By_ID WHERE StudentID = '" + StudentID + "'";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@StudentID", query);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                Grades grades = new Grades();
                while (reader.Read())
                {

                    grades.textBlockMath.Text = reader["Math"].ToString();
                    grades.textBlockInformatics.Text = reader["Informatics"].ToString();
                    grades.textBlockBiology.Text = reader["Biology"].ToString();
                    grades.textBlockEnglish.Text = reader["English"].ToString();
                    grades.textBlockWorldHistory.Text = reader["World_History"].ToString();


                }
                reader.Close();
                grades.StudentID = StudentID;
                grades.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                sqlCon.Close(); 
            } 
        }

        private void studentInformation_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = sqlConnectionString;
            try
            {

                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query
                string query1 = " SELECT Surname, FirstNames FROM Student WHERE StudentID = '" + StudentID + "'";
                MySqlCommand cmd1 = new MySqlCommand(query1, sqlCon);
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@StudentID", query1);
                cmd1.ExecuteNonQuery();
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                StudentInformation studentInformation = new StudentInformation();
                while (reader1.Read())
                {

                    studentInformation.textBlockLastNames.Text = reader1["Surname"].ToString();
                    studentInformation.textBlockFirstNames.Text = reader1["FirstNames"].ToString();
                }
                reader1.Close();
                string query2 = " SELECT Gender, Email, Telephone, ParentSurname, ParentFirstNames, ParentPhone FROM Student_Additional_Information WHERE StudentID = '" + StudentID + "'";
                MySqlCommand cmd2 = new MySqlCommand(query2, sqlCon);
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = query2;
                cmd2.Parameters.AddWithValue("@StudentID", query2);
                cmd2.ExecuteNonQuery();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    studentInformation.textBlockGender.Text = reader2["Gender"].ToString();
                    studentInformation.textBlockEmail.Text = reader2["Email"].ToString();
                    studentInformation.textBlockTelephoneNumber.Text = reader2["Telephone"].ToString();
                    studentInformation.textBlockParentLastName.Text = reader2["ParentSurname"].ToString();
                    studentInformation.textBlockParentFirstNames.Text = reader2["ParentFirstNames"].ToString();
                    studentInformation.textBlockParentTelephoneNumber.Text = reader2["ParentPhone"].ToString();
                }
                studentInformation.StudentID = StudentID;
                studentInformation.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
