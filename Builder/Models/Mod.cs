using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Models
{
    

    public class Mod
    {
        public string Name { get; set; }
        public List<ModEffect> Effects { get; set; } = new();

        public override string ToString()
        {
            return Name;
        }

        public string DisplayText
        {
            get
            {
                
                string text=Name;
                foreach (ModEffect effect in Effects) {
                    string TypeText = effect.Type == Modifier.Percent ? "%" : "";
                    text += $"\n+{effect.Value}{TypeText} {effect.StatMod}";
                }

                return text;
            }

        }
    }
}
