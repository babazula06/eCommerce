using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using _Core.Models;

namespace _Models.Concrete
{
    public class Hour : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int CurrentHour { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
