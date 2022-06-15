using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public class RandomizeProchainPas : IProchainPas
    {
        private static Random random = new Random();

        public bool IsValidPosition(Position position)
        {
            throw new NotImplementedException();
        }

        public Position GetNext()
        {
            int newX = random.Next(0, 2);
            int newY = random.Next(0, 2);

            return new Position() { X = newX, Y = newY };
        }
    }
}
