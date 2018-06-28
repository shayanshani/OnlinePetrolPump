using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;
namespace OnlinePetrolPump.BL
{


    public partial class TblClient
    {

        public static DataTable GetAccountDetails(int ClientID)
        {

            return SPs.SpGetClientAccountDetials(ClientID).GetDataSet().Tables[0];
        }
        public static DataTable GetInvoieDetails(int ClientID, string fromDate, string toDate, string VehicleNo)
        {

            return SPs.SpGetClientInvoice(ClientID, fromDate, toDate,VehicleNo).GetDataSet().Tables[0];
        }
        public static DataTable GetVehicleBill(int ClientID, string fromDate, string toDate)
        {

            return SPs.SpGetVehicleBill(ClientID, fromDate, toDate).GetDataSet().Tables[0];
        }

        public static DataTable GetClients()
        {
            return SPs.SpRptGetClients().GetDataSet().Tables[0];
        }

        public static DataTable GetAccountDetails(int ClientID, string fromDate, string toDate)
        {
            return SPs.SpGetClientDetails(ClientID, fromDate, toDate).GetDataSet().Tables[0];
        }

        public static DataTable GetMonthlyStatement(int ClientID, string fromDate, string toDate)
        {
            return SPs.SpClientMonthlyStatment(ClientID, fromDate, toDate).GetDataSet().Tables[0];
        }

    }
}
