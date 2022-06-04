using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceProject3.Models;

namespace ServiceProject3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ServiceProject3.Models.Service> Service { get; set; }
        public DbSet<ServiceProject3.Models.ServiceBought> ServiceBought { get; set; }
        public DbSet<ServiceProject3.Models.Material> Material { get; set; }
        public DbSet<ServiceProject3.Models.MaterialBought> MaterialBought { get; set; }
        public DbSet<ServiceProject3.Models.UserDetail> UserDetail { get; set; }
        public DbSet<ServiceProject3.Models.Category> Category { get; set; }
        public DbSet<ServiceProject3.Models.MaterialCategory> MaterialCategory { get; set; }
        public DbSet<MaterialSubCategory> MaterialSubCategory { get; set; }
        public DbSet<ServiceProject3.Models.MaterialSubCatePrice> MaterialSubCatePrice { get; set; }
    }
}
