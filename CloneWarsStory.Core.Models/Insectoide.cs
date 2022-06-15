using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public class Insectoide : Personnage
    {
        public Insectoide(string name, IProchainPas prochainPas) : base(name, prochainPas)
        {
        }

        public override void SeDeplacer()
        {
            throw new NotImplementedException();
        }
    }
}
