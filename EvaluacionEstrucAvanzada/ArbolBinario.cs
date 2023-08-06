using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionEstrucAvanzada
{
    public class ArbolBinario
    {
        private Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar(DateTime fecha, string nombre)
        {
            if (raiz == null)
            {
                raiz = new Nodo(fecha, nombre);
            }
            else
            {
                InsertarEnSubarbol(raiz, fecha, nombre);
            }
        }
        private void InsertarEnSubarbol(Nodo nodo, DateTime fecha, string nombre)
        {
            if (DateTime.Compare(fecha, nodo.FechaPublicacion) < 0)
            {


                if (nodo.NodoIzquierdo == null)
                {
                    nodo.NodoIzquierdo = new Nodo(fecha, nombre);


                }
                else
                {

                    InsertarEnSubarbol(nodo.NodoIzquierdo, fecha, nombre);
                }
            }
            else
            {

                if (nodo.NodoDerecho == null)
                {
                    nodo.NodoDerecho = new Nodo(fecha, nombre);

                }
                else
                {

                    InsertarEnSubarbol(nodo.NodoDerecho, fecha, nombre);
                }
            }
        }
        public void mostrararbol()
        {
            MostrarArbolEnConsola(raiz);
        }
        private void MostrarArbolEnConsola(Nodo nodo)
        {
            
            if (nodo != null)
            {
                MostrarArbolEnConsola(nodo.NodoIzquierdo); // Recorre el subárbol izquierdo.
                Console.WriteLine($"Nombre: {nodo.NombreLibro}\nFecha Publicación: {nodo.FechaPublicacion.ToString("dd-MM-yyyy")}"); // Muestra el valor del nodo actual.
                //Console.WriteLine(""nodo.FechaPublicacion.ToString("dd-MM-yyyy") nodo.NombreLibro); // Muestra el valor del nodo actual.
                MostrarArbolEnConsola(nodo.NodoDerecho); // Recorre el subárbol derecho.
            }
        }
        public void Eliminar(DateTime fecha, string nombre)
        {
            raiz = EliminarNodo(raiz, fecha);
        }

        private Nodo EliminarNodo(Nodo nodo, DateTime fecha)
        {
            if (nodo == null)
            {
                return null;
            }

            if (DateTime.Compare(fecha, nodo.FechaPublicacion) < 0)
            {
                nodo.NodoIzquierdo = EliminarNodo(nodo.NodoIzquierdo, fecha);
            }
            else if (DateTime.Compare(fecha, nodo.FechaPublicacion) > 0)
            {
                nodo.NodoDerecho = EliminarNodo(nodo.NodoDerecho, fecha);
            }
            else
            {
                // Caso 1: El nodo a eliminar es una hoja o solo tiene un hijo.
                if (nodo.NodoIzquierdo == null)
                {
                    return nodo.NodoDerecho;
                }
                else if (nodo.NodoDerecho == null)
                {
                    return nodo.NodoIzquierdo;
                }
                Nodo sucesor = EncontrarMinimo(nodo.NodoDerecho);

                // Copiar el valor del sucesor al nodo actual.
                nodo.FechaPublicacion = sucesor.FechaPublicacion;
                nodo.NombreLibro = sucesor.NombreLibro;

                // Eliminar el sucesor del subárbol derecho.
                nodo.NodoDerecho = EliminarNodo(nodo.NodoDerecho, sucesor.FechaPublicacion);
            }

            return nodo;
        }

        private Nodo EncontrarMinimo(Nodo nodo)
        {
            while (nodo.NodoIzquierdo != null)
            {
                nodo = nodo.NodoIzquierdo;
            }
            return nodo;
        }
        public void Buscar(DateTime fecha)
        {
            Console.WriteLine("Nombre: "+BuscarNodo(raiz, fecha).NombreLibro + "\nFecha Publicación: " +BuscarNodo(raiz, fecha).FechaPublicacion);
        }

        private Nodo BuscarNodo(Nodo nodo, DateTime fecha)
        {
            if (nodo == null || nodo.FechaPublicacion == fecha)
            {
                return nodo;
            }

            if (DateTime.Compare(fecha, nodo.FechaPublicacion) < 0)
            {
                return BuscarNodo(nodo.NodoIzquierdo, fecha);
            }
            else
            {
                return BuscarNodo(nodo.NodoDerecho, fecha);
            }
        }

    }
}
