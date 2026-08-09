using Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Data
{
    public static class Sample
    {
        public static List<Entity> Entities = new()
        {
            new Entity
            {
                Name="Braton",

                BaseStats = new()
                {
                    new Stat("Damage",100),
                    new Stat("Crit",30),
                    new Stat("Status",10),
                    new Stat("Fire Rate",9.58f)
                }
            },
            new Entity
            {
                Name="Paris",

                BaseStats = new()
                {
                    new Stat("Damage",120),
                    new Stat("Crit",35),
                    new Stat("Status",10),
                    new Stat("Fire Rate",1.0f)
                }
            },
        };
        public static List<Mod> Mods = new()
        {
            new Mod
            {
                Name="Serration",
                Effects=
                {
                    new ModEffect
                    {
                        StatMod="Damage",
                        Type=Modifier.Percent,
                        Value=90
                    }
                }
            },
            new Mod
            {
                Name="Caliber",
                Effects=
                {
                    new ModEffect
                    {
                        StatMod="Damage",
                        Type=Modifier.Flat,
                        Value=50
                    }
                }
            },
            new Mod
            {
                Name="Aptitude",
                Effects=
                {
                    new ModEffect
                    {
                        StatMod="Status",
                        Type=Modifier.Percent,
                        Value=30
                    }
                }
            },
            new Mod
            {
                Name="Broken Aptititude",
                Effects =
                {
                    new ModEffect
                    {
                        StatMod="Status",
                        Type=Modifier.Flat,
                        Value=5 
                    } 
                }

            },
            new Mod
            {
                Name="Strike",
                Effects= 
                {
                    new ModEffect
                    {
                        StatMod="Crit",
                        Type=Modifier.Percent,
                        Value=50
                    }
                }
            },
            new Mod
            {
                Name="Heavy",
                Effects =
                {
                    new ModEffect
                    {
                        StatMod="Damage",
                        Type=Modifier.Flat,
                        Value=25
                    },
                    new ModEffect
                    {
                        StatMod="Fire Rate",
                        Type=Modifier.Percent,
                        Value=45
                    }
                }
            }
        };

    }
}
