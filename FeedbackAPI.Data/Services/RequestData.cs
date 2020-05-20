using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Data.Services
{
    class RequestData : IRequestData
    {
        public IEnumerable<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public Request Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Request request)
        {
            throw new NotImplementedException();
        }

        public void Update(Request request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
