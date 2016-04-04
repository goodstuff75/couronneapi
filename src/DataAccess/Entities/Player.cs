using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Player
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual List<Game> Games { get; set; }
        public virtual int Wins { get; set; }
    }
}