﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyProjectEntities : DbContext
    {
        public MyProjectEntities()
            : base("name=MyProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<atype> atype { get; set; }
        public virtual DbSet<book> book { get; set; }
        public virtual DbSet<book_class> book_class { get; set; }
        public virtual DbSet<istate> istate { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}