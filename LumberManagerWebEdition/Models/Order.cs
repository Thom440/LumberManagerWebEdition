using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        /// <summary>
        /// The date the order was placed.
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The date the order has shipped. (nullable)
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime? ShipDate { get; set; }

        public virtual List<OrderLineItems> OrderLineItems { get; set; } = new List<OrderLineItems>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Order()
        {
            this.InvoiceDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Invoice number: {OrderID}" + " " + String.Join(" ", Customers);
        }
    }
}
