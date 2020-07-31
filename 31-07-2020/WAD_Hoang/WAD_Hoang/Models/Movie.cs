//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WAD_Hoang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Title's length must be 3 and 32")]        
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public System.DateTime ReleaseDate { get; set; }
        [Required]
        [Range(60, 140, ErrorMessage = "Running must be 60 and 140 minutes")]        
        public int RunningTime { get; set; }
        public int GenreId { get; set; }

        [Required]
        [RegularExpression("([0-9,\\.]+)")]
        public decimal BoxOffice { get; set; }
    
        public virtual Genre Genre { get; set; }
    }
}
