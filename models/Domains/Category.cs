using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace udemy_dotnet.models.Domains
{
    public class Category : Entity
    {

        public string Name { get; set; }
        public bool Active { get; set; }

        public Category(string name)
        {
            var contract = new Contract<Category>().IsNotNull(name, "Name");
            
            AddNotifications(contract);

            Name = name;
            Active = true;
        }
    }
}
