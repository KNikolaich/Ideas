﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StaffTimeModelContainer : DbContext
    {
        public StaffTimeModelContainer()
            : base("name=StaffTimeModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Week> Week { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
    }
}
