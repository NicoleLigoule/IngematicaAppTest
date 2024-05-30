using IngematicaAppTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Business
{
    public partial class EleccionViaBusiness
    {
        public List<EleccionViaModel> GetList()
        {
            List<EleccionViaModel> lista = SetList();
            return lista;
        }
        
        public EleccionViaModel GetById(int id)
        {
            List<EleccionViaModel> lista = SetList();
            EleccionViaModel eleccionVia = lista.Where(x => x.IdEleccionVia == id).FirstOrDefault();
            return eleccionVia;
        }

        private static List<EleccionViaModel> SetList()
        {
            List<EleccionViaModel> lista = new List<EleccionViaModel>();
            lista.Add(new EleccionViaModel { IdEleccionVia = 1, Camino = false, Nombre = "POR AUTOPISTA"});
            lista.Add(new EleccionViaModel { IdEleccionVia = 2, Camino = true, Nombre = "POR RUTA"});
            return lista;
        }
    }
}
