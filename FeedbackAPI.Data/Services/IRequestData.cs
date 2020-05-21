using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Data.Services
{
    public interface IRequestData
    {
        IEnumerable<Request> GetAll();

        Request Get(int id);

        void Accept(int id);

        void Reject(int id);

        void Add(Request request);
    }
}
