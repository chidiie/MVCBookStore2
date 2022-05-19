using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyBookStore2.Enums;
using MyBookStore2.Helpers;
using Microsoft.AspNetCore.Http;

namespace MyBookStore2.Models
{
    public class BookModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Enter a password")]
        public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter a title")]
        //[MyCustomValidation("abc")]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter an author")]

        public string Author { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        public string Category { get; set; }
        //[Required(ErrorMessage = "Please enter language of book")]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Please enter languages of book")]

        public int? TotalPages { get; set; }
        public string Language { get; set; }
        [Display(Name = "Please select cover page of book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name = "Please select the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
