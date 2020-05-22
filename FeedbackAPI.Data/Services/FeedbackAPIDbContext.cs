using System.Data.Entity;

using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Data.Services
{
    public class FeedbackAPIDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}
