using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Transaction.Model.Entities;
using Transaction.Model.Repository;

namespace TransactionWeb.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ApiContext _transactionRepository = new ApiContext();

        // GET: api/Transaction
        [Route("Select")]
        public IEnumerable<Entity> Get()
        {
            return _transactionRepository.GetAll();
        }

        // GET: api/Transaction/5
        [Route("Get/{id}")]
        public Entity Get(Guid id)
        {
            return _transactionRepository.Get(id);
        }

        // POST: api/Transaction
        [Route("Insert")]
        [HttpPost]
        public bool Insert([FromBody] object request)
        {
            var items = JsonConvert.DeserializeObject<Entity>(request.ToString());
            return _transactionRepository.Insert(items);
        }
    }
}
