using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Models
{
    public class Build
    {
        public Entity Entity { get; set; }

        public List<Mod> Mods { get; set; }=new List<Mod>();

        public List<Stat> CalculatedStats { get; set; } =new List<Stat>();
    }
}
