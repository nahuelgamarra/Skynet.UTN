using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public interface ITransferirCarga<T>
    {
        void  TransferirCarga(T operadorDestino, Carga carga);
    }
}
