using CloneWarsStory.Core.Models.Armes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public abstract class Arme : IInfligerDegat
    {
        #region Fields
        private static int ID = 0;
        #endregion

        #region Constructors
        public Arme(string name, decimal puissance)
        {
            this.Id = ++ Arme.ID;
            this.Name = name;
            this.Puissance = puissance;
        }
        #endregion

        #region Public methods
        public abstract void FaireMal(IEtreVivant vivant);
        #endregion

        #region Properties
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public decimal Puissance { get; init; } = 50.5M;

        public abstract decimal PuissanceReelle { get; }
        #endregion
    }
}
