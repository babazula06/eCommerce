using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using _Core.Models;

namespace _Models.Concrete
{
    public class Order : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 OrderId { get; set; }
        public Int64 CampaignId { get; set; }
        public string ProductCode { get; set; }       
        public Int32 OrderQuantity { get; set; }
        public Decimal OrderPrice { get; set; }        
        public byte RecordStatus { get; set; }
        public DateTime CreateTime { get; set; }
     
      

    }
}
