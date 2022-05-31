using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PrisonOperationSystem_UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2V1OQNV;Initial Catalog=ZakładKarny;Integrated Security=True");
            try
            {
                if(connection.State == ConnectionState.Closed)
                    connection.Open();
                string query = "SELECT (1) FROM DaneLogowania WHERE Login=@Login AND Haslo=@Haslo";
                SqlCommand cmd = new SqlCommand(query, connection); //runs query on connected database
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Login", txtLogin.Text); //declare scalar variable
                cmd.Parameters.AddWithValue("@Haslo", txtHaslo.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                if (count == 1) //if it returns 1(meaning 1 of the rows in db) go to next window
                {
                    MainWindow Dashboard = new MainWindow();
                    Dashboard.Show();
                    this.Close();
                }
                else //else display this one
                {
                    MessageBox.Show("Login lub hasło jest niepoprawne!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
