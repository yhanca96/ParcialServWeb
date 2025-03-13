//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParcialServWeb.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdComputador { get; set; }
        public int IdAgencia { get; set; }
        public System.DateTime FechaVenta { get; set; }
        public decimal Precio { get; set; }
        [JsonIgnore]
        public virtual Agencia Agencia { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        public virtual Computador Computador { get; set; }
    }
}
