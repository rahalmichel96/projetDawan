using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Utilisateur : BaseEntity
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        public string Ville { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public string ConfirmPWD { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Admin { get; set; }
        public Compte Compte { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
