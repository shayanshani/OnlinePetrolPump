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
	/// Strongly-typed collection for the TblProduct class.
	/// </summary>
    [Serializable]
	public partial class TblProductCollection : ActiveList<TblProduct, TblProductCollection>
	{	   
		public TblProductCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblProductCollection</returns>
		public TblProductCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblProduct o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tbl_Product table.
	/// </summary>
	[Serializable]
	public partial class TblProduct : ActiveRecord<TblProduct>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblProduct()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblProduct(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblProduct(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblProduct(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tbl_Product", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProductid = new TableSchema.TableColumn(schema);
				colvarProductid.ColumnName = "Productid";
				colvarProductid.DataType = DbType.Int32;
				colvarProductid.MaxLength = 0;
				colvarProductid.AutoIncrement = true;
				colvarProductid.IsNullable = false;
				colvarProductid.IsPrimaryKey = true;
				colvarProductid.IsForeignKey = false;
				colvarProductid.IsReadOnly = false;
				colvarProductid.DefaultSetting = @"";
				colvarProductid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductid);
				
				TableSchema.TableColumn colvarProduct = new TableSchema.TableColumn(schema);
				colvarProduct.ColumnName = "Product";
				colvarProduct.DataType = DbType.AnsiString;
				colvarProduct.MaxLength = 500;
				colvarProduct.AutoIncrement = false;
				colvarProduct.IsNullable = true;
				colvarProduct.IsPrimaryKey = false;
				colvarProduct.IsForeignKey = false;
				colvarProduct.IsReadOnly = false;
				colvarProduct.DefaultSetting = @"";
				colvarProduct.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProduct);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("Tbl_Product",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Productid")]
		[Bindable(true)]
		public int Productid 
		{
			get { return GetColumnValue<int>(Columns.Productid); }
			set { SetColumnValue(Columns.Productid, value); }
		}
		  
		[XmlAttribute("Product")]
		[Bindable(true)]
		public string Product 
		{
			get { return GetColumnValue<string>(Columns.Product); }
			set { SetColumnValue(Columns.Product, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varProduct)
		{
			TblProduct item = new TblProduct();
			
			item.Product = varProduct;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductid,string varProduct)
		{
			TblProduct item = new TblProduct();
			
				item.Productid = varProductid;
			
				item.Product = varProduct;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProductidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Productid = @"Productid";
			 public static string Product = @"Product";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
