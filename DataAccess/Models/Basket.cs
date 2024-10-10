using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
     public class Basket
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Payed { get; set; }

        public int UserId {  get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public Status Status { get; set; }
        [ForeignKey("UserId")]
        public User?User  { get; set; }


        public ICollection<BasketItems> ?BasketItems { get; set; }




    }
}
