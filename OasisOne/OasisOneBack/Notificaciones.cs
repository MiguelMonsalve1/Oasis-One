//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OasisOneBack
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notificaciones
    {
        public int Id_Notificacion { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
        public string Mensaje { get; set; }
        public Nullable<System.DateTime> Fecha_Envio { get; set; }
        public Nullable<bool> Leido { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
