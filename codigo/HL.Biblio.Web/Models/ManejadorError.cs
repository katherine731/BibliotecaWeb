using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HL.Biblio.Web.Models {
    public class ManejadorError {
        public ManejadorError(Exception ex) {
            if(!string.IsNullOrEmpty(ex.Message))
                Mensaje = ex.Message;
            if(ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                ExcepcionOrigen = ex.InnerException.Message;
            if(!string.IsNullOrEmpty(ex.Source))
                Origen = ex.Source;
            if(!string.IsNullOrEmpty(ex.StackTrace))
                EstadoPila = ex.StackTrace;
            if(ex.TargetSite != null && !string.IsNullOrEmpty(ex.TargetSite.ToString()))
                Sitio = ex.TargetSite.ToString();
        }

        public ManejadorError(string mensaje, string excepcionOrigen, string origen, string estadoPila, string sitio) {
            Mensaje = mensaje;
            Origen = origen;
            EstadoPila = estadoPila;
            Sitio = sitio;
            ExcepcionOrigen = excepcionOrigen;
        }

        public string Mensaje { get; set; }
        public string Origen { get; set; }
        public string EstadoPila { get; set; }
        public string Sitio { get; set; }
        public string ExcepcionOrigen { get; set; }
    }

}