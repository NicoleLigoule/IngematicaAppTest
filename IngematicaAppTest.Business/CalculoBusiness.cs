using IngematicaAppTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Business
{
    public partial class CalculoBusiness
    {
            public DateTime CalcularFechaLlegada(DateTime fechaPartida, int idLocalidad, int idTipoTransporte, bool porRuta)
            {
                LocalidadBusiness localidadBusiness = new LocalidadBusiness();
                TipoTransporteBusiness tipoTransporteBusiness = new TipoTransporteBusiness();

                LocalidadModel localidad = localidadBusiness.GetById(idLocalidad);
                TipoTransporteModel tipoTransporte = tipoTransporteBusiness.GetById(idTipoTransporte);

                if (localidad == null || tipoTransporte == null) // si no se encuenta la localidad o el tipo de transporte
                {
                    throw new ArgumentException("Localidad o tipo de transporte inválidos.");
                }

                int diasBaseDemora = localidad.DiasDemora;
                decimal coeficienteDemora = tipoTransporte.CoeficineteDemora;

                // calculo los dias de demora inicial
                decimal diasDemora = diasBaseDemora * coeficienteDemora;

                // condicion de si viaja por ruta
                if (porRuta)
                {
                    diasDemora *= 1.1m;
                }

                // math.ceiling lo que hace es redondear hacia arriba para ordenar el numero de dias
                int diasDemoraRedondeados = (int)Math.Ceiling(diasDemora);

                // excluyo los dias de semana
                DateTime fechaLlegada = fechaPartida;
                int diasContados = 0;

                while (diasContados < diasDemoraRedondeados)
                {
                    fechaLlegada = fechaLlegada.AddDays(1); // utilizo AddDays para sumar un dia y avanzar en el calendario pero reviso que no sea Sabado ni Domingo
                    if (fechaLlegada.DayOfWeek != DayOfWeek.Saturday && fechaLlegada.DayOfWeek != DayOfWeek.Sunday)
                    {
                        diasContados++;
                    }
                }

                return fechaLlegada;
            }
    }
}

