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
using System.Configuration;
using System.Data.SqlClient;

namespace VisParam_Sniim
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string connectionString;
        

        public Window1()
        {
           
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        private void Window_Loaded1(object sender, RoutedEventArgs e)
        {
       
        }

        private void Add1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.InsertValue", con1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@radius", TextBox1.Text);
            cmd.Parameters.AddWithValue("@dielectric_constant", TextBox2.Text);
            cmd.Parameters.AddWithValue("@theoretical_polarization", TextBox3.Text);
            cmd.Parameters.AddWithValue("@measured_speed", TextBox4.Text);
            cmd.Parameters.AddWithValue("@measured_polarization", TextBox5.Text);
            cmd.Parameters.AddWithValue("@ID", "1");

            con1.Open();
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
                
            }
            con1.Close();

        }

        private void Add2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
