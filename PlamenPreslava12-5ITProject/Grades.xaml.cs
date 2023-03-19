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
    /// Interaction logic for Grades.xaml
    /// </summary>
    public partial class Grades : Window
    {
        public Grades()
        {
            InitializeComponent();
        }

        public string StudentID;
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.StudentID = StudentID;
            homePage.Show();
            this.Close();
        }
    }
}
