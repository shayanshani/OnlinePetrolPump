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
	/// Strongly-typed collection for the TblClient class.
	/// </summary>
    [Serializable]
	public partial class TblClientCollection : ActiveList<TblClient, TblClientCollection>
	{	   
		public TblClientCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblClientCollection</returns>
		public TblClientCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblClient o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tbl_Client table.
	/// </summary>
	[Serializable]
	public partial class TblClient : ActiveRecord<TblClient>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblClient()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblClient(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblClient(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblClient(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tbl_Client", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarClientid = new TableSchema.TableColumn(schema);
				colvarClientid.ColumnName = "Clientid";
				colvarClientid.DataType = DbType.Int32;
				colvarClientid.MaxLength = 0;
				colvarClientid.AutoIncrement = true;
				colvarClientid.IsNullable = false;
				colvarClientid.IsPrimaryKey = true;
				colvarClientid.IsForeignKey = false;
				colvarClientid.IsReadOnly = false;
				colvarClientid.DefaultSetting = @"";
				colvarClientid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientid);
				
				TableSchema.TableColumn colvarClientName = new TableSchema.TableColumn(schema);
				colvarClientName.ColumnName = "ClientName";
				colvarClientName.DataType = DbType.AnsiString;
				colvarClientName.MaxLength = 50;
				colvarClientName.AutoIncrement = false;
				colvarClientName.IsNullable = true;
				colvarClientName.IsPrimaryKey = false;
				colvarClientName.IsForeignKey = false;
				colvarClientName.IsReadOnly = false;
				colvarClientName.DefaultSetting = @"";
				colvarClientName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientName);
				
				TableSchema.TableColumn colvarContact = new TableSchema.TableColumn(schema);
				colvarContact.ColumnName = "Contact";
				colvarContact.DataType = DbType.AnsiString;
				colvarContact.MaxLength = 50;
				colvarContact.AutoIncrement = false;
				colvarContact.IsNullable = true;
				colvarContact.IsPrimaryKey = false;
				colvarContact.IsForeignKey = false;
				colvarContact.IsReadOnly = false;
				colvarContact.DefaultSetting = @"";
				colvarContact.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContact);
				
				TableSchema.TableColumn colvarCnic = new TableSchema.TableColumn(schema);
				colvarCnic.ColumnName = "CNIC";
				colvarCnic.DataType = DbType.AnsiString;
				colvarCnic.MaxLength = 50;
				colvarCnic.AutoIncrement = false;
				colvarCnic.IsNullable = true;
				colvarCnic.IsPrimaryKey = false;
				colvarCnic.IsForeignKey = false;
				colvarCnic.IsReadOnly = false;
				colvarCnic.DefaultSetting = @"";
				colvarCnic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCnic);
				
				TableSchema.TableColumn colvarLimit = new TableSchema.TableColumn(schema);
				colvarLimit.ColumnName = "Limit";
				colvarLimit.DataType = DbType.Int32;
				colvarLimit.MaxLength = 0;
				colvarLimit.AutoIncrement = false;
				colvarLimit.IsNullable = true;
				colvarLimit.IsPrimaryKey = false;
				colvarLimit.IsForeignKey = false;
				colvarLimit.IsReadOnly = false;
				colvarLimit.DefaultSetting = @"";
				colvarLimit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLimit);
				
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
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Int32;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = true;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("Tbl_Client",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Clientid")]
		[Bindable(true)]
		public int Clientid 
		{
			get { return GetColumnValue<int>(Columns.Clientid); }
			set { SetColumnValue(Columns.Clientid, value); }
		}
		  
		[XmlAttribute("ClientName")]
		[Bindable(true)]
		public string ClientName 
		{
			get { return GetColumnValue<string>(Columns.ClientName); }
			set { SetColumnValue(Columns.ClientName, value); }
		}
		  
		[XmlAttribute("Contact")]
		[Bindable(true)]
		public string Contact 
		{
			get { return GetColumnValue<string>(Columns.Contact); }
			set { SetColumnValue(Columns.Contact, value); }
		}
		  
		[XmlAttribute("Cnic")]
		[Bindable(true)]
		public string Cnic 
		{
			get { return GetColumnValue<string>(Columns.Cnic); }
			set { SetColumnValue(Columns.Cnic, value); }
		}
		  
		[XmlAttribute("Limit")]
		[Bindable(true)]
		public int? Limit 
		{
			get { return GetColumnValue<int?>(Columns.Limit); }
			set { SetColumnValue(Columns.Limit, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public int? IsActive 
		{
			get { return GetColumnValue<int?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varClientName,string varContact,string varCnic,int? varLimit,DateTime? varDateX,int? varIsActive)
		{
			TblClient item = new TblClient();
			
			item.ClientName = varClientName;
			
			item.Contact = varContact;
			
			item.Cnic = varCnic;
			
			item.Limit = varLimit;
			
			item.DateX = varDateX;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varClientid,string varClientName,string varContact,string varCnic,int? varLimit,DateTime? varDateX,int? varIsActive)
		{
			TblClient item = new TblClient();
			
				item.Clientid = varClientid;
			
				item.ClientName = varClientName;
			
				item.Contact = varContact;
			
				item.Cnic = varCnic;
			
				item.Limit = varLimit;
			
				item.DateX = varDateX;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ClientidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClientNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CnicColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LimitColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Clientid = @"Clientid";
			 public static string ClientName = @"ClientName";
			 public static string Contact = @"Contact";
			 public static string Cnic = @"CNIC";
			 public static string Limit = @"Limit";
			 public static string DateX = @"Date";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
