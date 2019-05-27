//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projektas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reserver { get; set; }
        public int ReservedSpace { get; set; }
        public Reservation()
        {
        }
        public Reservation(int id)
        {
            this.ReservedSpace = id;
        }

        public virtual Customer Customer { get; set; }
        public virtual EventSpace EventSpace { get; set; }
        public virtual UserOrder UserOrder { get; set; }
    }
}
