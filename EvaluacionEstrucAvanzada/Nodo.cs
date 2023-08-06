using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionEstrucAvanzada
{
    public class Nodo
    {
        public string NombreLibro { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Nodo NodoIzquierdo { get; set; }
        public Nodo NodoDerecho { get; set; }

        public Nodo(DateTime FechaPubli, string nombreLibro)
        {
            FechaPublicacion = FechaPubli;
            NodoIzquierdo = null;
            NodoDerecho = null;
            NombreLibro = nombreLibro;
        }
    }
}
