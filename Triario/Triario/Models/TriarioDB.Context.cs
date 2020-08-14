﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Triario.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TriarioEntities1 : DbContext
    {
        public TriarioEntities1()
            : base("name=TriarioEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual int Actualizate_Department(string id_Department, string name)
        {
            var id_DepartmentParameter = id_Department != null ?
                new ObjectParameter("Id_Department", id_Department) :
                new ObjectParameter("Id_Department", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Actualizate_Department", id_DepartmentParameter, nameParameter);
        }
    
        public virtual int Actualizate_Employee(Nullable<int> cC, string fName, string lName, string eUser, string email, Nullable<decimal> salary, string fk_Department)
        {
            var cCParameter = cC.HasValue ?
                new ObjectParameter("CC", cC) :
                new ObjectParameter("CC", typeof(int));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var eUserParameter = eUser != null ?
                new ObjectParameter("EUser", eUser) :
                new ObjectParameter("EUser", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(decimal));
    
            var fk_DepartmentParameter = fk_Department != null ?
                new ObjectParameter("Fk_Department", fk_Department) :
                new ObjectParameter("Fk_Department", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Actualizate_Employee", cCParameter, fNameParameter, lNameParameter, eUserParameter, emailParameter, salaryParameter, fk_DepartmentParameter);
        }
    
        public virtual int Create_Department(string id_Department, string name)
        {
            var id_DepartmentParameter = id_Department != null ?
                new ObjectParameter("Id_Department", id_Department) :
                new ObjectParameter("Id_Department", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Create_Department", id_DepartmentParameter, nameParameter);
        }
    
        public virtual int Create_Employee(Nullable<int> cC, string fName, string lName, string eUser, string email, Nullable<decimal> salary, string fk_Department)
        {
            var cCParameter = cC.HasValue ?
                new ObjectParameter("CC", cC) :
                new ObjectParameter("CC", typeof(int));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var eUserParameter = eUser != null ?
                new ObjectParameter("EUser", eUser) :
                new ObjectParameter("EUser", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(decimal));
    
            var fk_DepartmentParameter = fk_Department != null ?
                new ObjectParameter("Fk_Department", fk_Department) :
                new ObjectParameter("Fk_Department", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Create_Employee", cCParameter, fNameParameter, lNameParameter, eUserParameter, emailParameter, salaryParameter, fk_DepartmentParameter);
        }
    
        public virtual int Delete_Department(string id_Department)
        {
            var id_DepartmentParameter = id_Department != null ?
                new ObjectParameter("Id_Department", id_Department) :
                new ObjectParameter("Id_Department", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_Department", id_DepartmentParameter);
        }
    
        public virtual int Delete_Employee(Nullable<int> cC)
        {
            var cCParameter = cC.HasValue ?
                new ObjectParameter("CC", cC) :
                new ObjectParameter("CC", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_Employee", cCParameter);
        }
    
        public virtual ObjectResult<Search_Department_Result> Search_Department(string id_Department)
        {
            var id_DepartmentParameter = id_Department != null ?
                new ObjectParameter("Id_Department", id_Department) :
                new ObjectParameter("Id_Department", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Search_Department_Result>("Search_Department", id_DepartmentParameter);
        }
    
        public virtual ObjectResult<Search_Employee_Result> Search_Employee(Nullable<int> cC)
        {
            var cCParameter = cC.HasValue ?
                new ObjectParameter("CC", cC) :
                new ObjectParameter("CC", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Search_Employee_Result>("Search_Employee", cCParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<decimal>> Sum_Department()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("Sum_Department");
        }
    
        public virtual ObjectResult<Sum_Salary_Department_Result> Sum_Salary_Department(string id_Department)
        {
            var id_DepartmentParameter = id_Department != null ?
                new ObjectParameter("Id_Department", id_Department) :
                new ObjectParameter("Id_Department", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sum_Salary_Department_Result>("Sum_Salary_Department", id_DepartmentParameter);
        }

        public System.Data.Entity.DbSet<Triario.Models.ViewModels.JoinViewModel> JoinViewModels { get; set; }
    }
}
