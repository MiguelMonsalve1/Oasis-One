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
    
    public partial class Productos_Proveedor
    {
        public int Id_Producto { get; set; }
        public Nullable<int> Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio_Unitario { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
    }
}
