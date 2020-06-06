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
            this.DataContext = new ParamViewModel();
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
                MessageBox.Show("Значения успешно добавлены");
            }

            dbConnection.Close();

        }

        private void CloseWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }

    
}
