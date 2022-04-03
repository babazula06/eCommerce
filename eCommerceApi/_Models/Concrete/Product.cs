using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using _Core.Models;

namespace _Models.Concrete
{
    public class Product : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ProductId { get; set; }      
        public string ProductCode { get; set; }
        public Decimal PriceActual { get; set; }
        public Decimal PriceOrginial { get; set; }
        public int Stock { get; set; }
        public byte RecordStatus { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUserID { get; set; }

    }
}
