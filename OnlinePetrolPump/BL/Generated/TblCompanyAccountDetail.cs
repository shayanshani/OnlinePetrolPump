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
	/// Strongly-typed collection for the TblCompanyAccountDetail class.
	/// </summary>
    [Serializable]
	public partial class TblCompanyAccountDetailCollection : ActiveList<TblCompanyAccountDetail, TblCompanyAccountDetailCollection>
	{	   
		public TblCompanyAccountDetailCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblCompanyAccountDetailCollection</returns>
		public TblCompanyAccountDetailCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblCompanyAccountDetail o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_CompanyAccountDetails table.
	/// </summary>
	[Serializable]
	public partial class TblCompanyAccountDetail : ActiveRecord<TblCompanyAccountDetail>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblCompanyAccountDetail()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblCompanyAccountDetail(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblCompanyAccountDetail(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblCompanyAccountDetail(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_CompanyAccountDetails", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
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
				
				TableSchema.TableColumn colvarCompanyid = new TableSchema.TableColumn(schema);
				colvarCompanyid.ColumnName = "Companyid";
				colvarCompanyid.DataType = DbType.Int32;
				colvarCompanyid.MaxLength = 0;
				colvarCompanyid.AutoIncrement = false;
				colvarCompanyid.IsNullable = true;
				colvarCompanyid.IsPrimaryKey = false;
				colvarCompanyid.IsForeignKey = false;
				colvarCompanyid.IsReadOnly = false;
				colvarCompanyid.DefaultSetting = @"";
				colvarCompanyid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompanyid);
				
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
				
				TableSchema.TableColumn colvarVehcleNo = new TableSchema.TableColumn(schema);
				colvarVehcleNo.ColumnName = "VehcleNo";
				colvarVehcleNo.DataType = DbType.AnsiString;
				colvarVehcleNo.MaxLength = -1;
				colvarVehcleNo.AutoIncrement = false;
				colvarVehcleNo.IsNullable = true;
				colvarVehcleNo.IsPrimaryKey = false;
				colvarVehcleNo.IsForeignKey = false;
				colvarVehcleNo.IsReadOnly = false;
				colvarVehcleNo.DefaultSetting = @"";
				colvarVehcleNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVehcleNo);
				
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
				
				TableSchema.TableColumn colvarOtherExpense = new TableSchema.TableColumn(schema);
				colvarOtherExpense.ColumnName = "OtherExpense";
				colvarOtherExpense.DataType = DbType.Currency;
				colvarOtherExpense.MaxLength = 0;
				colvarOtherExpense.AutoIncrement = false;
				colvarOtherExpense.IsNullable = true;
				colvarOtherExpense.IsPrimaryKey = false;
				colvarOtherExpense.IsForeignKey = false;
				colvarOtherExpense.IsReadOnly = false;
				colvarOtherExpense.DefaultSetting = @"";
				colvarOtherExpense.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtherExpense);
				
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
				
				TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
				colvarCategoryID.ColumnName = "CategoryID";
				colvarCategoryID.DataType = DbType.Int32;
				colvarCategoryID.MaxLength = 0;
				colvarCategoryID.AutoIncrement = false;
				colvarCategoryID.IsNullable = true;
				colvarCategoryID.IsPrimaryKey = false;
				colvarCategoryID.IsForeignKey = false;
				colvarCategoryID.IsReadOnly = false;
				colvarCategoryID.DefaultSetting = @"";
				colvarCategoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryID);
				
				TableSchema.TableColumn colvarProductid = new TableSchema.TableColumn(schema);
				colvarProductid.ColumnName = "Productid";
				colvarProductid.DataType = DbType.Int32;
				colvarProductid.MaxLength = 0;
				colvarProductid.AutoIncrement = false;
				colvarProductid.IsNullable = true;
				colvarProductid.IsPrimaryKey = false;
				colvarProductid.IsForeignKey = false;
				colvarProductid.IsReadOnly = false;
				colvarProductid.DefaultSetting = @"";
				colvarProductid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductid);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_CompanyAccountDetails",schema);
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
		  
		[XmlAttribute("Companyid")]
		[Bindable(true)]
		public int? Companyid 
		{
			get { return GetColumnValue<int?>(Columns.Companyid); }
			set { SetColumnValue(Columns.Companyid, value); }
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
		  
		[XmlAttribute("VehcleNo")]
		[Bindable(true)]
		public string VehcleNo 
		{
			get { return GetColumnValue<string>(Columns.VehcleNo); }
			set { SetColumnValue(Columns.VehcleNo, value); }
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
		  
		[XmlAttribute("OtherExpense")]
		[Bindable(true)]
		public decimal? OtherExpense 
		{
			get { return GetColumnValue<decimal?>(Columns.OtherExpense); }
			set { SetColumnValue(Columns.OtherExpense, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("CategoryID")]
		[Bindable(true)]
		public int? CategoryID 
		{
			get { return GetColumnValue<int?>(Columns.CategoryID); }
			set { SetColumnValue(Columns.CategoryID, value); }
		}
		  
		[XmlAttribute("Productid")]
		[Bindable(true)]
		public int? Productid 
		{
			get { return GetColumnValue<int?>(Columns.Productid); }
			set { SetColumnValue(Columns.Productid, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCompanyid,int? varReciptNo,DateTime? varDateX,string varVehcleNo,double? varLiters,decimal? varRate,decimal? varAmount,decimal? varReceived,decimal? varOtherExpense,string varDescription,int? varCategoryID,int? varProductid)
		{
			TblCompanyAccountDetail item = new TblCompanyAccountDetail();
			
			item.Companyid = varCompanyid;
			
			item.ReciptNo = varReciptNo;
			
			item.DateX = varDateX;
			
			item.VehcleNo = varVehcleNo;
			
			item.Liters = varLiters;
			
			item.Rate = varRate;
			
			item.Amount = varAmount;
			
			item.Received = varReceived;
			
			item.OtherExpense = varOtherExpense;
			
			item.Description = varDescription;
			
			item.CategoryID = varCategoryID;
			
			item.Productid = varProductid;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSerialNo,int? varCompanyid,int? varReciptNo,DateTime? varDateX,string varVehcleNo,double? varLiters,decimal? varRate,decimal? varAmount,decimal? varReceived,decimal? varOtherExpense,string varDescription,int? varCategoryID,int? varProductid)
		{
			TblCompanyAccountDetail item = new TblCompanyAccountDetail();
			
				item.SerialNo = varSerialNo;
			
				item.Companyid = varCompanyid;
			
				item.ReciptNo = varReciptNo;
			
				item.DateX = varDateX;
			
				item.VehcleNo = varVehcleNo;
			
				item.Liters = varLiters;
			
				item.Rate = varRate;
			
				item.Amount = varAmount;
			
				item.Received = varReceived;
			
				item.OtherExpense = varOtherExpense;
			
				item.Description = varDescription;
			
				item.CategoryID = varCategoryID;
			
				item.Productid = varProductid;
			
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
        
        
        
        public static TableSchema.TableColumn CompanyidColumn
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
        
        
        
        public static TableSchema.TableColumn VehcleNoColumn
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
        
        
        
        public static TableSchema.TableColumn OtherExpenseColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryIDColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductidColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SerialNo = @"SerialNo";
			 public static string Companyid = @"Companyid";
			 public static string ReciptNo = @"ReciptNo";
			 public static string DateX = @"Date";
			 public static string VehcleNo = @"VehcleNo";
			 public static string Liters = @"Liters";
			 public static string Rate = @"Rate";
			 public static string Amount = @"Amount";
			 public static string Received = @"Received";
			 public static string OtherExpense = @"OtherExpense";
			 public static string Description = @"Description";
			 public static string CategoryID = @"CategoryID";
			 public static string Productid = @"Productid";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
