using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL.Biblio.POCO {
    public class LibroDet {
        #region Primitive Properties

        public virtual int Id {
            get;
            set;
        }

        public virtual string Codigo {
            get;
            set;
        }

        public virtual string Titulo {
            get;
            set;
        }

        public virtual string Edicion {
            get;
            set;
        }

        public virtual string Idioma {
            get;
            set;
        }

        public virtual string Observacion {
            get;
            set;
        }

        public virtual int Tipo {
            get;
            set;
        }

        public virtual int Estado {
            get;
            set;
        }

        public virtual string Autor {
            get;
            set;
        }

        public virtual string Editorial {
            get;
            set;
        }

        public virtual string ClasifAbrev {
            get;
            set;
        }

        public virtual int Copias {
            get;
            set;
        }

        #endregion
    }
}
