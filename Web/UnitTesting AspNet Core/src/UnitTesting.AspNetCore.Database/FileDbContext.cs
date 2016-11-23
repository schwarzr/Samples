﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTesting.DotNetCore.Model;

namespace UnitTesting.DotNetCore.Database
{
    public class FileDbContext : DbContext
    {
        public FileDbContext()
        {
        }

        public FileDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FileReference> FileReferences { get; set; }

        public DbSet<User> Users { get; set; }

        public async Task AddTestDataAsync(string userName)
        {
            var user1 = new Model.User { Name = userName };
            var user2 = new Model.User { Name = "Testuser2" };
            var user3 = new Model.User { Name = "Testuser3" };
            this.Users.Add(user1);
            this.Users.Add(user2);
            this.Users.Add(user3);
            await this.SaveChangesAsync();
            this.FileReferences.Add(new FileReference { Id = Guid.NewGuid(), Author = user1, Name = "Testfile1", Path = "TestFile1.jpg", FileType = FileType.Image });
            this.FileReferences.Add(new FileReference { Id = Guid.NewGuid(), Author = user1, Name = "Testfile2", Path = "TestFile2.pdf", FileType = FileType.Document });
            this.FileReferences.Add(new FileReference { Id = Guid.NewGuid(), Author = user1, Name = "Testfile3", Path = "TestFile3.bin", FileType = FileType.Undefined });
            this.FileReferences.Add(new FileReference { Id = Guid.NewGuid(), Author = user1, Name = "Testfile4", Path = "TestFile4.iso", FileType = FileType.Undefined });
            this.FileReferences.Add(new FileReference { Id = Guid.NewGuid(), Author = user3, Name = "Testfile5", Path = "TestFile4.iso", FileType = FileType.Undefined });
            await this.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Initial Catalog=UnitTesting;");
            }
        }
    }
}