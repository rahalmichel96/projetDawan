using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Livre : BaseEntity
    {
        [Required]
        public string Titre { get; set; }
        [Required]
        public DateTime DateParution { get; set; }
        [Required]
        public string Resume { get; set; }
        [Required]
        public double Valeur { get; set; }
        [Required]
        public EtatLivre Etat { get; set; }
        public List<Categorie> Categories { get; set; }
        public List<Auteur> Auteurs { get; set; }
    }
}
