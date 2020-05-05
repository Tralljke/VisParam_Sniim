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
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string SelectSql = "SELECT * FROM ViscoelasticParamTable";
            VisParam = new DataTable();
            SqlConnection dbConnection = null;
              
            try
            {
                dbConnection = new SqlConnection(connectionString);
                SqlCommand SelectCommand = new SqlCommand(SelectSql, dbConnection);
                adapter = new SqlDataAdapter(SelectCommand)
                {
                    InsertCommand = new SqlCommand("InsertValue", dbConnection),
                    DeleteCommand = new SqlCommand("DELETE * FROM ViscoelasticParamTable WHERE ID = @ID", dbConnection)
                };
                dbConnection.Open();
                adapter.Fill(VisParam);
                ValuesGrid.ItemsSource = VisParam.DefaultView; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dbConnection != null)
                    dbConnection.Close();
            }
            //string A = "";
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    A += dataGridView1.Rows[i].Cells[2].Value.ToString();
            //foreach (DataColumn column in )//
            string s = Convert.ToString(VisParam.Rows[0][2]);
            MessageBox.Show(s);
        }

        public void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            VisParam.Clear();
            adapter.Fill(VisParam);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = ValuesGrid.SelectedItem as DataRowView;
            SqlConnection dbConnection = new SqlConnection(connectionString);
            SqlCommand deleteCommand = new SqlCommand("delete from ViscoelasticParamTable where ID=@ID", dbConnection);
            deleteCommand.Parameters.Add(new SqlParameter("@ID", rowview.Row[0].ToString()));

            dbConnection.Open();
            try
                {
                    deleteCommand.ExecuteNonQuery();
                }
            catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            finally
                {
                    dbConnection.Close();
                    UpdateDB();
                }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 AddParamWin = new Window1();
            AddParamWin.Show();
        }

    }
}

