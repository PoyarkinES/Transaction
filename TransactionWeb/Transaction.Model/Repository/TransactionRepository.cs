using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Transaction.Model.Entities;

namespace Transaction.Model.Repository
{
    public class ApiContext
    {
        private static List<Entity> Items { get; } = new List<Entity>();

        public IEnumerable<Entity> GetAll()
        {
            return Items;
        }

        public Entity Get(Guid id)
        {
            return Items.FirstOrDefault(f=>f.Id == id);
        }

        public bool Insert(Entity item)
        {
            try
            {
                Items.Add(item);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
