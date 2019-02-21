using AddMessages.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListOfMessages.data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {

        }
        public DbSet<MessageB> MessageBs { get; set; }
    }
}
