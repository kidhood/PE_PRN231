using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;

namespace WatercolorsPainting_Repository.Interface
{
    public interface IUserAccountRepository
    {
        UserAccount CheckLogin(string email, string password);
    }
}
