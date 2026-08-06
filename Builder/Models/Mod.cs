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
    }

    public class Mod
    {
        public string Name { get; set; }
        public string StatMod { get; set; }
        public Modifier Type { get; set; }
        public float Value { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string DisplayText
        {
            get
            {
                string TypeText = Type == Modifier.Percent ? "%" : "";
                return $"{Name}\n+{Value}{TypeText} {StatMod}";
            }

        }
    }
}
