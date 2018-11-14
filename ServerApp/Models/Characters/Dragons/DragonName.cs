using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonName
    {
        static public int MinLength => 4;
        static public int MaxLength => 20;

        public int    ActualLength { get => this.Value.Length; }
        public string Value        { get; set; } = String.Empty;
        
    }
}
