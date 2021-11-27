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
        public TypeUtilisateur TypeUtilisateur { get; set; }
        public Compte Compte { get; set; }
        public List<Commande> Commandes { get; set; }

        public Utilisateur(string nom, string prenom, string ville, string username, string password, string confirmPWD, string email, TypeUtilisateur typeUtilisateur)
        {
            Nom = nom;
            Prenom = prenom;
            Ville = ville;
            Username = username;
            Password = password;
            ConfirmPWD = confirmPWD;
            Email = email;
            TypeUtilisateur = typeUtilisateur;
        }

        public Utilisateur()
        {
        }
    }
}
