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

        public void FillComboBox() //filling combobox with data
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

        private void ComboBox_DropDownClosed(object sender, EventArgs e) //adding logic for combobox(filling textboxes with data acording to PESEL)
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
                    string rozpWyroku = dr.GetDateTime(4).ToString();
                    string zakWyroku = dr.GetDateTime(5).ToString();
                    string stZagro = dr.GetInt32(12).ToString();
                    

                    txtimie.Text = imie;
                    txtnazwisko.Text = nazwisko;
                    txtPESEL.Text = PESEL;
                    txtRozpWyroku.Text = rozpWyroku;
                    txtZakWyroku.Text = zakWyroku;
                    txtThreatLevel.Text = stZagro;
                    
                }
                dr.Close();

                string query2 = "SELECT P.RodzajPrzestepstwa FROM Wiezniowie AS W JOIN Przestepstwa P ON P.ID = W.PrzestepstwaID  WHERE PESEL='" + DisPESEL.Text + "' ";
                SqlCommand command2 = new SqlCommand(query2, connection);
                dr = command2.ExecuteReader();

                while (dr.Read())
                {
                    string przestepstwo = dr.GetString(0);
                    txtConvictedFor.Text = przestepstwo;

                }

                dr.Close();

                string query3 = "SELECT C.TypCeli FROM Wiezniowie AS W JOIN Cele C ON C.ID = W.CeleID WHERE PESEL='" + DisPESEL.Text + "' ";
                SqlCommand command3 = new SqlCommand(query3, connection);
                dr = command3.ExecuteReader();

                while (dr.Read())
                {
                    string cela = dr.GetString(0);
                    txtCell.Text = cela;

                }

                dr.Close();
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
        private void btnAddPrisoner_Click(object sender, RoutedEventArgs e) //logic for addprisoner button
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2V1OQNV;Initial Catalog=ZakładKarny;Integrated Security=True");
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string query = "INSERT INTO Wiezniowie (Imie,Nazwisko,PESEL,RozpoczecieWyroku,PlanowaneZakonczenieWyroku,PrzestepstwaID,StopienZagrozeniaWiezniaID,CeleID) VALUES('" + this.txtimie.Text + "','" + this.txtnazwisko.Text + "','" + this.txtPESEL.Text + "','" + this.txtRozpWyroku.Text + "','" + this.txtZakWyroku.Text + "','" + this.txtConvictedFor.Text + "','" + this.txtThreatLevel.Text + "','" + this.txtCell.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Prisoner has been added");

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
