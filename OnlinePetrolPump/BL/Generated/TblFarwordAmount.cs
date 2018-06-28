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
	/// Strongly-typed collection for the TblFarwordAmount class.
	/// </summary>
    [Serializable]
	public partial class TblFarwordAmountCollection : ActiveList<TblFarwordAmount, TblFarwordAmountCollection>
	{	   
		public TblFarwordAmountCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblFarwordAmountCollection</returns>
		public TblFarwordAmountCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblFarwordAmount o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_FarwordAmount table.
	/// </summary>
	[Serializable]
	public partial class TblFarwordAmount : ActiveRecord<TblFarwordAmount>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblFarwordAmount()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblFarwordAmount(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblFarwordAmount(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblFarwordAmount(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_FarwordAmount", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarFid = new TableSchema.TableColumn(schema);
				colvarFid.ColumnName = "FID";
				colvarFid.DataType = DbType.Int32;
				colvarFid.MaxLength = 0;
				colvarFid.AutoIncrement = true;
				colvarFid.IsNullable = false;
				colvarFid.IsPrimaryKey = true;
				colvarFid.IsForeignKey = false;
				colvarFid.IsReadOnly = false;
				colvarFid.DefaultSetting = @"";
				colvarFid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFid);
				
				TableSchema.TableColumn colvarSerialNo = new TableSchema.TableColumn(schema);
				colvarSerialNo.ColumnName = "SerialNo";
				colvarSerialNo.DataType = DbType.Int32;
				colvarSerialNo.MaxLength = 0;
				colvarSerialNo.AutoIncrement = false;
				colvarSerialNo.IsNullable = true;
				colvarSerialNo.IsPrimaryKey = false;
				colvarSerialNo.IsForeignKey = false;
				colvarSerialNo.IsReadOnly = false;
				colvarSerialNo.DefaultSetting = @"";
				colvarSerialNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSerialNo);
				
				TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
				colvarRate.ColumnName = "Rate";
				colvarRate.DataType = DbType.Double;
				colvarRate.MaxLength = 0;
				colvarRate.AutoIncrement = false;
				colvarRate.IsNullable = true;
				colvarRate.IsPrimaryKey = false;
				colvarRate.IsForeignKey = false;
				colvarRate.IsReadOnly = false;
				colvarRate.DefaultSetting = @"";
				colvarRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRate);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Double;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = true;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarClientID = new TableSchema.TableColumn(schema);
				colvarClientID.ColumnName = "ClientID";
				colvarClientID.DataType = DbType.Int32;
				colvarClientID.MaxLength = 0;
				colvarClientID.AutoIncrement = false;
				colvarClientID.IsNullable = true;
				colvarClientID.IsPrimaryKey = false;
				colvarClientID.IsForeignKey = false;
				colvarClientID.IsReadOnly = false;
				colvarClientID.DefaultSetting = @"";
				colvarClientID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientID);
				
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
				DataService.Providers["OnlinePetrolPump"].AddSchema("tbl_FarwordAmount",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Fid")]
		[Bindable(true)]
		public int Fid 
		{
			get { return GetColumnValue<int>(Columns.Fid); }
			set { SetColumnValue(Columns.Fid, value); }
		}
		  
		[XmlAttribute("SerialNo")]
		[Bindable(true)]
		public int? SerialNo 
		{
			get { return GetColumnValue<int?>(Columns.SerialNo); }
			set { SetColumnValue(Columns.SerialNo, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public double? Rate 
		{
			get { return GetColumnValue<double?>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public double? Quantity 
		{
			get { return GetColumnValue<double?>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("ClientID")]
		[Bindable(true)]
		public int? ClientID 
		{
			get { return GetColumnValue<int?>(Columns.ClientID); }
			set { SetColumnValue(Columns.ClientID, value); }
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
		public static void Insert(int? varSerialNo,double? varRate,double? varQuantity,int? varClientID,int? varCategoryID)
		{
			TblFarwordAmount item = new TblFarwordAmount();
			
			item.SerialNo = varSerialNo;
			
			item.Rate = varRate;
			
			item.Quantity = varQuantity;
			
			item.ClientID = varClientID;
			
			item.CategoryID = varCategoryID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varFid,int? varSerialNo,double? varRate,double? varQuantity,int? varClientID,int? varCategoryID)
		{
			TblFarwordAmount item = new TblFarwordAmount();
			
				item.Fid = varFid;
			
				item.SerialNo = varSerialNo;
			
				item.Rate = varRate;
			
				item.Quantity = varQuantity;
			
				item.ClientID = varClientID;
			
				item.CategoryID = varCategoryID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn FidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SerialNoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ClientIDColumn
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
			 public static string Fid = @"FID";
			 public static string SerialNo = @"SerialNo";
			 public static string Rate = @"Rate";
			 public static string Quantity = @"Quantity";
			 public static string ClientID = @"ClientID";
			 public static string CategoryID = @"CategoryID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
