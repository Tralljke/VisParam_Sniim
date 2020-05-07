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
        public DataTable VisParam;
        List<double> list = new List<double>();
        List<StatisticalProcessing.MyParams> list1 = new List<StatisticalProcessing.MyParams>();
        
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
            {
                if (VisParam.Rows.Count == 0)
                {
                    list.Add(0);
                    MessageBox.Show("Таблица пуста");
                }

                else
                {
                    for (int i = 0; i < VisParam.Rows.Count; i++)
                    {
                        list.Add(Convert.ToDouble(VisParam.Rows[i][0]));
                    }
                }
            }
            StatisticalProcessing.GetAverage(list);
            AddParams();
            AveragesGrid.ItemsSource = list1;
            //StatisticalProcessing.ShowA();
        }

        public void AddParams()
        {
            list1.Add(new StatisticalProcessing.MyParams(Ave: StatisticalProcessing.average, Dispersion: StatisticalProcessing.Z, Kef: StatisticalProcessing.C));
            list1.Add(new StatisticalProcessing.MyParams(Ave: StatisticalProcessing.average, Dispersion: StatisticalProcessing.Z, Kef: StatisticalProcessing.C));
        }


        public void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            VisParam.Clear();
            adapter.Fill(VisParam);
            for (int i = 0; i < VisParam.Rows.Count; i++)
                list.Add(Convert.ToDouble(VisParam.Rows[i][0]));
            StatisticalProcessing.GetAverage(list);
            StatisticalProcessing.ShowA();
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

        private void CloseWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

