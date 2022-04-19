using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet.Controller
{
    public class CategoryResponse
    {
        public Guid Id {get; set;}
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}