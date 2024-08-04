using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Practica_C_.Program;

namespace Practica_C_
{
    
    internal class Program
    {
        //Creo una lista para almacenar los personajes
        static List<Personaje> Personajes = new List<Personaje>();
        static void Main(string[] args)
        {
            //Aqui solo es un menu repetitivo
            int op;
            do
            {
                Console.WriteLine("Elegi una opcion:");
                Console.WriteLine("1.Listar Personajes");
                Console.WriteLine("2.Añadir Personaje");
                Console.WriteLine("3.Editar Personaje");
                Console.WriteLine("4.Eliminar Personaje");
                Console.WriteLine("5.Movimiento Personaje");
                Console.WriteLine("0.Salir");

                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Añadir();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:
                        Eliminar();
                        break;
                    case 5:
                        Moverse();
                        break;
                    default:
                        Console.WriteLine("Alegi una pue");
                        break;
                }
            } while(op != 0);
            
            Console.ReadKey();
        }

        public static void Listar()
        {
            Console.WriteLine("Lista de Personajes");
            foreach(var personaje in Personajes)
            {
                Console.WriteLine($"ID: {personaje.Id}, Nombre: {personaje.Nombre}, Descripción: {personaje.Descripcion}, Tipo: {personaje.Tipo}, Acciones: {personaje.Acciones}");
            }
        }

        public static void Añadir()
        {
            Console.WriteLine("Esta Añadiendo");

            int id = 0;
            string Nombre = "", des = "", tipo = "", acciones = "";

            Console.WriteLine("Id:");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre:");
            Nombre = Console.ReadLine();
            Console.WriteLine("Descripcion:");
            des = Console.ReadLine();
            Console.WriteLine("Tipo:");
            tipo = Console.ReadLine();
            Console.WriteLine("Acciones:");
            acciones = Console.ReadLine();

            Personaje personajeNuevo = new Personaje(id,Nombre,des,tipo,acciones);

            Personajes.Add(personajeNuevo);

            Console.WriteLine("Se ha añadido correctamente");
            

        }

        public static void Editar()
        {
            Console.WriteLine("Esta editando");
            Console.WriteLine("Ingrese el id del personaje a editar:");
            int id = int.Parse(Console.ReadLine());

            //el find sirve para buscar un elemento que cumpla con la condicion entre parentecis
            var personaje = Personajes.Find(p => p.Id == id);
            if (personaje != null)
            {
                Console.Write("Nuevo Nombre: ");
                personaje.Nombre = Console.ReadLine();

                Console.Write("Nueva Descripción: ");
                personaje.Descripcion = Console.ReadLine();

                Console.Write("Nuevo Tipo: ");
                personaje.Tipo = Console.ReadLine();

                Console.Write("Nuevas Acciones: ");
                personaje.Acciones = Console.ReadLine();

                Console.WriteLine("Editado exitosamente");
            }
            else
            {
                Console.WriteLine("El personaje no existe");
            }

        }

        public static void Eliminar()
        {
            Console.WriteLine("Eliminar Personaje");
            Console.Write("Ingrese el ID del personaje a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            var personaje = Personajes.Find(p => p.Id == id);

            if (personaje != null)
            {
                //Con el remove se elimina al personaje encontrado
                Personajes.Remove(personaje);
                Console.WriteLine("Personaje eliminado exitosamente");
            }
            else
            {
                Console.WriteLine("El personaje no existe");
            }
        }

        //funcion para hacer que un personaje se mueva
        public static void Moverse()
        {
            Console.WriteLine("Ingresa el id del personaje que quieres mover: ");

            int id = int.Parse(Console.ReadLine());
            var personaje = Personajes.Find(p => p.Id == id);

            if (personaje != null)
            {
                Personaje per = new Personaje(personaje.Id, personaje.Nombre,personaje.Descripcion,personaje.Tipo,personaje.Acciones);
                per.Derecha();
                per.Izquierda();
                per.Saltar();
            }
            else
            {
                Console.WriteLine("El personaje no existe");
            }



        }


        public class Personaje
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set;}
            public string Tipo { get; set;}
            public string Acciones { get; set;}

            public Personaje(int id, string nombre, string descripcion, string tipo, string acciones)
            {
                Id = id;
                Nombre = nombre;
                Descripcion = descripcion;
                Tipo = tipo;
                Acciones = acciones;
            }

            // Estos son los movimientos de los personajes 
            public void Izquierda()
            {
                Console.WriteLine("El personaje " + Nombre + " se esta moviendo a la izquieda");
            }

            public void Derecha()
            {
                Console.WriteLine("El personaje " + Nombre + " se esta moviendo a la derecha");
            }

            public void Saltar()
            {
                Console.WriteLine("El personaje " + Nombre + " esta saltando");
            }

        }

    }
}
