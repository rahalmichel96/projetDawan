using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateParution { get; set; }
        public string Resume { get; set; }
        public double Valeur { get; set; }
        public EtatLivre Etat { get; set; }
    }
}
