using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetStudy.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }   //제목
        public DateTime DateAdded { get; set; }     //입고일
        public DateTime ReleaseDate { get; set; }   //개봉일
        public byte NumberInStock { get; set; }     //재고

        /* Navigation Property */
        [Required]
        public Genre Genre { get; set; }    //장르
        /* FK */
        public byte GenreId {  get; set; }
    }

    /* 
     /movies/random   //movies 컨트롤러의 random 작업
    */
}