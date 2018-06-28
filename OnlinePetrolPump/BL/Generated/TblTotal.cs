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
	/// Strongly-typed collection for the TblTotal class.
	/// </summary>
    [Serializable]
	public partial class TblTotalCollection : ActiveList<TblTotal, TblTotalCollection>
	{	   
		public TblTotalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblTotalCollection</returns>
		public TblTotalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblTotal o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Totals table.
	/// </summary>
	[Serializable]
	public partial class TblTotal : ActiveRecord<TblTotal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblTotal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblTotal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblTotal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblTotal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Totals", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTotalID = new TableSchema.TableColumn(schema);
				colvarTotalID.ColumnName = "TotalID";
				colvarTotalID.DataType = DbType.Int32;
				colvarTotalID.MaxLength = 0;
				colvarTotalID.AutoIncrement = true;
				colvarTotalID.IsNullable = false;
				colvarTotalID.IsPrimaryKey = true;
				colvarTotalID.IsForeignKey = false;
				colvarTotalID.IsReadOnly = false;
				colvarTotalID.DefaultSetting = @"";
				colvarTotalID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalID);
				
				TableSchema.TableColumn colvarTotalPurchase = new TableSchema.TableColumn(schema);
				colvarTotalPurchase.ColumnName = "TotalPurchase";
				colvarTotalPurchase.DataType = DbType.Currency;
				colvarTotalPurchase.MaxLength = 0;
				colvarTotalPurchase.AutoIncrement = false;
				colvarTotalPurchase.IsNullable = true;
				colvarTotalPurchase.IsPrimaryKey = false;
				colvarTotalPurchase.IsForeignKey = false;
				colvarTotalPurchase.IsReadOnly = false;
				colvarTotalPurchase.DefaultSetting = @"";
				colvarTotalPurchase.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalPurchase);
				
				TableSchema.TableColumn colvarTotalSale = new TableSchema.TableColumn(schema);
				colvarTotalSale.ColumnName = "TotalSale";
				colvarTotalSale.DataType = DbType.Currency;
				colvarTotalSale.MaxLength = 0;
				colvarTotalSale.AutoIncrement = false;
				colvarTotalSale.IsNullable = true;
				colvarTotalSale.IsPrimaryKey = false;
				colvarTotalSale.IsForeignKey = false;
				colvarTotalSale.IsReadOnly = false;
				colvarTotalSale.DefaultSetting = @"";
				colvarTotalSale.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalSale);
				
				TableSchema.TableColumn colvarTotalExpense = new TableSchema.TableColumn(schema);
				colvarTotalExpense.ColumnName = "TotalExpense";
				colvarTotalExpense.DataType = DbType.Currency;
				colvarTotalExpense.MaxLength = 0;
				colvarTotalExpense.AutoIncrement = false;
				colvarTotalExpense.IsNullable = true;
				colvarTotalExpense.IsPrimaryKey = false;
				colvarTotalExpense.IsForeignKey = false;
				colvarTotalExpense.IsReadOnly = false;
				colvarTotalExpense.DefaultSetting = @"";
				colvarTotalExpense.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalExpense);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_Totals",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TotalID")]
		[Bindable(true)]
		public int TotalID 
		{
			get { return GetColumnValue<int>(Columns.TotalID); }
			set { SetColumnValue(Columns.TotalID, value); }
		}
		  
		[XmlAttribute("TotalPurchase")]
		[Bindable(true)]
		public decimal? TotalPurchase 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalPurchase); }
			set { SetColumnValue(Columns.TotalPurchase, value); }
		}
		  
		[XmlAttribute("TotalSale")]
		[Bindable(true)]
		public decimal? TotalSale 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalSale); }
			set { SetColumnValue(Columns.TotalSale, value); }
		}
		  
		[XmlAttribute("TotalExpense")]
		[Bindable(true)]
		public decimal? TotalExpense 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalExpense); }
			set { SetColumnValue(Columns.TotalExpense, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(decimal? varTotalPurchase,decimal? varTotalSale,decimal? varTotalExpense)
		{
			TblTotal item = new TblTotal();
			
			item.TotalPurchase = varTotalPurchase;
			
			item.TotalSale = varTotalSale;
			
			item.TotalExpense = varTotalExpense;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTotalID,decimal? varTotalPurchase,decimal? varTotalSale,decimal? varTotalExpense)
		{
			TblTotal item = new TblTotal();
			
				item.TotalID = varTotalID;
			
				item.TotalPurchase = varTotalPurchase;
			
				item.TotalSale = varTotalSale;
			
				item.TotalExpense = varTotalExpense;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TotalIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalPurchaseColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalSaleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalExpenseColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TotalID = @"TotalID";
			 public static string TotalPurchase = @"TotalPurchase";
			 public static string TotalSale = @"TotalSale";
			 public static string TotalExpense = @"TotalExpense";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
