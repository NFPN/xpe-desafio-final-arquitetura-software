using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasOnline.Dominio.Enums
{
    public enum StatusPedido
    {
        Pendente = 1,
        Processando = 2,
        Enviado = 3,
        Entregue = 4,
        Cancelado = 5
    }
}
