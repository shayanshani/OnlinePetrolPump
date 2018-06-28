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
	/// Strongly-typed collection for the TblTankGainLoss class.
	/// </summary>
    [Serializable]
	public partial class TblTankGainLossCollection : ActiveList<TblTankGainLoss, TblTankGainLossCollection>
	{	   
		public TblTankGainLossCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblTankGainLossCollection</returns>
		public TblTankGainLossCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblTankGainLoss o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_TankGainLoss table.
	/// </summary>
	[Serializable]
	public partial class TblTankGainLoss : ActiveRecord<TblTankGainLoss>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblTankGainLoss()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblTankGainLoss(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblTankGainLoss(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblTankGainLoss(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_TankGainLoss", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
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
				
				TableSchema.TableColumn colvarQty = new TableSchema.TableColumn(schema);
				colvarQty.ColumnName = "Qty";
				colvarQty.DataType = DbType.Currency;
				colvarQty.MaxLength = 0;
				colvarQty.AutoIncrement = false;
				colvarQty.IsNullable = true;
				colvarQty.IsPrimaryKey = false;
				colvarQty.IsForeignKey = false;
				colvarQty.IsReadOnly = false;
				colvarQty.DefaultSetting = @"";
				colvarQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQty);
				
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
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.Int32;
				colvarType.MaxLength = 0;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = true;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_TankGainLoss",schema);
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
		  
		[XmlAttribute("CategoryID")]
		[Bindable(true)]
		public int? CategoryID 
		{
			get { return GetColumnValue<int?>(Columns.CategoryID); }
			set { SetColumnValue(Columns.CategoryID, value); }
		}
		  
		[XmlAttribute("Qty")]
		[Bindable(true)]
		public decimal? Qty 
		{
			get { return GetColumnValue<decimal?>(Columns.Qty); }
			set { SetColumnValue(Columns.Qty, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("Type")]
		[Bindable(true)]
		public int? Type 
		{
			get { return GetColumnValue<int?>(Columns.Type); }
			set { SetColumnValue(Columns.Type, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCategoryID,decimal? varQty,DateTime? varDateX,int? varType)
		{
			TblTankGainLoss item = new TblTankGainLoss();
			
			item.CategoryID = varCategoryID;
			
			item.Qty = varQty;
			
			item.DateX = varDateX;
			
			item.Type = varType;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSerialNo,int? varCategoryID,decimal? varQty,DateTime? varDateX,int? varType)
		{
			TblTankGainLoss item = new TblTankGainLoss();
			
				item.SerialNo = varSerialNo;
			
				item.CategoryID = varCategoryID;
			
				item.Qty = varQty;
			
				item.DateX = varDateX;
			
				item.Type = varType;
			
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
        
        
        
        public static TableSchema.TableColumn CategoryIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn QtyColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SerialNo = @"SerialNo";
			 public static string CategoryID = @"CategoryID";
			 public static string Qty = @"Qty";
			 public static string DateX = @"Date";
			 public static string Type = @"Type";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
