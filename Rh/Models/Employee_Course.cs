//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee_Course
    {
        public int ID_EMPLEADO_CURSO { get; set; }
        public Nullable<int> ID_EMPLEADO { get; set; }
        public Nullable<int> ID_CURSO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> CALIFICACION { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
