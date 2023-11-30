using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades;

namespace Logica.Interfaces
{
    public interface ITransferirCarga<T>
    {
        void TransferirCarga(T operadorDestino, Carga carga);

    }
}
