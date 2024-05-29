using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngematicaAppTest.Model;
using IngematicaAppTest.Business;


namespace IngematicaAppTest.Service
{
    public partial class EleccionViaService
    {
        public List<EleccionViaModel> GetList()
        {
            EleccionViaBusiness bs = new EleccionViaBusiness();

            return bs.GetList();
        }

        public EleccionViaModel GetById(int id)
        {
            EleccionViaBusiness bs = new EleccionViaBusiness();

            EleccionViaModel eleccionVia = bs.GetById(id);

            return eleccionVia;
        }
    }
}
