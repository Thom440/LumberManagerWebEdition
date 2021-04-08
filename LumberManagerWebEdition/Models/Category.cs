using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// The name of the type of lumber, ie: white wood, decking.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }

        public List<Product> Products { get; set; }
    }
}
