using CloneWarsStory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Tests.Models.Fakes
{
    internal class FakeEtreVivant : IEtreVivant
    {
        public int PointsDeVie { get; set; } = 100;
    }
}
