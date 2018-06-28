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
    public partial class SPs
    {

        /// <summary>
        /// Creates an object wrapper for the sp_AdminLogin Procedure
        /// </summary>
        public static StoredProcedure SpAdminLogin(string UserName, string Password)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_AdminLogin", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@UserName", UserName, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@Password", Password, DbType.AnsiString, null, null);

            return sp;
        }

        public static StoredProcedure SpDynamicMachineReading(int? MachineID, int? NozleID, DateTime? DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_DynamicMachineReading", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@MachineID", MachineID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@NozleID", NozleID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@Date", DateX, DbType.DateTime, null, null);

            return sp;
        }

        public static StoredProcedure SpProfits(string DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Profits", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@Date", DateX, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_ClientMonthlyStatment Procedure
        /// </summary>
        public static StoredProcedure SpClientMonthlyStatment(int? ClientID, string DateFrom, string DateTo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_ClientMonthlyStatment", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@ClientID", ClientID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@DateFrom", DateFrom, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@DateTo", DateTo, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_DailyStatementReport Procedure
        /// </summary>
        public static StoredProcedure SpDailyStatementReport(string DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_DailyStatementReport", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@Date", DateX, DbType.AnsiString, null, null);

            return sp;
        }
        public static StoredProcedure SpSalePurchaseReport(string FromDate, string ToDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_SalePurchaseReport", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@DateFrom", FromDate, DbType.AnsiString, null, null);
            sp.Command.AddParameter("@DateTo", ToDate, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetClientAccountDetials Procedure
        /// </summary>
        public static StoredProcedure SpGetClientAccountDetials(int? ClientID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetClientAccountDetials", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@ClientID", ClientID, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetClientDetails Procedure
        /// </summary>
        public static StoredProcedure SpGetClientDetails(int? ClientID, string DateFrom, string DateTo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetClientDetails", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@ClientID", ClientID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@DateFrom", DateFrom, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@DateTo", DateTo, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetClientInvoice Procedure
        /// </summary>
        public static StoredProcedure SpGetClientInvoice(int? ClientID, string DateFrom, string DateTo, string VehicleNo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetClientInvoice", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@ClientID", ClientID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@DateFrom", DateFrom, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@DateTo", DateTo, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@VehicleNo", VehicleNo, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_getCompany Procedure
        /// </summary>
        public static StoredProcedure SpGetCompany()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_getCompany", DataService.GetInstance("OnlinePetrolPump"), "");

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetCompanyAccountDetials Procedure
        /// </summary>
        public static StoredProcedure SpGetCompanyAccountDetials(int? CompanyID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetCompanyAccountDetials", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@CompanyID", CompanyID, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetCompanyMonthlyStatment Procedure
        /// </summary>
        public static StoredProcedure SpGetCompanyMonthlyStatment(int? CompanyId, string DateFrom, string DateTo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetCompanyMonthlyStatment", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@CompanyId", CompanyId, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@DateFrom", DateFrom, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@DateTo", DateTo, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetExpenseReport Procedure
        /// </summary>
        public static StoredProcedure SpGetExpenseReport(int? HeadID, string FromDate, string ToDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetExpenseReport", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@HeadID", HeadID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@FromDate", FromDate, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@ToDate", ToDate, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetStockDetials Procedure
        /// </summary>
        public static StoredProcedure SpGetStockDetials(string fromDate, string toDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetStockDetials", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@fromDate", fromDate, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@toDate", toDate, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_GetVehicleBill Procedure
        /// </summary>
        public static StoredProcedure SpGetVehicleBill(int? ClientID, string DateFrom, string DateTo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetVehicleBill", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@ClientID", ClientID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@DateFrom", DateFrom, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@DateTo", DateTo, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_MachineReading Procedure
        /// </summary>
        public static StoredProcedure SpMachineReading(DateTime? DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_MachineReading", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@Date", DateX, DbType.DateTime, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_MachineReadingReport Procedure
        /// </summary>
        public static StoredProcedure SpMachineReadingReport(string DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_MachineReadingReport", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@Date", DateX, DbType.AnsiString, null, null);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_rptGetClients Procedure
        /// </summary>
        public static StoredProcedure SpRptGetClients()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_rptGetClients", DataService.GetInstance("OnlinePetrolPump"), "");

            return sp;
        }

        public static StoredProcedure SpRptGetCompany()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_rptGetCompany", DataService.GetInstance("OnlinePetrolPump"), "");

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the sp_StockInvoice Procedure
        /// </summary>
        public static StoredProcedure SpStockInvoice(string frmDate, string toDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_StockInvoice", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@frmDate", frmDate, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@toDate", toDate, DbType.AnsiString, null, null);

            return sp;
        }

        public static StoredProcedure SpTankDetails(string DateX, int? CategoryID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_TankDetails", DataService.GetInstance("OnlinePetrolPump"), "dbo");

            sp.Command.AddParameter("@Date", DateX, DbType.AnsiString, null, null);

            sp.Command.AddParameter("@CategoryID", CategoryID, DbType.Int32, 0, 10);

            return sp;
        }
    }

}
