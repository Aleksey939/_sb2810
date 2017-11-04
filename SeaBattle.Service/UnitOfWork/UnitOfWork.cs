using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Data.Model;
using SeaBattle.Data.Context;
using SeaBattle.Service.Service;

namespace SeaBattle.Service.Base
{
 public  class UnitOfWork
    {

       
        private static UnitOfWork _instance;

        private SeaBattleContext _dbContext;
        private FieldService _fieldService;
        private UserService _userService;
        private UserAccountService _userAccountService;
      
        private UnitOfWork()
        {

        }

        public static UnitOfWork Instance => _instance ?? (_instance = new UnitOfWork());

        public SeaBattleContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new SeaBattleContext();
                return _dbContext;
            }
        }

        public FieldService fieldService { get { _fieldService = new FieldService(_dbContext); return _fieldService; } }

        public UserAccountService userAccountService { get { _userAccountService = new UserAccountService(_dbContext);return _userAccountService; } }
        public UserService userService { get { _userService = new UserService(_dbContext); return _userService; } }
    }

    }

