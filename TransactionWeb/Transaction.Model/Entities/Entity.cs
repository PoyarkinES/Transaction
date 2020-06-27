using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Model.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }
    }
}
