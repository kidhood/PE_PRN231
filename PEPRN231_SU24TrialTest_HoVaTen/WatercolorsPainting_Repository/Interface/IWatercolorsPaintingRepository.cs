using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;

namespace WatercolorsPainting_Repository.Interface
{
    public interface IWatercolorsPaintingRepository
    {
        void CreateWater(WatercolorsPainting watercolorsPainting);
        IQueryable<WatercolorsPainting> GetAll(Expression<Func<WatercolorsPainting, bool>>? predicate = null,
        Func<IQueryable<WatercolorsPainting>, IOrderedQueryable<WatercolorsPainting>>? orderBy = null,
        List<Expression<Func<WatercolorsPainting, object>>>? includes = null,
        bool disableTracking = false);
        void UpdateWater(WatercolorsPainting watercolorsPainting);
    }
}
