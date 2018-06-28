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
	/// Strongly-typed collection for the TblMobilOilSale class.
	/// </summary>
    [Serializable]
	public partial class TblMobilOilSaleCollection : ActiveList<TblMobilOilSale, TblMobilOilSaleCollection>
	{	   
		public TblMobilOilSaleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblMobilOilSaleCollection</returns>
		public TblMobilOilSaleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblMobilOilSale o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tbl_MobilOilSale table.
	/// </summary>
	[Serializable]
	public partial class TblMobilOilSale : ActiveRecord<TblMobilOilSale>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblMobilOilSale()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblMobilOilSale(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblMobilOilSale(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblMobilOilSale(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tbl_MobilOilSale", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPk = new TableSchema.TableColumn(schema);
				colvarPk.ColumnName = "PK";
				colvarPk.DataType = DbType.Int32;
				colvarPk.MaxLength = 0;
				colvarPk.AutoIncrement = true;
				colvarPk.IsNullable = false;
				colvarPk.IsPrimaryKey = true;
				colvarPk.IsForeignKey = false;
				colvarPk.IsReadOnly = false;
				colvarPk.DefaultSetting = @"";
				colvarPk.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPk);
				
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
				
				TableSchema.TableColumn colvarRecieptNo = new TableSchema.TableColumn(schema);
				colvarRecieptNo.ColumnName = "RecieptNo";
				colvarRecieptNo.DataType = DbType.AnsiString;
				colvarRecieptNo.MaxLength = -1;
				colvarRecieptNo.AutoIncrement = false;
				colvarRecieptNo.IsNullable = true;
				colvarRecieptNo.IsPrimaryKey = false;
				colvarRecieptNo.IsForeignKey = false;
				colvarRecieptNo.IsReadOnly = false;
				colvarRecieptNo.DefaultSetting = @"";
				colvarRecieptNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecieptNo);
				
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
				
				TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
				colvarDiscount.ColumnName = "Discount";
				colvarDiscount.DataType = DbType.Double;
				colvarDiscount.MaxLength = 0;
				colvarDiscount.AutoIncrement = false;
				colvarDiscount.IsNullable = true;
				colvarDiscount.IsPrimaryKey = false;
				colvarDiscount.IsForeignKey = false;
				colvarDiscount.IsReadOnly = false;
				colvarDiscount.DefaultSetting = @"";
				colvarDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscount);
				
				TableSchema.TableColumn colvarPerPrice = new TableSchema.TableColumn(schema);
				colvarPerPrice.ColumnName = "PerPrice";
				colvarPerPrice.DataType = DbType.Double;
				colvarPerPrice.MaxLength = 0;
				colvarPerPrice.AutoIncrement = false;
				colvarPerPrice.IsNullable = true;
				colvarPerPrice.IsPrimaryKey = false;
				colvarPerPrice.IsForeignKey = false;
				colvarPerPrice.IsReadOnly = false;
				colvarPerPrice.DefaultSetting = @"";
				colvarPerPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerPrice);
				
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
				
				TableSchema.TableColumn colvarTotal = new TableSchema.TableColumn(schema);
				colvarTotal.ColumnName = "Total";
				colvarTotal.DataType = DbType.Double;
				colvarTotal.MaxLength = 0;
				colvarTotal.AutoIncrement = false;
				colvarTotal.IsNullable = true;
				colvarTotal.IsPrimaryKey = false;
				colvarTotal.IsForeignKey = false;
				colvarTotal.IsReadOnly = false;
				colvarTotal.DefaultSetting = @"";
				colvarTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotal);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("Tbl_MobilOilSale",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Pk")]
		[Bindable(true)]
		public int Pk 
		{
			get { return GetColumnValue<int>(Columns.Pk); }
			set { SetColumnValue(Columns.Pk, value); }
		}
		  
		[XmlAttribute("Productid")]
		[Bindable(true)]
		public int? Productid 
		{
			get { return GetColumnValue<int?>(Columns.Productid); }
			set { SetColumnValue(Columns.Productid, value); }
		}
		  
		[XmlAttribute("RecieptNo")]
		[Bindable(true)]
		public string RecieptNo 
		{
			get { return GetColumnValue<string>(Columns.RecieptNo); }
			set { SetColumnValue(Columns.RecieptNo, value); }
		}
		  
		[XmlAttribute("Liters")]
		[Bindable(true)]
		public double? Liters 
		{
			get { return GetColumnValue<double?>(Columns.Liters); }
			set { SetColumnValue(Columns.Liters, value); }
		}
		  
		[XmlAttribute("Discount")]
		[Bindable(true)]
		public double? Discount 
		{
			get { return GetColumnValue<double?>(Columns.Discount); }
			set { SetColumnValue(Columns.Discount, value); }
		}
		  
		[XmlAttribute("PerPrice")]
		[Bindable(true)]
		public double? PerPrice 
		{
			get { return GetColumnValue<double?>(Columns.PerPrice); }
			set { SetColumnValue(Columns.PerPrice, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public string DateX 
		{
			get { return GetColumnValue<string>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("Total")]
		[Bindable(true)]
		public double? Total 
		{
			get { return GetColumnValue<double?>(Columns.Total); }
			set { SetColumnValue(Columns.Total, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varProductid,string varRecieptNo,double? varLiters,double? varDiscount,double? varPerPrice,string varDateX,double? varTotal,string varDescription)
		{
			TblMobilOilSale item = new TblMobilOilSale();
			
			item.Productid = varProductid;
			
			item.RecieptNo = varRecieptNo;
			
			item.Liters = varLiters;
			
			item.Discount = varDiscount;
			
			item.PerPrice = varPerPrice;
			
			item.DateX = varDateX;
			
			item.Total = varTotal;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPk,int? varProductid,string varRecieptNo,double? varLiters,double? varDiscount,double? varPerPrice,string varDateX,double? varTotal,string varDescription)
		{
			TblMobilOilSale item = new TblMobilOilSale();
			
				item.Pk = varPk;
			
				item.Productid = varProductid;
			
				item.RecieptNo = varRecieptNo;
			
				item.Liters = varLiters;
			
				item.Discount = varDiscount;
			
				item.PerPrice = varPerPrice;
			
				item.DateX = varDateX;
			
				item.Total = varTotal;
			
				item.Description = varDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PkColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RecieptNoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LitersColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PerPriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Pk = @"PK";
			 public static string Productid = @"Productid";
			 public static string RecieptNo = @"RecieptNo";
			 public static string Liters = @"Liters";
			 public static string Discount = @"Discount";
			 public static string PerPrice = @"PerPrice";
			 public static string DateX = @"Date";
			 public static string Total = @"Total";
			 public static string Description = @"Description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
