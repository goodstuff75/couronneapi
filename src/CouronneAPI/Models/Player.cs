using System;
using System.Collections.Generic;

namespace CouronneAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public List<Game> Games { get; set; }
        public int Wins { get; set; }
    }
}