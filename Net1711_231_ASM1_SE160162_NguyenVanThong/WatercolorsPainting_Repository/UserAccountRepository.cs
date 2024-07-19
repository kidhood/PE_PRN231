using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;
using WatercolorsPainting_DAO;
using WatercolorsPainting_Repository.Interface;

namespace WatercolorsPainting_Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly UserAccountDAO _dao;

        public UserAccountRepository()
        {
            _dao ??= new UserAccountDAO();
        }

        public UserAccount CheckLogin(string email, string password)
        {
            return this._dao.Get().Where(x => x.UserEmail == email && x.UserPassword == password).FirstOrDefault(); 
        }
    }
}
