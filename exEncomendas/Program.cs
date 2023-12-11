using exEncomendas.Entidades.Enums;
using exEncomendas.Entidades;

namespace exEncomendas
{
    internal class Program
    {
        static List<Client> clientes = new List<Client>();
        static List<Product> produtos = new List<Product>();
        static List<Order> encomendas = new List<Order>();
        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Adicionar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Adicionar Produto");
                Console.WriteLine("4 - Listar Produtos");
                Console.WriteLine("5 - Criar Encomenda");
                Console.WriteLine("6 - Listar Encomendas");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        ListClients();
                        break;
                    case "3":
                        AddProduct();
                        break;
                    case "4":
                        ListProducts();
                        break;
                    case "5":
                        CreateOrder();
                        break;
                    case "6":
                        ListOrders();
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static public void AddClient()
        {
            Console.Write("\n\nNome do Cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Email do Cliente: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento do Cliente (dd/mm/yyyy): ");
            DateTime dn = DateTime.Parse(Console.ReadLine());
            clientes.Add(new Client(nome, email, dn));
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        static public void ListClients()
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (var client in clientes)
                Console.WriteLine(client.ToString());
        }

        static public void AddProduct()
        {
            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.Write("Preço do Produto: ");
            double price = double.Parse(Console.ReadLine());
            produtos.Add(new Product(nome, price));
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        static public void ListProducts()
        {
            Console.WriteLine("Lista de Produtos:");
            foreach (var p in produtos)
                Console.WriteLine(p.ToString());
        }

        static public void CreateOrder()
        {
            Console.Write("Status da Encomenda (0 - Pendente, 1 - Processando, 2 - Em Envio, 3 - Entregue): ");
            OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());
            DateTime dt = DateTime.Now;

            Console.WriteLine("Selecione um Cliente para a Encomenda:");
            for (int i = 0; i < clientes.Count; i++)
                Console.WriteLine($"{i} - {clientes[i].Name}");
            int iCliente = int.Parse(Console.ReadLine());

            if (iCliente >= 0 && iCliente < clientes.Count)
            {
                Order order = new Order(dt, os, clientes[iCliente]);
                encomendas.Add(order);
                bool addingItems = true;
                while (addingItems)
                {
                    Console.Write("Índice do Produto: ");
                    for (int i = 0; i < produtos.Count; i++)
                    {
                        Console.WriteLine($"{i} - {produtos[i].Name}");
                    }
                    int productIndex = int.Parse(Console.ReadLine());
                    if (productIndex >= 0 && productIndex < produtos.Count)
                    {
                        Product p = produtos[productIndex];
                        Console.Write("Quantidade: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Preço: ");
                        double preço = int.Parse(Console.ReadLine());

                        order.AddItem(new OrderItem(p, quantity, preço));
                        Console.WriteLine("Encomenda criada com sucesso!");

                        Console.Write("Adicionar outro item à encomenda? (S/N): ");
                        string response = Console.ReadLine();
                        if (response.ToUpper() != "S")
                            addingItems = false;
                    }
                    else
                    {
                        Console.WriteLine("Índice de produto inválido!");
                    }
                }
            }
            else
                Console.WriteLine("Cliente inválido!");
        }

        static private void ListOrders()
        {
            foreach (Order order in encomendas)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}