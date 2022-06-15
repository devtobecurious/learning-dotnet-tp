using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public abstract class Personnage : IDeplacement, ICombattant, IEtreVivant
    {
        #region Fields
        protected readonly IProchainPas prochainPas;
        #endregion

        #region Constructors
        public Personnage(string name, IProchainPas prochainPas)
        {
            this.Name = name;
            this.prochainPas = prochainPas;
        }
        #endregion

        #region Public methods
        public virtual void Afficher(Action<object> afficher)
        {
            afficher(this);
        }

        public abstract void SeDeplacer();

        public virtual void Attaquer(ICombattant combattant)
        {
            if (this.IsDifferent(combattant) && combattant is IEtreVivant vivant)
            {
                this.ArmeParDefaut.FaireMal(vivant);
            }
        }

        public override string ToString()
        {
            return "*";
        }

        public bool IsDifferent(ICombattant combattant)
        {
            return this.Equals(combattant);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region Properties
        public string Name { get; set; } = string.Empty;

        public int Id { get; init; }

        public Arme ArmeParDefaut { get; set; }

        public int PointsDeVie { get; set; } = 100;

        public Position CurrentPosition { get; set; }
        #endregion
    }
}
