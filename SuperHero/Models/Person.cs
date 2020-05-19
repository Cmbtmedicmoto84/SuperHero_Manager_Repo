using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string SuperHeroName { get; set; }

        public string AlterEgo { get; set; }

        public string PrimarySuperPower { get; set; }

        public string SecondarySuperPower { get; set; }

        public string CatchPhrase { get; set; }

    }


}
