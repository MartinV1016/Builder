using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Models;
using Builder.Data;

namespace Builder.Services
{
    public class StatCalculator
    {
        public List<Stat> Calculate(Build build)
        {
            List<Stat> calculatedStats = build.Entity.BaseStats.Select(stat => new Stat(stat.Name, stat.Value)).ToList();

            foreach (Mod mod in build.Mods)
            {
                foreach (ModEffect effect in mod.Effects)
                {
                    Stat? affectedStat = calculatedStats.FirstOrDefault(stat => stat.Name == effect.StatMod);

                    if (affectedStat == null)
                    {
                        continue;
                    }

                    switch (effect.Type)
                    {
                        case Modifier.Flat:
                            affectedStat.Value += effect.Value;
                            break;

                        case Modifier.Percent:
                            affectedStat.Value *= (1 + effect.Value / 100);
                            break;
                    }
                }
            }

            return calculatedStats;
        }

        public float CalculateDPS(float damage, float atkspeed) {
            return damage * atkspeed;
        }
    }
}
