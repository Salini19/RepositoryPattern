using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System.Collections.Generic;

namespace RepositoryPattern
{
    public class Dbclass : DbContext
    {
        public Dbclass(DbContextOptions<Dbclass> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
