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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace VisParam_Sniim
{
       public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable VisParam;

        public MainWindow()
        {
            InitializeComponent();
            // получаем строку подключения из app.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Viscoelastic_param_table";
            VisParam = new DataTable();
            SqlConnection connection = null;

            // conn.Open();
            // SqlDataAdapter rdr = new SqlDataAdapter("Select * from Employees", conn);
            // SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(command);
            // SqlCommand cmd = new SqlCommand("delete from Viscoelastic_param_table where id=@id", command.SelectCommand.connection);
            // cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            // cmd.Parameters["id"].SourceVersion = DataRowVersion.Original;
            // cmd.Parameters["id"].SourceColumn = "id";
            // rdr.DeleteCommand = cmd;
            // rdr.Fill(dataset, "mydata")
            // Console.WriteLine(cmdBuilder.GetDeleteCommand().CommandText);
            // foreach (DataRow row in dataset.Tables.Rows)
            // {
            // row.Delete();
            // }
            //           UpdateDB();
            //        

            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                adapter.InsertCommand = new SqlCommand("InsertValue", connection);
                adapter.DeleteCommand = new SqlCommand("DELETE * FROM Viscoelastic_param_table WHERE id = @id", connection);
                connection.Open();
                adapter.Fill(VisParam);
                ValuesGrid.ItemsSource = VisParam.DefaultView;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(VisParam);
            VisParam.Clear();
            adapter.Fill(VisParam);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // SqlDataAdapter rdr = new SqlDataAdapter("Select * from Employees", conn);
            SqlConnection con1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("delete from Viscoelastic_param_table where id=@id", con1);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            cmd.Parameters["id"].SourceVersion = DataRowVersion.Original;
            cmd.Parameters["id"].SourceColumn = "id";

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
            UpdateDB();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }
    }
}

