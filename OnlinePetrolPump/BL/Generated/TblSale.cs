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
	/// Strongly-typed collection for the TblSale class.
	/// </summary>
    [Serializable]
	public partial class TblSaleCollection : ActiveList<TblSale, TblSaleCollection>
	{	   
		public TblSaleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblSaleCollection</returns>
		public TblSaleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblSale o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Sales table.
	/// </summary>
	[Serializable]
	public partial class TblSale : ActiveRecord<TblSale>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblSale()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblSale(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblSale(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblSale(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Sales", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSno = new TableSchema.TableColumn(schema);
				colvarSno.ColumnName = "Sno";
				colvarSno.DataType = DbType.Int32;
				colvarSno.MaxLength = 0;
				colvarSno.AutoIncrement = true;
				colvarSno.IsNullable = false;
				colvarSno.IsPrimaryKey = true;
				colvarSno.IsForeignKey = false;
				colvarSno.IsReadOnly = false;
				colvarSno.DefaultSetting = @"";
				colvarSno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSno);
				
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
				
				TableSchema.TableColumn colvarQty = new TableSchema.TableColumn(schema);
				colvarQty.ColumnName = "Qty";
				colvarQty.DataType = DbType.Double;
				colvarQty.MaxLength = 0;
				colvarQty.AutoIncrement = false;
				colvarQty.IsNullable = true;
				colvarQty.IsPrimaryKey = false;
				colvarQty.IsForeignKey = false;
				colvarQty.IsReadOnly = false;
				colvarQty.DefaultSetting = @"";
				colvarQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQty);
				
				TableSchema.TableColumn colvarPrice = new TableSchema.TableColumn(schema);
				colvarPrice.ColumnName = "Price";
				colvarPrice.DataType = DbType.Currency;
				colvarPrice.MaxLength = 0;
				colvarPrice.AutoIncrement = false;
				colvarPrice.IsNullable = true;
				colvarPrice.IsPrimaryKey = false;
				colvarPrice.IsForeignKey = false;
				colvarPrice.IsReadOnly = false;
				colvarPrice.DefaultSetting = @"";
				colvarPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrice);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_Sales",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Sno")]
		[Bindable(true)]
		public int Sno 
		{
			get { return GetColumnValue<int>(Columns.Sno); }
			set { SetColumnValue(Columns.Sno, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("Qty")]
		[Bindable(true)]
		public double? Qty 
		{
			get { return GetColumnValue<double?>(Columns.Qty); }
			set { SetColumnValue(Columns.Qty, value); }
		}
		  
		[XmlAttribute("Price")]
		[Bindable(true)]
		public decimal? Price 
		{
			get { return GetColumnValue<decimal?>(Columns.Price); }
			set { SetColumnValue(Columns.Price, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public decimal? Rate 
		{
			get { return GetColumnValue<decimal?>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("CategoryID")]
		[Bindable(true)]
		public int? CategoryID 
		{
			get { return GetColumnValue<int?>(Columns.CategoryID); }
			set { SetColumnValue(Columns.CategoryID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varDateX,double? varQty,decimal? varPrice,decimal? varRate,int? varCategoryID)
		{
			TblSale item = new TblSale();
			
			item.DateX = varDateX;
			
			item.Qty = varQty;
			
			item.Price = varPrice;
			
			item.Rate = varRate;
			
			item.CategoryID = varCategoryID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSno,DateTime? varDateX,double? varQty,decimal? varPrice,decimal? varRate,int? varCategoryID)
		{
			TblSale item = new TblSale();
			
				item.Sno = varSno;
			
				item.DateX = varDateX;
			
				item.Qty = varQty;
			
				item.Price = varPrice;
			
				item.Rate = varRate;
			
				item.CategoryID = varCategoryID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SnoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn QtyColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PriceColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Sno = @"Sno";
			 public static string DateX = @"Date";
			 public static string Qty = @"Qty";
			 public static string Price = @"Price";
			 public static string Rate = @"Rate";
			 public static string CategoryID = @"CategoryID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
