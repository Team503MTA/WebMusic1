using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMusic.Models.Metadata
{
    [MetadataTypeAttribute(typeof(ARTISTMetadata))]
    public partial class ARTIST
    {
        internal sealed class ARTISTMetadata
        {
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name="Name Artist")]
            public int ID { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Name Song ")]
            public string NAME { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Born ")]
            public string BORN { get; set; }
            
            
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", HtmlEncode = false)]
            [Display(Name = "Date ")]
            [Required(ErrorMessage = "please set data")]
            public Nullable<System.DateTime> DATE { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Description ")]
            public string DESCRIP { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Twitter ")]
            public string TW { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Facebook ")]
            public string FB { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "ID Lable ")]
            public Nullable<short> ID_LABEL { get; set; }
            
            
            [Display(Name = "Image ")]
            public string IMG { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Name Lable ")]
            public string NAME_LABEL { get; set; }
            
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Point Month ")]
            public Nullable<int> POINT_MONTH { get; set; }
           
            
            [Required(ErrorMessage = "please set data")]
            [Display(Name = "Point All ")]
            public Nullable<int> POINT_ALL { get; set; }

            
        }
    }
}