using BookExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.DataAccess.SQL.Metier
{
    public interface IUtilisateurRepository
    {
        Utilisateur FindByMail(string mail);
    }
}
