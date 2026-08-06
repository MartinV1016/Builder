using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Models
{
    public class Stat
    {
        public string Name { get; set; }
        public float Value { get; set; }

        public Stat(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}
