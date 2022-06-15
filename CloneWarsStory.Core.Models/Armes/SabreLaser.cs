using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models.Armes
{
    public class SabreLaser : Arme
    {
        public SabreLaser(string name, decimal puissance) : base(name, puissance)
        {
        }

        public override decimal PuissanceReelle => this.Puissance * 2;

        public override void FaireMal(IEtreVivant vivant)
        {
            vivant.PointsDeVie -= (int)this.PuissanceReelle;
            if (vivant.PointsDeVie < 0)
            {
                vivant.PointsDeVie = 0;
            }
        }
    }
}
