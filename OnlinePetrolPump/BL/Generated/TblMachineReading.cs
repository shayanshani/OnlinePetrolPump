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
	/// Strongly-typed collection for the TblMachineReading class.
	/// </summary>
    [Serializable]
	public partial class TblMachineReadingCollection : ActiveList<TblMachineReading, TblMachineReadingCollection>
	{	   
		public TblMachineReadingCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblMachineReadingCollection</returns>
		public TblMachineReadingCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblMachineReading o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_MachineReading table.
	/// </summary>
	[Serializable]
	public partial class TblMachineReading : ActiveRecord<TblMachineReading>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblMachineReading()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblMachineReading(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblMachineReading(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblMachineReading(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_MachineReading", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarReadingID = new TableSchema.TableColumn(schema);
				colvarReadingID.ColumnName = "ReadingID";
				colvarReadingID.DataType = DbType.Int32;
				colvarReadingID.MaxLength = 0;
				colvarReadingID.AutoIncrement = true;
				colvarReadingID.IsNullable = false;
				colvarReadingID.IsPrimaryKey = true;
				colvarReadingID.IsForeignKey = false;
				colvarReadingID.IsReadOnly = false;
				colvarReadingID.DefaultSetting = @"";
				colvarReadingID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReadingID);
				
				TableSchema.TableColumn colvarMachineID = new TableSchema.TableColumn(schema);
				colvarMachineID.ColumnName = "MachineID";
				colvarMachineID.DataType = DbType.Int32;
				colvarMachineID.MaxLength = 0;
				colvarMachineID.AutoIncrement = false;
				colvarMachineID.IsNullable = true;
				colvarMachineID.IsPrimaryKey = false;
				colvarMachineID.IsForeignKey = false;
				colvarMachineID.IsReadOnly = false;
				colvarMachineID.DefaultSetting = @"";
				colvarMachineID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMachineID);
				
				TableSchema.TableColumn colvarPreviousReading = new TableSchema.TableColumn(schema);
				colvarPreviousReading.ColumnName = "PreviousReading";
				colvarPreviousReading.DataType = DbType.Decimal;
				colvarPreviousReading.MaxLength = 0;
				colvarPreviousReading.AutoIncrement = false;
				colvarPreviousReading.IsNullable = true;
				colvarPreviousReading.IsPrimaryKey = false;
				colvarPreviousReading.IsForeignKey = false;
				colvarPreviousReading.IsReadOnly = false;
				colvarPreviousReading.DefaultSetting = @"";
				colvarPreviousReading.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreviousReading);
				
				TableSchema.TableColumn colvarCurrentReading = new TableSchema.TableColumn(schema);
				colvarCurrentReading.ColumnName = "CurrentReading";
				colvarCurrentReading.DataType = DbType.Decimal;
				colvarCurrentReading.MaxLength = 0;
				colvarCurrentReading.AutoIncrement = false;
				colvarCurrentReading.IsNullable = true;
				colvarCurrentReading.IsPrimaryKey = false;
				colvarCurrentReading.IsForeignKey = false;
				colvarCurrentReading.IsReadOnly = false;
				colvarCurrentReading.DefaultSetting = @"";
				colvarCurrentReading.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrentReading);
				
				TableSchema.TableColumn colvarDateX = new TableSchema.TableColumn(schema);
				colvarDateX.ColumnName = "Date";
				colvarDateX.DataType = DbType.AnsiString;
				colvarDateX.MaxLength = 0;
				colvarDateX.AutoIncrement = false;
				colvarDateX.IsNullable = true;
				colvarDateX.IsPrimaryKey = false;
				colvarDateX.IsForeignKey = false;
				colvarDateX.IsReadOnly = false;
				colvarDateX.DefaultSetting = @"";
				colvarDateX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateX);
				
				TableSchema.TableColumn colvarChangeDate = new TableSchema.TableColumn(schema);
				colvarChangeDate.ColumnName = "ChangeDate";
				colvarChangeDate.DataType = DbType.AnsiString;
				colvarChangeDate.MaxLength = 0;
				colvarChangeDate.AutoIncrement = false;
				colvarChangeDate.IsNullable = true;
				colvarChangeDate.IsPrimaryKey = false;
				colvarChangeDate.IsForeignKey = false;
				colvarChangeDate.IsReadOnly = false;
				colvarChangeDate.DefaultSetting = @"";
				colvarChangeDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChangeDate);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "isActive";
				colvarIsActive.DataType = DbType.Boolean;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = true;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
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
				
				TableSchema.TableColumn colvarTestLiter = new TableSchema.TableColumn(schema);
				colvarTestLiter.ColumnName = "TestLiter";
				colvarTestLiter.DataType = DbType.Decimal;
				colvarTestLiter.MaxLength = 0;
				colvarTestLiter.AutoIncrement = false;
				colvarTestLiter.IsNullable = true;
				colvarTestLiter.IsPrimaryKey = false;
				colvarTestLiter.IsForeignKey = false;
				colvarTestLiter.IsReadOnly = false;
				colvarTestLiter.DefaultSetting = @"";
				colvarTestLiter.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTestLiter);
				
				TableSchema.TableColumn colvarNozleID = new TableSchema.TableColumn(schema);
				colvarNozleID.ColumnName = "NozleID";
				colvarNozleID.DataType = DbType.Int32;
				colvarNozleID.MaxLength = 0;
				colvarNozleID.AutoIncrement = false;
				colvarNozleID.IsNullable = true;
				colvarNozleID.IsPrimaryKey = false;
				colvarNozleID.IsForeignKey = false;
				colvarNozleID.IsReadOnly = false;
				colvarNozleID.DefaultSetting = @"";
				colvarNozleID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNozleID);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_MachineReading",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ReadingID")]
		[Bindable(true)]
		public int ReadingID 
		{
			get { return GetColumnValue<int>(Columns.ReadingID); }
			set { SetColumnValue(Columns.ReadingID, value); }
		}
		  
		[XmlAttribute("MachineID")]
		[Bindable(true)]
		public int? MachineID 
		{
			get { return GetColumnValue<int?>(Columns.MachineID); }
			set { SetColumnValue(Columns.MachineID, value); }
		}
		  
		[XmlAttribute("PreviousReading")]
		[Bindable(true)]
		public decimal? PreviousReading 
		{
			get { return GetColumnValue<decimal?>(Columns.PreviousReading); }
			set { SetColumnValue(Columns.PreviousReading, value); }
		}
		  
		[XmlAttribute("CurrentReading")]
		[Bindable(true)]
		public decimal? CurrentReading 
		{
			get { return GetColumnValue<decimal?>(Columns.CurrentReading); }
			set { SetColumnValue(Columns.CurrentReading, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public string DateX 
		{
			get { return GetColumnValue<string>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("ChangeDate")]
		[Bindable(true)]
		public string ChangeDate 
		{
			get { return GetColumnValue<string>(Columns.ChangeDate); }
			set { SetColumnValue(Columns.ChangeDate, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		  
		[XmlAttribute("CategoryID")]
		[Bindable(true)]
		public int? CategoryID 
		{
			get { return GetColumnValue<int?>(Columns.CategoryID); }
			set { SetColumnValue(Columns.CategoryID, value); }
		}
		  
		[XmlAttribute("TestLiter")]
		[Bindable(true)]
		public decimal? TestLiter 
		{
			get { return GetColumnValue<decimal?>(Columns.TestLiter); }
			set { SetColumnValue(Columns.TestLiter, value); }
		}
		  
		[XmlAttribute("NozleID")]
		[Bindable(true)]
		public int? NozleID 
		{
			get { return GetColumnValue<int?>(Columns.NozleID); }
			set { SetColumnValue(Columns.NozleID, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public decimal? Rate 
		{
			get { return GetColumnValue<decimal?>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varMachineID,decimal? varPreviousReading,decimal? varCurrentReading,string varDateX,string varChangeDate,bool? varIsActive,int? varCategoryID,decimal? varTestLiter,int? varNozleID,decimal? varRate)
		{
			TblMachineReading item = new TblMachineReading();
			
			item.MachineID = varMachineID;
			
			item.PreviousReading = varPreviousReading;
			
			item.CurrentReading = varCurrentReading;
			
			item.DateX = varDateX;
			
			item.ChangeDate = varChangeDate;
			
			item.IsActive = varIsActive;
			
			item.CategoryID = varCategoryID;
			
			item.TestLiter = varTestLiter;
			
			item.NozleID = varNozleID;
			
			item.Rate = varRate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varReadingID,int? varMachineID,decimal? varPreviousReading,decimal? varCurrentReading,string varDateX,string varChangeDate,bool? varIsActive,int? varCategoryID,decimal? varTestLiter,int? varNozleID,decimal? varRate)
		{
			TblMachineReading item = new TblMachineReading();
			
				item.ReadingID = varReadingID;
			
				item.MachineID = varMachineID;
			
				item.PreviousReading = varPreviousReading;
			
				item.CurrentReading = varCurrentReading;
			
				item.DateX = varDateX;
			
				item.ChangeDate = varChangeDate;
			
				item.IsActive = varIsActive;
			
				item.CategoryID = varCategoryID;
			
				item.TestLiter = varTestLiter;
			
				item.NozleID = varNozleID;
			
				item.Rate = varRate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ReadingIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn MachineIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PreviousReadingColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrentReadingColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ChangeDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TestLiterColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn NozleIDColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ReadingID = @"ReadingID";
			 public static string MachineID = @"MachineID";
			 public static string PreviousReading = @"PreviousReading";
			 public static string CurrentReading = @"CurrentReading";
			 public static string DateX = @"Date";
			 public static string ChangeDate = @"ChangeDate";
			 public static string IsActive = @"isActive";
			 public static string CategoryID = @"CategoryID";
			 public static string TestLiter = @"TestLiter";
			 public static string NozleID = @"NozleID";
			 public static string Rate = @"Rate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
