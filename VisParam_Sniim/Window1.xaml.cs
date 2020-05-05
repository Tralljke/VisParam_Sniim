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

        private void AddParam_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);
            SqlCommand InsertValueCommand = new SqlCommand("dbo.InsertValue", dbConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            InsertValueCommand.Parameters.AddWithValue("@radius", RadiusTextBox.Text);
            InsertValueCommand.Parameters.AddWithValue("@dielectricConstant", DConstantTextBox.Text);
            InsertValueCommand.Parameters.AddWithValue("@theoreticalPolarization", TPolarizationTextBox.Text);
            InsertValueCommand.Parameters.AddWithValue("@measuredSpeed", SpeedTextBox.Text);
            InsertValueCommand.Parameters.AddWithValue("@measuredPolarization", MPolarizationTextBox.Text);

            dbConnection.Open();
            try
            {
                InsertValueCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }

            dbConnection.Close();

        }

        private void CloseWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddRandomParam_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            try
            {
                // добавить i = 10 случайных значений в базу данных 
                // диапазон значений приближен к реальным
                for (int i = 0; i < 10; i++)
                {
                    SqlConnection dbConnection = new SqlConnection(connectionString);
                    SqlCommand InsertValueCommand = new SqlCommand("dbo.InsertValue", dbConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    InsertValueCommand.Parameters.AddWithValue("@radius", (rand.NextDouble() * 0.00000060 + 0.0000309));
                    InsertValueCommand.Parameters.AddWithValue("@dielectricConstant", (rand.NextDouble() * 0.015 + 20.08));
                    InsertValueCommand.Parameters.AddWithValue("@theoreticalPolarization", (rand.NextDouble() * 1.12E-15 + 7.92E-15));
                    InsertValueCommand.Parameters.AddWithValue("@measuredSpeed", (rand.NextDouble() * 1.383E-05 + 1.22E-05));
                    InsertValueCommand.Parameters.AddWithValue("@measuredPolarization", (rand.NextDouble() * 0.15E-15 + 9.97E-15));
                    dbConnection.Open();
                    try
                    {
                        InsertValueCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        dbConnection.Close();
                    }
                    
                }
                MessageBox.Show("Значения успешно добавлены");
            }
            catch (Exception idk) {
                MessageBox.Show(idk.Message);
            }
            
        }

        
    }

    
}
