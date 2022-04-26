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

        public Category(string name, string createdBy, string editedBy)
        {
            var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name")
            .IsNotNullOrEmpty(createdBy, "CreatedBy")
            .IsNotNullOrEmpty(editedBy, "EditedBy");
            AddNotifications(contract);

            Name = name;
            Active = true;
            CreatedBy = createdBy;
            EditedBy = editedBy;
            CreatedOn = DateTime.Now;
            EditedBy = "Test";
            EditedOn = DateTime.Now;
        }
    }
}
