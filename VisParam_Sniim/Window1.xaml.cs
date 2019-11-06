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
using VisParam_Sniim;

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

        private void Add3_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    SqlConnection con1 = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("dbo.InsertValue", con1);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@radius", (rand.NextDouble() * 0.00000060 + 0.0000309));
                    cmd.Parameters.AddWithValue("@dielectric_constant", (rand.NextDouble() * 0.015 + 20.08));
                    cmd.Parameters.AddWithValue("@theoretical_polarization", (rand.NextDouble() * 1.12E-15 + 7.92E-15));
                    cmd.Parameters.AddWithValue("@measured_speed", (rand.NextDouble() * 1.383E-05 + 1.22E-05));
                    cmd.Parameters.AddWithValue("@measured_polarization", (rand.NextDouble() * 0.15E-15 + 9.97E-15));
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
                        con1.Close();
                    }
                    MessageBox.Show("Значения успешно добавлены");
                }
            }
            catch (Exception idk) {
                MessageBox.Show(idk.Message);
            }
            
        }
    }

    
}
