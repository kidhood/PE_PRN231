using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;

namespace WatercolorsPainting_Repository.Interface
{
    public interface IStyleRepository
    {
        List<Style> GetAll();
    }
}
