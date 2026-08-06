using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Data;
using Builder.Models;
using Builder.Services;

namespace Builder.Test
{
    public static class TestRunner
    {
        public static Build Run()
        {
            Debug.WriteLine("App Started");

            Entity selectedEntity = Sample.Entities[1];

            Build build = new Build
            {
                Entity = selectedEntity
            };

            build.Mods.Add(Sample.Mods[0]);
            build.Mods.Add(Sample.Mods[1]);
            build.Mods.Add(Sample.Mods[2]);
            build.Mods.Add(Sample.Mods[3]);
            build.Mods.Add(Sample.Mods[4]);

            StatCalculator calculator = new StatCalculator();

            build.CalculatedStats = calculator.Calculate(build);

            return build;
            

        }
    }
}
