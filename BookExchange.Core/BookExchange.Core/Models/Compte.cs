using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Core.Models
{
    public class Compte : BaseEntity
    {
        [Required]
        public double Solde { get; set; }
    }
}
