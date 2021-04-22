using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
