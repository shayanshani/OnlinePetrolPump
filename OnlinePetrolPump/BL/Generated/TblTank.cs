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
	/// Strongly-typed collection for the TblTank class.
	/// </summary>
    [Serializable]
	public partial class TblTankCollection : ActiveList<TblTank, TblTankCollection>
	{	   
		public TblTankCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblTankCollection</returns>
		public TblTankCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblTank o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tbl_Tank table.
	/// </summary>
	[Serializable]
	public partial class TblTank : ActiveRecord<TblTank>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblTank()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblTank(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblTank(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblTank(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tbl_Tank", TableType.Table, DataService.GetInstance("OnlinePetrolPump"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTankid = new TableSchema.TableColumn(schema);
				colvarTankid.ColumnName = "Tankid";
				colvarTankid.DataType = DbType.Int32;
				colvarTankid.MaxLength = 0;
				colvarTankid.AutoIncrement = true;
				colvarTankid.IsNullable = false;
				colvarTankid.IsPrimaryKey = true;
				colvarTankid.IsForeignKey = false;
				colvarTankid.IsReadOnly = false;
				colvarTankid.DefaultSetting = @"";
				colvarTankid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTankid);
				
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
				
				TableSchema.TableColumn colvarDip = new TableSchema.TableColumn(schema);
				colvarDip.ColumnName = "Dip";
				colvarDip.DataType = DbType.Double;
				colvarDip.MaxLength = 0;
				colvarDip.AutoIncrement = false;
				colvarDip.IsNullable = true;
				colvarDip.IsPrimaryKey = false;
				colvarDip.IsForeignKey = false;
				colvarDip.IsReadOnly = false;
				colvarDip.DefaultSetting = @"";
				colvarDip.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDip);
				
				TableSchema.TableColumn colvarCatagoryid = new TableSchema.TableColumn(schema);
				colvarCatagoryid.ColumnName = "Catagoryid";
				colvarCatagoryid.DataType = DbType.Int32;
				colvarCatagoryid.MaxLength = 0;
				colvarCatagoryid.AutoIncrement = false;
				colvarCatagoryid.IsNullable = true;
				colvarCatagoryid.IsPrimaryKey = false;
				colvarCatagoryid.IsForeignKey = false;
				colvarCatagoryid.IsReadOnly = false;
				colvarCatagoryid.DefaultSetting = @"";
				colvarCatagoryid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCatagoryid);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OnlinePetrolPump"].AddSchema("Tbl_Tank",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Tankid")]
		[Bindable(true)]
		public int Tankid 
		{
			get { return GetColumnValue<int>(Columns.Tankid); }
			set { SetColumnValue(Columns.Tankid, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public double? Quantity 
		{
			get { return GetColumnValue<double?>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("Dip")]
		[Bindable(true)]
		public double? Dip 
		{
			get { return GetColumnValue<double?>(Columns.Dip); }
			set { SetColumnValue(Columns.Dip, value); }
		}
		  
		[XmlAttribute("Catagoryid")]
		[Bindable(true)]
		public int? Catagoryid 
		{
			get { return GetColumnValue<int?>(Columns.Catagoryid); }
			set { SetColumnValue(Columns.Catagoryid, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(double? varQuantity,double? varDip,int? varCatagoryid)
		{
			TblTank item = new TblTank();
			
			item.Quantity = varQuantity;
			
			item.Dip = varDip;
			
			item.Catagoryid = varCatagoryid;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTankid,double? varQuantity,double? varDip,int? varCatagoryid)
		{
			TblTank item = new TblTank();
			
				item.Tankid = varTankid;
			
				item.Quantity = varQuantity;
			
				item.Dip = varDip;
			
				item.Catagoryid = varCatagoryid;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TankidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DipColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CatagoryidColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Tankid = @"Tankid";
			 public static string Quantity = @"Quantity";
			 public static string Dip = @"Dip";
			 public static string Catagoryid = @"Catagoryid";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
