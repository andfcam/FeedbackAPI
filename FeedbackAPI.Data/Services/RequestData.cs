using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Request Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Accept(int id)
        {
            throw new NotImplementedException();
        }

        public void Reject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
