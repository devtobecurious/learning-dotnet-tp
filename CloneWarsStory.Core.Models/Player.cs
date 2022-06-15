using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    /// <summary>
    /// Représente le joueur dans le jeu, 
    /// contient toutes les informations spécifiques à ce joueur
    /// (pseudo, age, ...)
    /// </summary>
    public class Player
    {
        private static int ID_GENERATOR = 0;
        private string _name;
        private int _id;
        private DateTime dateNaissance;

        public Player() { }

        public Player(string name, DateOnly dateNaissance)
        {
            this._id = ++ID_GENERATOR;

            this.Name = name;

            this.DateOnlyNaissance = dateNaissance;
        }

        public string Name
        {
            get { return _name; }
            set 
            { 
                if (! string.IsNullOrEmpty(value))
                {
                    _name = value; 
                }
            }
        }

        [Key]
        public int Id
        {
            get
            {
                return this._id;
            }
            set => this._id = value;
        }

        [NotMapped]
        public Personnage PersonnagePrincipale { get; set; }

        public string DateNaissanceFormattee
        {
            get => this.DateNaissance.ToShortDateString();
        }

        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public DateOnly DateOnlyNaissance 
        { 
            get => DateOnly.FromDateTime(this.dateNaissance);
            init => this.dateNaissance = value.ToDateTime(new TimeOnly());
        }
    }
}
