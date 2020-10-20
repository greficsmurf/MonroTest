using ArtMonroTest.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMonroTest.Database.Models
{
    public class TestData
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductSize { get; set; }
        public int ProductAmount { get; set; }

        public IsInStock isAvailable {get;set;} 
    }
}
