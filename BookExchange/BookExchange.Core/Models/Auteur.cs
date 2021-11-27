using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Auteur : BaseEntity
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
