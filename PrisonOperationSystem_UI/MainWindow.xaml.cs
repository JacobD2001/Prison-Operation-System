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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrisonOperationSystem_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBox();
        }

        public void FillComboBox()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2V1OQNV;Initial Catalog=ZakładKarny;Integrated Security=True");
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string query = "SELECT PESEL FROM Wiezniowie";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DisPESEL.ItemsSource = table.DefaultView; //assaign datasource to the combobox using datatable
                DisPESEL.DisplayMemberPath = "PESEL"; //assaign display value to combobox control(ui)              
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

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2V1OQNV;Initial Catalog=ZakładKarny;Integrated Security=True");
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string query = "SELECT * FROM Wiezniowie WHERE PESEL='" + DisPESEL.Text + "' ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string imie = dr.GetString(1);
                    string nazwisko = dr.GetString(2);
                    string PESEL = dr.GetString(3);
                    string RozpWyroku = dr.GetDateTime(4).ToString();
                    string ZakWyroku = dr.GetDateTime(5).ToString();

                    txtimie.Text = imie;
                    txtnazwisko.Text = nazwisko;
                    txtPESEL.Text = PESEL;
                    txtRozpWyroku.Text = RozpWyroku;
                    txtZakWyroku.Text = ZakWyroku;
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
