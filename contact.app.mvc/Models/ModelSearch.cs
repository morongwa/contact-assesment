using System;
using System.ComponentModel.DataAnnotations;

namespace contact.app.mvc.Models
{
    public class ModelSearch
    {
        public ModelSearch()
        {
        }
        [Required]
        public string Query { get; set; }
    }
}

