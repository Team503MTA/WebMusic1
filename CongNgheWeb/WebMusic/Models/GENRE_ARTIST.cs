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
    
    public partial class GENRE_ARTIST
    {
        public int ID_ARTIST { get; set; }
        public short ID_GENRE { get; set; }
        public Nullable<byte> POINT { get; set; }
        public string NAME_GENRE { get; set; }
        public string NAME_LABEL { get; set; }
    
        public virtual ARTIST ARTIST { get; set; }
        public virtual GENRE GENRE { get; set; }
    }
}
