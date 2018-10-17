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
using System.Data;
using System.Data.SqlClient;
namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet _Return;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(txtUserName.Text + Environment.NewLine + txtAddress.Text + Environment.NewLine + dtpDOB.Text);            

        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection MainConn = new SqlConnection();
            SqlCommandBuilder cmdBuilder;
            MainConn.ConnectionString = @"data source=IBT-171102-01\SQLEXPRESS01;Initial Catalog=Uberiq_Pantai_Property;User ID=sa;Password=2good2btrue";
            MainConn.Open();
            SqlCommand MainCommand = new SqlCommand();
            MainCommand.CommandText = "select * from tblProperty";
            SqlDataAdapter MainAdpt = new SqlDataAdapter(MainCommand.CommandText,MainConn);
            cmdBuilder = new SqlCommandBuilder(MainAdpt);
            if (_Return !=null)
            {
                MainAdpt.Update(_Return,"Property");
            }            
            _Return = new DataSet();
            MainAdpt.Fill(_Return,"Property");            

            dgvView.ItemsSource = _Return.Tables[0].DefaultView;            
        }
    }
}
