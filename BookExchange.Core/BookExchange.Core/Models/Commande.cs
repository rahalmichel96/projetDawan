using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }
    }
}
