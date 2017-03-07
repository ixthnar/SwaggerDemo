using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwaggerDemo.Models
{
    /// <summary>
    /// Customer class XML doc
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer class id XML doc
        /// </summary>
        [Key]
        public int id { get; set; }
    }
}