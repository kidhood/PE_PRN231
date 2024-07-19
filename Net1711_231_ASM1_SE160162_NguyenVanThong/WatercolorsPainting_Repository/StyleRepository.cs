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
    public class StyleRepository : IStyleRepository
    {
        private readonly StyleDAO _dao;

        public StyleRepository()
        {
            _dao ??= new StyleDAO();
        }

        public List<Style> GetAll()
        {
            return this._dao.GetAll();
        }
    }
}
