//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PSS_08_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_User
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int EDAD { get; set; }
        public Nullable<int> C_STATUS { get; set; }
    
        public virtual mSTATUS mSTATUS { get; set; }
    }
}
