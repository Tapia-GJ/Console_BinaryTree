using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionEstrucAvanzada
{
    public class Services
    {
        ArbolBinario arbol = new ArbolBinario();
        public void menu()
        {
            
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("                         Bienvenido                         ");
            Console.WriteLine("Persiona un número");
            Console.WriteLine("1: Agregar un nuevo libro\n2: Eliminar un libro\n3: Buscar un libro\n4: Mostrar libros en orden de fecha\n5: Limpiar pantalla\n6: Salir");
            string opc = Console.ReadLine();
            int numopc=0;
            if (opc.Length > 1 || int.TryParse(opc, out numopc) == false)
            {
                Console.Clear();
                Console.WriteLine("Ingresa una de las opciones!!!\n");
                menu();
            }
            else
            {
                numopc = int.Parse(opc);
            }
            switch (numopc)
            {
                case 1:
                    Agregar(); Console.Clear(); menu();
                    break;
                case 2:
                    Eliminar(); Console.Clear(); menu();
                    break;
                case 3:
                    Buscar(); menu();
                    break;
                case 4:
                    Mostrar(); menu();
                    break;
                case 5:
                    Console.Clear();
                    menu();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Escribe un numero de los que se muestran");
                    menu();
                    break;
            }
        }
        public void Agregar()
        {
            Console.WriteLine("Escribe el nombre del libro: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escribe la fecha en formato dd-mm-yyyy");
            DateTime fecha = ValidarFecha();
            arbol.Insertar(fecha, nombre);
        }
        public void Eliminar()
        {
            Console.WriteLine("Escribe el nombre del libro: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escribe la fecha en formato dd-mm-yyyy");
            DateTime fecha = ValidarFecha();
            arbol.Eliminar(fecha, nombre);
        }
        public void Buscar()
        {
            Console.WriteLine("Escribe la fecha en formato dd-mm-yyyy");
            DateTime fecha = ValidarFecha();
            arbol.Buscar(fecha);
        }
        public void Mostrar()
        {
            arbol.mostrararbol();
        }
        public void datos()
        {
            string nombre = "Orgullo y Prejuicio";
            DateTime fecha = new DateTime(1813, 01, 28);
            arbol.Insertar(fecha, nombre);
            nombre = "Don Quijote";
            fecha = new DateTime(1605, 01, 16);
            arbol.Insertar(fecha, nombre);
            nombre = "Crimen y Castigo";
            fecha = new DateTime(1866, 01, 12);
            arbol.Insertar(fecha, nombre);
            nombre = "Matar a un Ruiseñor";
            fecha = new DateTime(1960, 07, 11);
            arbol.Insertar(fecha, nombre);
            nombre = "1984";
            fecha = new DateTime(1949, 06, 08);
            arbol.Insertar(fecha, nombre);
            nombre = "Cien Años de Soledad";
            fecha = new DateTime(1967, 05, 30);
            arbol.Insertar(fecha, nombre);
            nombre = "Hamlet";
            fecha = new DateTime(1600, 01, 01);
            arbol.Insertar(fecha, nombre);
            nombre = "Ulises";
            fecha = new DateTime(1922, 02, 02);
            arbol.Insertar(fecha, nombre);
            nombre = "Los miserables";
            fecha = new DateTime(1862, 04, 03);
            arbol.Insertar(fecha, nombre);
            nombre = "Harry Potter y la piedra filosofal";
            fecha = new DateTime(1997, 06, 26);
            arbol.Insertar(fecha, nombre);
            nombre = "El gran Gatsby";
            fecha = new DateTime(1925, 04, 10);
            arbol.Insertar(fecha, nombre);
            nombre = "El Principito";
            fecha = new DateTime(1943, 04, 06);
            arbol.Insertar(fecha, nombre);
            nombre = "Cazadores de sombras: Ciudad de hueso";
            fecha = new DateTime(2007, 03, 27);
            arbol.Insertar(fecha, nombre);
            nombre = "Los juegos del Hambre";
            fecha = new DateTime(2008, 09, 14);
            arbol.Insertar(fecha, nombre);
            nombre = "El nombre de la rosa";
            fecha = new DateTime(1980, 09, 04);
            arbol.Insertar(fecha, nombre);
            nombre = "El retrato de Dorian Gray";
            fecha = new DateTime(1890, 07, 01);
            arbol.Insertar(fecha, nombre);
            nombre = "El Señor de los Anillos: Las dos torres";
            fecha = new DateTime(1954, 11, 11);
            arbol.Insertar(fecha, nombre);
            nombre = "El alquimista";
            fecha = new DateTime(1988, 01, 01);
            arbol.Insertar(fecha, nombre);
            nombre = "Frankenstein";
            fecha = new DateTime(1818, 01, 01);
            arbol.Insertar(fecha, nombre);
            nombre = "Moby-Dick";
            fecha = new DateTime(1851, 10, 18);
            arbol.Insertar(fecha, nombre);
        }

        public DateTime ValidarFecha()
        {
            string validar = Console.ReadLine();
            DateTime fecha;
            if (validar.Length > 10 || DateTime.TryParse(validar, out fecha) == false)
            {
                Console.WriteLine("Ingresa una fecha en el formato dd-mm-yyyy");
                return ValidarFecha();
            }
            fecha = DateTime.Parse(validar);
            return fecha;
        }
    }
}
