using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exEncomendas.Entidades.Enums;

namespace exEncomendas.Entidades
{
    internal class Order
    {
        private List<OrderItem> listaItems = new List<OrderItem>();
        private DateTime moment;
        private OrderStatus orderStatus;
        public Client Cliente { get; set; }

        public Order(DateTime moment, OrderStatus orderStatus, Client cliente)
        {
            this.moment = moment;
            this.orderStatus = orderStatus;
            Cliente = cliente;
        }

        public void AddItem(OrderItem item)
        {
            listaItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            listaItems.Remove(item);
        }

        public override string ToString()
        {
            string s = "";
            if (listaItems.Count > 0)
            {
                foreach (OrderItem it in listaItems)
                    s += "\n\t\t" + it.ToString();
            }
            return $"\n\nDados da Encomenda:" +
                $"\nData/Hora da Encomenda: {moment}," +
                $"\nEstado da Encomenda: {(OrderStatus)orderStatus}" +
                $"\nCliente: {Cliente.ToString()}" +
                $"\nItems encomendados: \n{s}";
            

        }
    }
}
