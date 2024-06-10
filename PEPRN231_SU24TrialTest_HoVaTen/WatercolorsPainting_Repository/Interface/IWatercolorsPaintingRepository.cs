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
        IQueryable<WatercolorsPainting> GetAll();
        void UpdateWater(WatercolorsPainting watercolorsPainting);
    }
}
