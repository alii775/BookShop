using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
 public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
        public DateTime  Created { get; set; }
        public bool IsAvail { get; set; }
        public bool ShowHomePage { get; set; }
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autor? Autor{ get; set; }

        public ICollection<BasketItems> ?BasketItems { get; set; }
       
    }
}
