using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using SeaBattle.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeaBattle.Service.Service
{
    public class UserService:ServiceBase
    {
        public UserService(SeaBattleContext dbContext) : base(dbContext)
        {
        }
        public User AddUser(int userAccountId,string FN, string LN, string login)
        {
            if (string.IsNullOrEmpty(FN) ||
                 string.IsNullOrEmpty(LN) ||
                string.IsNullOrEmpty(login) ||
                UnitOfWork.Instance.DbContext.Users.Any(u => u.Login == login))
                return null;

            var user = new User { UserAccountId= userAccountId,FirstName = FN, LastName = LN, Login= login };
         

            UnitOfWork.Instance.DbContext.Users.Add(user);
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



    }
}
