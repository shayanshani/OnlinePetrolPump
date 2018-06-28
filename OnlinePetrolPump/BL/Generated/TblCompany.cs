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
	/// Strongly-typed collection for the TblCompany class.
	/// </summary>
    [Serializable]
	public partial class TblCompanyCollection : ActiveList<TblCompany, TblCompanyCollection>
	{	   
		public TblCompanyCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblCompanyCollection</returns>
		public TblCompanyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblCompany o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tbl_Company table.
	/// </summary>
	[Serializable]
	public partial class TblCompany : ActiveRecord<TblCompany>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblCompany()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblCompany(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblCompany(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblCompany(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tbl_Company", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCompanyid = new TableSchema.TableColumn(schema);
				colvarCompanyid.ColumnName = "Companyid";
				colvarCompanyid.DataType = DbType.Int32;
				colvarCompanyid.MaxLength = 0;
				colvarCompanyid.AutoIncrement = true;
				colvarCompanyid.IsNullable = false;
				colvarCompanyid.IsPrimaryKey = true;
				colvarCompanyid.IsForeignKey = false;
				colvarCompanyid.IsReadOnly = false;
				colvarCompanyid.DefaultSetting = @"";
				colvarCompanyid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompanyid);
				
				TableSchema.TableColumn colvarCompany = new TableSchema.TableColumn(schema);
				colvarCompany.ColumnName = "Company";
				colvarCompany.DataType = DbType.AnsiString;
				colvarCompany.MaxLength = 500;
				colvarCompany.AutoIncrement = false;
				colvarCompany.IsNullable = true;
				colvarCompany.IsPrimaryKey = false;
				colvarCompany.IsForeignKey = false;
				colvarCompany.IsReadOnly = false;
				colvarCompany.DefaultSetting = @"";
				colvarCompany.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompany);
				
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
				DataService.Providers["OnlinePetrolPump"].AddSchema("Tbl_Company",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Companyid")]
		[Bindable(true)]
		public int Companyid 
		{
			get { return GetColumnValue<int>(Columns.Companyid); }
			set { SetColumnValue(Columns.Companyid, value); }
		}
		  
		[XmlAttribute("Company")]
		[Bindable(true)]
		public string Company 
		{
			get { return GetColumnValue<string>(Columns.Company); }
			set { SetColumnValue(Columns.Company, value); }
		}
		  
		[XmlAttribute("Contact")]
		[Bindable(true)]
		public string Contact 
		{
			get { return GetColumnValue<string>(Columns.Contact); }
			set { SetColumnValue(Columns.Contact, value); }
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
		public static void Insert(string varCompany,string varContact,int? varIsActive)
		{
			TblCompany item = new TblCompany();
			
			item.Company = varCompany;
			
			item.Contact = varContact;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCompanyid,string varCompany,string varContact,int? varIsActive)
		{
			TblCompany item = new TblCompany();
			
				item.Companyid = varCompanyid;
			
				item.Company = varCompany;
			
				item.Contact = varContact;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CompanyidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CompanyColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Companyid = @"Companyid";
			 public static string Company = @"Company";
			 public static string Contact = @"Contact";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
