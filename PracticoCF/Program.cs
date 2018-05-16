using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

namespace PracticoCF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RestaurantContext db = new RestaurantContext())
            {
                string exit = string.Empty;

                while (exit != "0")
                {
                    // Crear y Guardar Clientes y Direcciones
                    Console.WriteLine("Ingrese el nombre del cliente: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Ingrese el apellido del cliente: ");
                    string lastname = Console.ReadLine();

                    Console.WriteLine("Ingrese la cedula del cliente: ");
                    string idCard = Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre de calle del cliente: ");
                    string streetName = Console.ReadLine();

                    Console.WriteLine("Ingrese el numero de casa del cliente: ");
                    int streetNumber = int.Parse(Console.ReadLine());

                    Client client = new Client();
                    client.name = name;
                    client.lastname = lastname;
                    client.idCard = idCard;

                    Address address = new Address();
                    address.streetName = streetName;
                    address.streetNumber = streetNumber;
                    address.theClient = client;

                    client.addresses.Add(address);
                    db.clients.Add(client); // Agrega a la DB
                    db.SaveChanges();

                    Console.WriteLine("Para salir ingrese '0'. Ingrese cualquier otra tecla para ingresar otro cliente");
                    exit = Console.ReadLine();

                    IEnumerable<Client> clients = from c in db.clients
                                                  orderby c.lastname, c.name
                                                  select c;

                    Console.WriteLine("-----> Todos los Clientes <-----");
                    foreach (Client theC in clients)
                    {
                        Console.WriteLine($"{theC.name} {theC.lastname}");
                        Console.WriteLine("");
                        Console.WriteLine("--> Direcciones <--");
                        foreach (Address theA in theC.addresses)
                        {
                            Console.WriteLine($"{theA.streetName} {theA.streetNumber}");
                        }

                        Console.WriteLine("Presione una tecla para salir...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
