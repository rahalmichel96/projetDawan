using BookExchange.Core.Models;
using BookExchange.DataAccess.SQL.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.DataAccess.SQL
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private MyContext DataContext;

        public UtilisateurRepository(MyContext dataContext)
        {
            DataContext = dataContext;
        }

        public Utilisateur FindByMail(string email)
        {
            return DataContext.Utilisateurs.SingleOrDefault(u => u.Email == email);
        }
    }
}
