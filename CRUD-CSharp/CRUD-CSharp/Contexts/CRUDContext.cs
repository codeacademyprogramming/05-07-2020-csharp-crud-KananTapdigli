using CRUD_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_CSharp.Contexts
{
    public class CRUDContext : DbContext
    {
        public CRUDContext()
            : base("CRUDConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}