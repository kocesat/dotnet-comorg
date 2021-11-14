using ComorgApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComorgApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Broadcast> Broadcasts { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
