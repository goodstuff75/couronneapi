using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
   
    }
}

