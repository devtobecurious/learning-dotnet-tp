using CloneWarsStory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.UI.Console
{
    internal class MaPropreRandomizeProchainPas : IProchainPas
    {
        public Position GetNext()
        {
            return new Position() { X = 0, Y = 0 };
        }

        public bool IsValidPosition(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
