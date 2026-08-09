using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Models
{
    public enum Modifier
    {
        Flat,
        Percent
    };
    public class ModEffect
    {
        public string StatMod { get; set; }
        
        public Modifier Type { get; set; }
        public float Value { get; set; }
    }
}
