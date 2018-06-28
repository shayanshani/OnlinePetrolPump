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
	/// <summary>
	/// Strongly-typed collection for the TblClientAccount class.
	/// </summary>
    [Serializable]
	public partial class TblClientAccountCollection : ActiveList<TblClientAccount, TblClientAccountCollection>
	{	   
		public TblClientAccountCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblClientAccountCollection</returns>
		public TblClientAccountCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblClientAccount o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the tbl_ClientAccount table.
	/// </summary>
	[Serializable]
	public partial class TblClientAccount : ActiveRecord<TblClientAccount>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblClientAccount()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblClientAccount(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblClientAccount(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblClientAccount(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("tbl_ClientAccount", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSerialNo = new TableSchema.TableColumn(schema);
				colvarSerialNo.ColumnName = "SerialNo";
				colvarSerialNo.DataType = DbType.Int32;
				colvarSerialNo.MaxLength = 0;
				colvarSerialNo.AutoIncrement = true;
				colvarSerialNo.IsNullable = false;
				colvarSerialNo.IsPrimaryKey = true;
				colvarSerialNo.IsForeignKey = false;
				colvarSerialNo.IsReadOnly = false;
				colvarSerialNo.DefaultSetting = @"";
				colvarSerialNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSerialNo);
				
				TableSchema.TableColumn colvarClientid = new TableSchema.TableColumn(schema);
				colvarClientid.ColumnName = "Clientid";
				colvarClientid.DataType = DbType.Int32;
				colvarClientid.MaxLength = 0;
				colvarClientid.AutoIncrement = false;
				colvarClientid.IsNullable = true;
				colvarClientid.IsPrimaryKey = false;
				colvarClientid.IsForeignKey = false;
				colvarClientid.IsReadOnly = false;
				colvarClientid.DefaultSetting = @"";
				colvarClientid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientid);
				
				TableSchema.TableColumn colvarReciptNo = new TableSchema.TableColumn(schema);
				colvarReciptNo.ColumnName = "ReciptNo";
				colvarReciptNo.DataType = DbType.Int32;
				colvarReciptNo.MaxLength = 0;
				colvarReciptNo.AutoIncrement = false;
				colvarReciptNo.IsNullable = true;
				colvarReciptNo.IsPrimaryKey = false;
				colvarReciptNo.IsForeignKey = false;
				colvarReciptNo.IsReadOnly = false;
				colvarReciptNo.DefaultSetting = @"";
				colvarReciptNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReciptNo);
				
				TableSchema.TableColumn colvarDateX = new TableSchema.TableColumn(schema);
				colvarDateX.ColumnName = "Date";
				colvarDateX.DataType = DbType.DateTime;
				colvarDateX.MaxLength = 0;
				colvarDateX.AutoIncrement = false;
				colvarDateX.IsNullable = true;
				colvarDateX.IsPrimaryKey = false;
				colvarDateX.IsForeignKey = false;
				colvarDateX.IsReadOnly = false;
				colvarDateX.DefaultSetting = @"";
				colvarDateX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateX);
				
				TableSchema.TableColumn colvarVehicleNo = new TableSchema.TableColumn(schema);
				colvarVehicleNo.ColumnName = "VehicleNo";
				colvarVehicleNo.DataType = DbType.AnsiString;
				colvarVehicleNo.MaxLength = 50;
				colvarVehicleNo.AutoIncrement = false;
				colvarVehicleNo.IsNullable = true;
				colvarVehicleNo.IsPrimaryKey = false;
				colvarVehicleNo.IsForeignKey = false;
				colvarVehicleNo.IsReadOnly = false;
				colvarVehicleNo.DefaultSetting = @"";
				colvarVehicleNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVehicleNo);
				
				TableSchema.TableColumn colvarLiters = new TableSchema.TableColumn(schema);
				colvarLiters.ColumnName = "Liters";
				colvarLiters.DataType = DbType.Double;
				colvarLiters.MaxLength = 0;
				colvarLiters.AutoIncrement = false;
				colvarLiters.IsNullable = true;
				colvarLiters.IsPrimaryKey = false;
				colvarLiters.IsForeignKey = false;
				colvarLiters.IsReadOnly = false;
				colvarLiters.DefaultSetting = @"";
				colvarLiters.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLiters);
				
				TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
				colvarRate.ColumnName = "Rate";
				colvarRate.DataType = DbType.Currency;
				colvarRate.MaxLength = 0;
				colvarRate.AutoIncrement = false;
				colvarRate.IsNullable = true;
				colvarRate.IsPrimaryKey = false;
				colvarRate.IsForeignKey = false;
				colvarRate.IsReadOnly = false;
				colvarRate.DefaultSetting = @"";
				colvarRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRate);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "Amount";
				colvarAmount.DataType = DbType.Currency;
				colvarAmount.MaxLength = 0;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = true;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				colvarAmount.DefaultSetting = @"";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
				TableSchema.TableColumn colvarReceived = new TableSchema.TableColumn(schema);
				colvarReceived.ColumnName = "Received";
				colvarReceived.DataType = DbType.Currency;
				colvarReceived.MaxLength = 0;
				colvarReceived.AutoIncrement = false;
				colvarReceived.IsNullable = true;
				colvarReceived.IsPrimaryKey = false;
				colvarReceived.IsForeignKey = false;
				colvarReceived.IsReadOnly = false;
				colvarReceived.DefaultSetting = @"";
				colvarReceived.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReceived);
				
				TableSchema.TableColumn colvarDsicount = new TableSchema.TableColumn(schema);
				colvarDsicount.ColumnName = "Dsicount";
				colvarDsicount.DataType = DbType.Currency;
				colvarDsicount.MaxLength = 0;
				colvarDsicount.AutoIncrement = false;
				colvarDsicount.IsNullable = true;
				colvarDsicount.IsPrimaryKey = false;
				colvarDsicount.IsForeignKey = false;
				colvarDsicount.IsReadOnly = false;
				colvarDsicount.DefaultSetting = @"";
				colvarDsicount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDsicount);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = -1;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarFid = new TableSchema.TableColumn(schema);
				colvarFid.ColumnName = "FID";
				colvarFid.DataType = DbType.Int32;
				colvarFid.MaxLength = 0;
				colvarFid.AutoIncrement = false;
				colvarFid.IsNullable = true;
				colvarFid.IsPrimaryKey = false;
				colvarFid.IsForeignKey = false;
				colvarFid.IsReadOnly = false;
				colvarFid.DefaultSetting = @"";
				colvarFid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFid);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_ClientAccount",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SerialNo")]
		[Bindable(true)]
		public int SerialNo 
		{
			get { return GetColumnValue<int>(Columns.SerialNo); }
			set { SetColumnValue(Columns.SerialNo, value); }
		}
		  
		[XmlAttribute("Clientid")]
		[Bindable(true)]
		public int? Clientid 
		{
			get { return GetColumnValue<int?>(Columns.Clientid); }
			set { SetColumnValue(Columns.Clientid, value); }
		}
		  
		[XmlAttribute("ReciptNo")]
		[Bindable(true)]
		public int? ReciptNo 
		{
			get { return GetColumnValue<int?>(Columns.ReciptNo); }
			set { SetColumnValue(Columns.ReciptNo, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("VehicleNo")]
		[Bindable(true)]
		public string VehicleNo 
		{
			get { return GetColumnValue<string>(Columns.VehicleNo); }
			set { SetColumnValue(Columns.VehicleNo, value); }
		}
		  
		[XmlAttribute("Liters")]
		[Bindable(true)]
		public double? Liters 
		{
			get { return GetColumnValue<double?>(Columns.Liters); }
			set { SetColumnValue(Columns.Liters, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public decimal? Rate 
		{
			get { return GetColumnValue<decimal?>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public decimal? Amount 
		{
			get { return GetColumnValue<decimal?>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("Received")]
		[Bindable(true)]
		public decimal? Received 
		{
			get { return GetColumnValue<decimal?>(Columns.Received); }
			set { SetColumnValue(Columns.Received, value); }
		}
		  
		[XmlAttribute("Dsicount")]
		[Bindable(true)]
		public decimal? Dsicount 
		{
			get { return GetColumnValue<decimal?>(Columns.Dsicount); }
			set { SetColumnValue(Columns.Dsicount, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("Fid")]
		[Bindable(true)]
		public int? Fid 
		{
			get { return GetColumnValue<int?>(Columns.Fid); }
			set { SetColumnValue(Columns.Fid, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varClientid,int? varReciptNo,DateTime? varDateX,string varVehicleNo,double? varLiters,decimal? varRate,decimal? varAmount,decimal? varReceived,decimal? varDsicount,string varDescription,int? varFid)
		{
			TblClientAccount item = new TblClientAccount();
			
			item.Clientid = varClientid;
			
			item.ReciptNo = varReciptNo;
			
			item.DateX = varDateX;
			
			item.VehicleNo = varVehicleNo;
			
			item.Liters = varLiters;
			
			item.Rate = varRate;
			
			item.Amount = varAmount;
			
			item.Received = varReceived;
			
			item.Dsicount = varDsicount;
			
			item.Description = varDescription;
			
			item.Fid = varFid;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSerialNo,int? varClientid,int? varReciptNo,DateTime? varDateX,string varVehicleNo,double? varLiters,decimal? varRate,decimal? varAmount,decimal? varReceived,decimal? varDsicount,string varDescription,int? varFid)
		{
			TblClientAccount item = new TblClientAccount();
			
				item.SerialNo = varSerialNo;
			
				item.Clientid = varClientid;
			
				item.ReciptNo = varReciptNo;
			
				item.DateX = varDateX;
			
				item.VehicleNo = varVehicleNo;
			
				item.Liters = varLiters;
			
				item.Rate = varRate;
			
				item.Amount = varAmount;
			
				item.Received = varReceived;
			
				item.Dsicount = varDsicount;
			
				item.Description = varDescription;
			
				item.Fid = varFid;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SerialNoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClientidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ReciptNoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn VehicleNoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn LitersColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ReceivedColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DsicountColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FidColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SerialNo = @"SerialNo";
			 public static string Clientid = @"Clientid";
			 public static string ReciptNo = @"ReciptNo";
			 public static string DateX = @"Date";
			 public static string VehicleNo = @"VehicleNo";
			 public static string Liters = @"Liters";
			 public static string Rate = @"Rate";
			 public static string Amount = @"Amount";
			 public static string Received = @"Received";
			 public static string Dsicount = @"Dsicount";
			 public static string Description = @"Description";
			 public static string Fid = @"FID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
