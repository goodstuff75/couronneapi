using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Game
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual int Player1 { get; set; }
        public virtual int Player2 { get; set; }
        public virtual int Winner { get; set; }
        public virtual DateTime PlayDate { get; set; }
    }
}
