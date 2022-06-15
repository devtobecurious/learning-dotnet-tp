using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public class Droide : Personnage
    {
        // private static Random random = new Random();

        public Droide(string name, IProchainPas prochainPas) : base(name, prochainPas)
        {
        }

        public override void SeDeplacer()
        {
            //int newX = random.Next(0, 2);
            //int newY = random.Next(0, 2);

            var position = this.prochainPas.GetNext();

            //this.CurrentPosition.X += newX;
            //this.CurrentPosition.Y += newY;

            this.CurrentPosition.X += position.X;
            this.CurrentPosition.Y += position.Y;
        }

        public override string ToString()
        {
            return "-p-p-";
        }
    }
}
