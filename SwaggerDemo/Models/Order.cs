using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwaggerDemo.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int idCust { get; set; }
    }
}