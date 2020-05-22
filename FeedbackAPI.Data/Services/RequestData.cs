using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Data.Services
{
    public class RequestData : IRequestData
    {
        private readonly FeedbackAPIDbContext _database;

        public RequestData(FeedbackAPIDbContext database)
        {
            _database = database;
        }

        public IEnumerable<Request> GetAll()
        {
            return _database.Requests;
        }

        public IEnumerable<Request> GetByStatus(StatusType status)
        {
            return _database.Requests.Where(request => request.Status == status);
        }

        public Request Get(int id)
        {
            return _database.Requests.Find(id);
        }

        public void Accept(int id)
        {
            var request = Get(id);
            request.Status = StatusType.Accepted;
            _database.Entry(request).State = EntityState.Modified;
            _database.SaveChanges();
        }

        public void Reject(int id)
        {
            var request = Get(id);
            request.Status = StatusType.Rejected;
            _database.Entry(request).State = EntityState.Modified;
            _database.SaveChanges();
        }

        public void Add(Request request)
        {
            _database.Requests.Add(request);
            _database.SaveChanges();
        }
    }
}
