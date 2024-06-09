using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;
using WatercolorsPainting_DAO;
using WatercolorsPainting_Repository.Interface;

namespace WatercolorsPainting_Repository
{
    public class WatercolorsPaintingRepository : IWatercolorsPaintingRepository
    {
        private readonly WatercolorsPaintingDAO _dao;

        public WatercolorsPaintingRepository()
        {
            _dao ??= new WatercolorsPaintingDAO();
        }

        public void CreateWater(WatercolorsPainting watercolorsPainting)
        {
            this._dao.Create(watercolorsPainting);
        }

        public IQueryable<WatercolorsPainting> GetAll(Expression<Func<WatercolorsPainting, bool>>? predicate = null,
        Func<IQueryable<WatercolorsPainting>, IOrderedQueryable<WatercolorsPainting>>? orderBy = null,
        List<Expression<Func<WatercolorsPainting, object>>>? includes = null,
        bool disableTracking = false)
        {
            return this._dao.Get(predicate, orderBy, includes, disableTracking);
        }

        public void UpdateWater(WatercolorsPainting watercolorsPainting)
        {
           this._dao.Update(watercolorsPainting);
        }
    }
}
