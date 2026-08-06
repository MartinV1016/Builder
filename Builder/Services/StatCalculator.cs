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

            foreach (Mod mods in build.Mods)
            {
                Stat? affectedStat = calculatedStats.FirstOrDefault(stat => stat.Name == mods.StatMod);

                if (affectedStat == null)
                {
                    continue;
                }

                switch (mods.Type)
                {
                    case Modifier.Flat:
                        affectedStat.Value += mods.Value;
                        break;

                    case Modifier.Percent:
                        affectedStat.Value*= 1 + mods.Value/100;
                        break;
                }
            }

            return calculatedStats;
        }
    }
}
