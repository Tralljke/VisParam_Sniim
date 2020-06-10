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
using System.Configuration;
using System.Data.SqlClient;
using VisParam_Sniim;

namespace VisParam_Sniim
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string connectionString;

        public Window2()
        {
            InitializeComponent();
            this.DataContext = new ParamViewModel();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            IdTextBox.Text = MainWindow.test.id.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            RadiusTextBox.Text = MainWindow.test.radius.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")); ;
            TPolarizationTextBox.Text = MainWindow.test.theoreticalPolarization.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            SpeedTextBox.Text = MainWindow.test.measuredSpeed.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            MPolarizationTextBox.Text = MainWindow.test.measuredPolarization.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }

        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditParam_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);
            SqlCommand EditValueCommand = new SqlCommand("Update [ViscoelasticParamTable] SET [radius] = @radius, [theoreticalPolarization] = @theoreticalPolarization " +
                ", [measuredSpeed] = @measuredSpeed, [measuredPolarization] = @measuredPolarization WHERE ID = @ID", dbConnection);
            EditValueCommand.Parameters.AddWithValue("@ID", IdTextBox.Text);
            EditValueCommand.Parameters.AddWithValue("@radius", RadiusTextBox.Text);
            EditValueCommand.Parameters.AddWithValue("@theoreticalPolarization", TPolarizationTextBox.Text);
            EditValueCommand.Parameters.AddWithValue("@measuredSpeed", SpeedTextBox.Text);
            EditValueCommand.Parameters.AddWithValue("@measuredPolarization", MPolarizationTextBox.Text);

            dbConnection.Open();
            try
            {
                EditValueCommand.ExecuteNonQuery();
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

       
    }
}
