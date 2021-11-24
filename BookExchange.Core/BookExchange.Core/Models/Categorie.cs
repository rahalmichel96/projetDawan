using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Categorie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomCategorie { get; set; }
    }
}
