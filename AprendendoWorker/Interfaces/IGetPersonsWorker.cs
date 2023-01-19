using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Interfaces
{
    public interface IGetPersonsWorker
    {
        int GetDadosPer();

        int GetDadosPersonagens(ILogger logger);
    }
}
