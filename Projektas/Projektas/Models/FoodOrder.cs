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
    
    public partial class FoodOrder
    {
        public int Number_of_people { get; set; }
        public string Order_text { get; set; }
        public int Order_id { get; set; }
        public int UserOrder { get; set; }
        public string Supplier { get; set; }
    
        public virtual UserOrder UserOrder1 { get; set; }
        public virtual FoodSupplier FoodSupplier { get; set; }
    }
}