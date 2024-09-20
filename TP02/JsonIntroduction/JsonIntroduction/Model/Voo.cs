using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonIntroduction.Model
{
    public class Voo
    {
        public string codigo { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public string horario { get; set; }
        public string companhia { get; set; }
        public string operando { get; set; }
    }
}