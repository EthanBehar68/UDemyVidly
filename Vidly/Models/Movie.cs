﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UDemyVidly.Models
{
    // Standard CLR Object:
    // plain old CLR object (POCO) is a simple object created in the Common Language Runtime (CLR) of the .NET Framework which is unencumbered by inheritance or attributes.
    // https://en.wikipedia.org/wiki/Plain_old_CLR_object
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter the movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        
        // [Required] - This caused an issue within Movies.Controller.Save b/c 
        // Genre = null but Required makes Entity reject null parameter so exception was thrown
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please select the movie's genre.")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Please enter the movie's release date.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please enter how many are in stock.")]
        [Range(1, 20, ErrorMessage = "Please enter a number between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}