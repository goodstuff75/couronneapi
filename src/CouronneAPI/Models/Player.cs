using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CouronneAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public List<Game> Games { get; set; }
        public int Wins { get; set; }
    }
}