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
        public static List<Erythrocyte> DataList = new List<Erythrocyte>();
        public static VariableParams test = new VariableParams();

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
           }

           
           
        }

        private void UpdateDB()
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
            if (ValuesGrid.SelectedItems.Count > 0)
            {
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
            if (rowview == null)
                MessageBox.Show("Сначала выберите элемент таблицы который хотите удалить");
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

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView rowview = ValuesGrid.SelectedItem as DataRowView;
            if (ValuesGrid.SelectedItems.Count > 0)
            {
                test.id = Convert.ToInt32(rowview.Row[0]);
                test.radius = Convert.ToDouble(rowview.Row[1]);
                test.theoreticalPolarization = Convert.ToDouble(rowview.Row[2]);
                test.measuredSpeed = Convert.ToDouble(rowview.Row[3]);
                test.measuredPolarization = Convert.ToDouble(rowview.Row[4]);
                Window2 EditParamWin = new Window2();
                EditParamWin.Show();
            }
            if (rowview == null)
                MessageBox.Show("Сначала выберите элемент таблицы который хотите изменить");

        }

        private void GetStatisticalParam_Click(object sender, RoutedEventArgs e)
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
                    DataList.Add(new Erythrocyte(Convert.ToDouble(VisParam.Rows[i][1]), Convert.ToDouble(VisParam.Rows[i][3]), Convert.ToDouble(VisParam.Rows[i][4])));
                }

                List<Erythrocyte> idk = new List<Erythrocyte>();
                if (idk.Count == 0)
                {
                    idk.Add(StatisticalProcessing.GetAverage(DataList));
                    idk.Add(StatisticalProcessing.GetDispersion(DataList));
                    idk.Add(StatisticalProcessing.GetVarCoef(DataList));
                    DataList.Clear();
                }
                StatisticalParamsGrid.ItemsSource = idk;
               
            }
        }
    }
}

