using SeaBattle.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Service
{
    public abstract class ServiceBase
    {


        protected readonly SeaBattleContext _dbContext;

        public ServiceBase(SeaBattleContext context)
        {
            _dbContext = context;
        }



        public virtual void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public virtual async Task SaveAsync()
        {
            try
            {
              await  _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
