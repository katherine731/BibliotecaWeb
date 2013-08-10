using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL.Biblio.BLL {
    public class Excepcion : Exception {
        public Excepcion(string mensaje, Excepcion innerException)
            : base(mensaje, innerException) {
        }

        public Excepcion()
            : base("", null) {
        }

        public Excepcion(Excepcion innerException)
            : base("", innerException) {
        }

        public Excepcion(string mensaje)
            : base(mensaje, null) {
        }

        public object Valor {
            get;
            set;
        }

        public string AddDetailMensaje() {
            return "Error al intentar adicionar al detalle:\n" + Message;
        }

        public string UpdateDetailMensaje() {
            return "Error al intentar actualizar el detalle:\n" + Message;
        }

        public string DeleteetailMensaje() {
            return "Error al intentar eliminar del detalle:\n" + Message;
        }

        public string GetMensaje() {
            return "Error al intentar obtener el registro:\n" + Message;
        }

        public string CreateMensaje() {
            return "Error al intentar crear el registro:\n" + Message;
        }

        public string UpdateMensaje() {
            return "Error al intentar actualizar el registro:\n" + Message;
        }

        public string DeleteMensaje() {
            return "Error al intentar eliminar el registro:\n" + Message;
        }

        public string LisMensaje() {
            return "Error al intentar listar los registros:\n" + Message;
        }
    }
}
