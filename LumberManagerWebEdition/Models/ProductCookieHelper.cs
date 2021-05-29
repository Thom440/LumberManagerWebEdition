using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public class ProductCookieHelper
    {
        public int ProductID { get; set; }

        /// <summary>
        /// The height of the lumber. ex 2 inches
        /// </summary>
        public byte Height { get; set; }

        /// <summary>
        /// The width of the lumber. ex 4 inches
        /// </summary>
        public byte Width { get; set; }

        /// <summary>
        /// The length of the lumber ex 8 foot
        /// </summary>
        public byte Length { get; set; }

        public byte Quantity { get; set; }

        public List<Category> Category { get; set; } = new List<Category>();
    }
}
