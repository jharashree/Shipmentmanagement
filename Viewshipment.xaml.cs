/// <summary>
/// View details for shipment management
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
using System.Collections.ObjectModel;

namespace ShipmentManagement
{
    /// <summary>
    /// Interaction logic for Viewshipment.xaml
    /// </summary>
    public partial class Viewshipment : Window
    {
        ShimentManagementViewModel objshipment = new ShimentManagementViewModel();
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public Viewshipment()
        {
            //InitializeComponent();
         

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ShipmentManagement", con))
                {
                    try
                    {
                        ObservableCollection<ShimentManagementViewModel> _shipmentCollection =
                        new ObservableCollection<ShimentManagementViewModel>();


                        _shipmentCollection.Add(new ShimentManagementViewModel
                        {
                            StrAction = "V",
                            strShipmenttype = objshipment.strShipmenttype,
                            strOrigin = objshipment.strOrigin,
                            strDestination = objshipment.strDestination,
                            intStatus = objshipment.intStatus

                        });


                        Viewshipment em = new Viewshipment();
                        this.DataContext = em;


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


      

