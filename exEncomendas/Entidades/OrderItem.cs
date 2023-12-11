using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEncomendas.Entidades
{
    internal class OrderItem
    {
        public Product Produto { get; set; }
        private int quantity;
        private double price;

        public OrderItem(Product produto, int quantity, double price)
        {
            this.Produto = produto;
            this.quantity = quantity;
            this.price = price;
        }

        public override string ToString()
        {
            return $"\n\nDados do item encomendado: " +
                $"\n\tProduto: {Produto.ToString()}" +
                $"\n\tQuantidade: {quantity}," +
                $"\n\tPreço: {price:f2}";
        }
    }
}
