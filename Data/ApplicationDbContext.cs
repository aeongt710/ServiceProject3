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
    }
}
