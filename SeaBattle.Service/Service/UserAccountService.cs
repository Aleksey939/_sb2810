using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Helpers;
using SeaBattle.Service.Base;
using System.Data.Entity.Validation;

using System.Windows;

namespace SeaBattle.Service.Service
{
   
        public class UserAccountService : ServiceBase
        {
       
        public UserAccountService(SeaBattleContext dbContext) : base(dbContext)
            {
            }

            public async Task<UserAccount> GetUserByEmail(string email)
            {
                var user = await UnitOfWork.Instance.DbContext.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);

                return user;
            }

            public  UserAccount AddUser(string email, string password)
            {
            if (string.IsNullOrEmpty(email) ||

                string.IsNullOrEmpty(password) ||
                UnitOfWork.Instance.DbContext.UserAccounts.Any(u => u.Email == email))
                return null;

            var user = new UserAccount {Email = email,Salt="default"};
            var hash = Crypto.HashPassword(password);
            user.HashPassword = hash;

            UnitOfWork.Instance.DbContext.UserAccounts.Add(user);
            try
            {
                UnitOfWork.Instance.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }

            return user;
            }

            public UserAccount VerifyUser(string email, string password)
            {
                var user = UnitOfWork.Instance.DbContext.UserAccounts.FirstOrDefault(u => u.Email == email);

                if (user == null) return null;

                if (Crypto.VerifyHashedPassword(user.HashPassword, password))
                    return user;

                return null;
            }
        }
    
}
