/// <summary>
/// Interaction Properties for shipment management
/// Created By: Jharashree Pattnaik
/// Created On: 7-3-2025
/// </summary>
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
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web;
using ShipmentManagement.ViewModels;
using System.Configuration;


namespace ShipmentManagement
{
    /// <summary>
    /// Interaction logic for ShipmentManagement.xaml
    /// </summary>
    public partial class ShipmentManagement : Window
    {
        public ShipmentManagement()
        {
            InitializeComponent();
        }
        ShimentManagementViewModel objshipment;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ShipmentManagement", con))
                {
                    try
                    {
                        con.Open();
                        // create an instance of the class.
                        objshipment = new ShimentManagementViewModel();
                        objshipment.StrAction = "A";
                        objshipment.strShipmenttype = Convert.ToString(ShipmentTypeComboBox.SelectedItem);
                        objshipment.strOrigin = Convert.ToString(txtOrigin.Text);
                        objshipment.strDestination = Convert.ToString(txtDestination.Text);
                        objshipment.strDatetime = Convert.ToDateTime(txtDate.Text);
                        objshipment.intStatus = Convert.ToInt32(StatusComboBox.SelectedValue);
                        objshipment.strOutput = "1"; //Data saved successfully
                        con.Close();
                    }
                    catch (Exception ex) //Exception handled
                    {

                        throw new ArgumentOutOfRangeException(
                        "Error Occured.", ex);
                        throw;
                    }
                    finally
                    {
                        objshipment = null;
                    }
          
                }
            }
        }
    }
}
    

