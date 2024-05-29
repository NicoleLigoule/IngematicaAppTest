using IngematicaAppTest.Model;
using IngematicaAppTest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IngematicaAppTest.Service
{
    public interface ICalculosService
    {
        DateTime CalcularFechaLlegada(DateTime fechaPartida, int idLocalidad, int idTipoTransporte, bool porRuta);
    }
    public partial class CalculoService : ICalculosService
    {
        private readonly CalculoBusiness _calculoBusiness;
        public CalculoService()
        {
            _calculoBusiness = new CalculoBusiness();
        }

        public DateTime CalcularFechaLlegada(DateTime fechaPartida, int idLocalidad, int idTipoTransporte, bool porRuta)
        {
            return _calculoBusiness.CalcularFechaLlegada(fechaPartida, idLocalidad, idTipoTransporte, porRuta);
        }
    }
}

