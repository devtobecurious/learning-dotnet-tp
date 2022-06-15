using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models.Armes
{
    public class PistoLaser : Arme
    {
        public PistoLaser(string name, int couleur) : base(name, 10)
        {
        }

        public override decimal PuissanceReelle => this.Puissance / 2;

        public override void FaireMal(IEtreVivant vivant)
        {
            vivant.PointsDeVie -= (int) this.PuissanceReelle;
        }
    }
}
