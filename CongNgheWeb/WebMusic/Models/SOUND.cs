//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMusic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SOUND
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<short> LABEL_ID { get; set; }
        public Nullable<System.DateTime> RELEASE_DATE { get; set; }
        public string DATA_SIZE { get; set; }
        public string DESCRIP { get; set; }
        public Nullable<double> COST { get; set; }
        public Nullable<int> POINT_MONTH { get; set; }
        public Nullable<int> POINT_ALL { get; set; }
        public string LINK_IMG { get; set; }
    
        public virtual LABEL LABEL { get; set; }
    }
}
