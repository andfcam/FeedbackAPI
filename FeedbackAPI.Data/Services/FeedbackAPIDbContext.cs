using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Data.Services
{
    public class FeedbackAPIDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}
