﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Data
{
    public class BookStoreContext : DbContext
    {
      
            public BookStoreContext(DbContextOptions<BookStoreContext> options)
                : base(options)
            {

            
            }


        public DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = BookStore; user id = sa; password = GL@M6@73s;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Webgentle.BookStore.Models.BookModel> BookModel { get; set; }

    }
}
