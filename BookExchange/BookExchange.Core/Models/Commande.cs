using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Commande : BaseEntity
    {
        [Required]
        public DateTime DateCommande { get; set; }
        [Required]
        public double Montant { get; set; }
        [Range(1,15)]
        [Required]
        public int DureeEnJours { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
