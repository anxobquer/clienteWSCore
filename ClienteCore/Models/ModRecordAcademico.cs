using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Models
{
    public class ModRecordAcademico
    {
        public int anio { get; set; }
        public int ciclo { get; set; }
        public string codMat { get; set; }
        public string matNombre { get; set; }
        //public int uv { get; set; }
        public double nota { get; set; }
        public string estado { get; set; }
        public string periodo { get; set; }
    }
}
