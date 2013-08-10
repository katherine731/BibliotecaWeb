using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL.Biblio.Web.Models {
    public class Mensaje {
        public enum TipoMsg {
            normal,
            alerta,
            error
        }

        public Mensaje(string contenido, TipoMsg tipo) {
            Tipo = tipo;
            Contenido = contenido;
        }

        public Mensaje()
            : this("", TipoMsg.normal) {

        }

        public TipoMsg Tipo { get; set; }
        public string Contenido { get; set; }
    }
}
