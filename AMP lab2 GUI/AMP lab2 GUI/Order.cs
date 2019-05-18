using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace AMP_lab2_GUI
{
    class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CardExpireDate { get; set; }
        public int CVV { get; set; }
        public string Status { get; set; } = "New";
        public int Price { get; set; }
        public Order()
        {

        }
        public int? TouristId { get; set; }//4-5.9 4-5.7
        public Tourist Tourist { get; set; }//4-5.9 4-5.7
    }
}
