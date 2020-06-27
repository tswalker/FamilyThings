﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyThings.DbContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class SampleDb : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertChildContainer(ChildContainer instance);
    partial void UpdateChildContainer(ChildContainer instance);
    partial void DeleteChildContainer(ChildContainer instance);
    partial void InsertColorType(ColorType instance);
    partial void UpdateColorType(ColorType instance);
    partial void DeleteColorType(ColorType instance);
    partial void InsertParentChildLinkage(ParentChildLinkage instance);
    partial void UpdateParentChildLinkage(ParentChildLinkage instance);
    partial void DeleteParentChildLinkage(ParentChildLinkage instance);
    partial void InsertParentContainer(ParentContainer instance);
    partial void UpdateParentContainer(ParentContainer instance);
    partial void DeleteParentContainer(ParentContainer instance);
    #endregion
		
		public SampleDb(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDb(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDb(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDb(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ChildContainer> ChildContainer
		{
			get
			{
				return this.GetTable<ChildContainer>();
			}
		}
		
		public System.Data.Linq.Table<ColorType> ColorType
		{
			get
			{
				return this.GetTable<ColorType>();
			}
		}
		
		public System.Data.Linq.Table<ParentChildLinkage> ParentChildLinkage
		{
			get
			{
				return this.GetTable<ParentChildLinkage>();
			}
		}
		
		public System.Data.Linq.Table<ParentContainer> ParentContainer
		{
			get
			{
				return this.GetTable<ParentContainer>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChildContainer")]
	public partial class ChildContainer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private System.Nullable<int> _ColorTypeId;
		
		private EntityRef<ColorType> _ColorType;
		
		private EntitySet<ParentChildLinkage> _ParentChildLinkage;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnColorTypeIdChanging(System.Nullable<int> value);
    partial void OnColorTypeIdChanged();
    #endregion
		
		public ChildContainer()
		{
			this._ColorType = default(EntityRef<ColorType>);
			this._ParentChildLinkage = new EntitySet<ParentChildLinkage>(new Action<ParentChildLinkage>(this.attach_ParentChildLinkage), new Action<ParentChildLinkage>(this.detach_ParentChildLinkage));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(128)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColorTypeId", DbType="Int")]
		public System.Nullable<int> ColorTypeId
		{
			get
			{
				return this._ColorTypeId;
			}
			set
			{
				if ((this._ColorTypeId != value))
				{
					if (this._ColorType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnColorTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ColorTypeId = value;
					this.SendPropertyChanged("ColorTypeId");
					this.OnColorTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ChildContainer_ColorType", Storage="_ColorType", ThisKey="ColorTypeId", OtherKey="Id", IsForeignKey=true)]
		public ColorType ColorType
		{
			get
			{
				return this._ColorType.Entity;
			}
			set
			{
				ColorType previousValue = this._ColorType.Entity;
				if (((previousValue != value) 
							|| (this._ColorType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ColorType.Entity = null;
						previousValue.ChildContainer.Remove(this);
					}
					this._ColorType.Entity = value;
					if ((value != null))
					{
						value.ChildContainer.Add(this);
						this._ColorTypeId = value.Id;
					}
					else
					{
						this._ColorTypeId = default(Nullable<int>);
					}
					this.SendPropertyChanged("ColorType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ParentChildLinkage_ChildContainer", Storage="_ParentChildLinkage", ThisKey="Id", OtherKey="ChildContainerId", DeleteRule="SET NULL")]
		public EntitySet<ParentChildLinkage> ParentChildLinkage
		{
			get
			{
				return this._ParentChildLinkage;
			}
			set
			{
				this._ParentChildLinkage.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ParentChildLinkage(ParentChildLinkage entity)
		{
			this.SendPropertyChanging();
			entity.ChildContainer = this;
		}
		
		private void detach_ParentChildLinkage(ParentChildLinkage entity)
		{
			this.SendPropertyChanging();
			entity.ChildContainer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ColorType")]
	public partial class ColorType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Symbol;
		
		private EntitySet<ChildContainer> _ChildContainer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSymbolChanging(string value);
    partial void OnSymbolChanged();
    #endregion
		
		public ColorType()
		{
			this._ChildContainer = new EntitySet<ChildContainer>(new Action<ChildContainer>(this.attach_ChildContainer), new Action<ChildContainer>(this.detach_ChildContainer));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(128)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="Char(1)")]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this.OnSymbolChanging(value);
					this.SendPropertyChanging();
					this._Symbol = value;
					this.SendPropertyChanged("Symbol");
					this.OnSymbolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ChildContainer_ColorType", Storage="_ChildContainer", ThisKey="Id", OtherKey="ColorTypeId", DeleteRule="SET NULL")]
		public EntitySet<ChildContainer> ChildContainer
		{
			get
			{
				return this._ChildContainer;
			}
			set
			{
				this._ChildContainer.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChildContainer(ChildContainer entity)
		{
			this.SendPropertyChanging();
			entity.ColorType = this;
		}
		
		private void detach_ChildContainer(ChildContainer entity)
		{
			this.SendPropertyChanging();
			entity.ColorType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ParentChildLinkage")]
	public partial class ParentChildLinkage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _ParentContainerId;
		
		private System.Nullable<int> _ChildContainerId;
		
		private EntityRef<ChildContainer> _ChildContainer;
		
		private EntityRef<ParentContainer> _ParentContainer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnParentContainerIdChanging(System.Nullable<int> value);
    partial void OnParentContainerIdChanged();
    partial void OnChildContainerIdChanging(System.Nullable<int> value);
    partial void OnChildContainerIdChanged();
    #endregion
		
		public ParentChildLinkage()
		{
			this._ChildContainer = default(EntityRef<ChildContainer>);
			this._ParentContainer = default(EntityRef<ParentContainer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentContainerId", DbType="Int")]
		public System.Nullable<int> ParentContainerId
		{
			get
			{
				return this._ParentContainerId;
			}
			set
			{
				if ((this._ParentContainerId != value))
				{
					if (this._ParentContainer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentContainerIdChanging(value);
					this.SendPropertyChanging();
					this._ParentContainerId = value;
					this.SendPropertyChanged("ParentContainerId");
					this.OnParentContainerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChildContainerId", DbType="Int")]
		public System.Nullable<int> ChildContainerId
		{
			get
			{
				return this._ChildContainerId;
			}
			set
			{
				if ((this._ChildContainerId != value))
				{
					if (this._ChildContainer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnChildContainerIdChanging(value);
					this.SendPropertyChanging();
					this._ChildContainerId = value;
					this.SendPropertyChanged("ChildContainerId");
					this.OnChildContainerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ParentChildLinkage_ChildContainer", Storage="_ChildContainer", ThisKey="ChildContainerId", OtherKey="Id", IsForeignKey=true)]
		public ChildContainer ChildContainer
		{
			get
			{
				return this._ChildContainer.Entity;
			}
			set
			{
				ChildContainer previousValue = this._ChildContainer.Entity;
				if (((previousValue != value) 
							|| (this._ChildContainer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ChildContainer.Entity = null;
						previousValue.ParentChildLinkage.Remove(this);
					}
					this._ChildContainer.Entity = value;
					if ((value != null))
					{
						value.ParentChildLinkage.Add(this);
						this._ChildContainerId = value.Id;
					}
					else
					{
						this._ChildContainerId = default(Nullable<int>);
					}
					this.SendPropertyChanged("ChildContainer");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ParentChildLinkage_ParentContainer", Storage="_ParentContainer", ThisKey="ParentContainerId", OtherKey="Id", IsForeignKey=true)]
		public ParentContainer ParentContainer
		{
			get
			{
				return this._ParentContainer.Entity;
			}
			set
			{
				ParentContainer previousValue = this._ParentContainer.Entity;
				if (((previousValue != value) 
							|| (this._ParentContainer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ParentContainer.Entity = null;
						previousValue.ParentChildLinkage.Remove(this);
					}
					this._ParentContainer.Entity = value;
					if ((value != null))
					{
						value.ParentChildLinkage.Add(this);
						this._ParentContainerId = value.Id;
					}
					else
					{
						this._ParentContainerId = default(Nullable<int>);
					}
					this.SendPropertyChanged("ParentContainer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ParentContainer")]
	public partial class ParentContainer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<ParentChildLinkage> _ParentChildLinkage;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public ParentContainer()
		{
			this._ParentChildLinkage = new EntitySet<ParentChildLinkage>(new Action<ParentChildLinkage>(this.attach_ParentChildLinkage), new Action<ParentChildLinkage>(this.detach_ParentChildLinkage));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(128)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ParentChildLinkage_ParentContainer", Storage="_ParentChildLinkage", ThisKey="Id", OtherKey="ParentContainerId", DeleteRule="CASCADE")]
		public EntitySet<ParentChildLinkage> ParentChildLinkage
		{
			get
			{
				return this._ParentChildLinkage;
			}
			set
			{
				this._ParentChildLinkage.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ParentChildLinkage(ParentChildLinkage entity)
		{
			this.SendPropertyChanging();
			entity.ParentContainer = this;
		}
		
		private void detach_ParentChildLinkage(ParentChildLinkage entity)
		{
			this.SendPropertyChanging();
			entity.ParentContainer = null;
		}
	}
}
#pragma warning restore 1591
