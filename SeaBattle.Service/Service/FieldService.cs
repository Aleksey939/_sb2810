using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using SeaBattle.Service.Base;
using System.Linq;
using System.Xml;

namespace SeaBattle.Service
{
    public   class FieldService: ServiceBase
    {



        public FieldService(SeaBattleContext dbContext) : base(dbContext)
        {
        }
        public async void SaveBattleFild(XmlDocument doc)
        {

            var fieldModel = new BattleField { Shema = doc };

            UnitOfWork.Instance.DbContext.Fields.Add(fieldModel);
            // _dbContext.Fields.Add(fieldModel);
            //  await SaveAsync();
           await  UnitOfWork.Instance.DbContext.SaveChangesAsync();

        }
        public XmlDocument GetBattleField()
        {

            var field = UnitOfWork.Instance.DbContext.Fields.FirstOrDefault();
                return field?.Shema;

        }
    }
}
