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

        private void class_Click(object sender, RoutedEventArgs e)
        {
            var window = new Class();
            window.Show();
            this.Close();
        }

        private void grades_Click(object sender, RoutedEventArgs e)
        {
            var window = new Grades();
            window.Show();
            this.Close();
        }

        private void studentInformation_Click(object sender, RoutedEventArgs e)
        {
            var window = new StudentInformation();
            window.Show();
            this.Close();
        }
    }
}
