using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public class StormTrooper : Personnage
    {
        public StormTrooper(string name, IProchainPas prochainPas) : base(name, prochainPas)
        {
        }

        public override void SeDeplacer()
        {
            
        }

        public override string ToString()
        {
            return "=o-o=";
        }
    }
}
