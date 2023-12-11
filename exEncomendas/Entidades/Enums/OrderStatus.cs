using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEncomendas.Entidades.Enums
{
    enum OrderStatus : int
    {
        PENDING_PAYMENT = 0,
        PROCESSING = 1,
        SHIPPING = 2,
        DELIVERED = 3
    }
}
