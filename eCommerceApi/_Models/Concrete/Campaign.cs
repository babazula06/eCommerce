using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using _Core.Models;

namespace _Models.Concrete
{
    public class Campaign : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CampaignId { get; set; }      
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public Decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public byte RecordStatus { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUserID { get; set; }

    }
}
