//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentaCar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Arac
    {
        public int AracID { get; set; }
        public Nullable<int> TipID { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public string Aciklama { get; set; }
        public string Rengi { get; set; }
        public string Vitesi { get; set; }
        public string Gorsel { get; set; }
        public string Fiyati { get; set; }
        public Nullable<int> Onecikanlar { get; set; }
        public Nullable<int> Aktifmi { get; set; }
    
        public virtual tbl_Aracturu tbl_Aracturu { get; set; }
        public virtual tbl_marka tbl_marka { get; set; }
    }
}