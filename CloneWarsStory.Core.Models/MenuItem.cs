using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    public class MenuItem
    {
        private static int ID_GENERATOR = 0;
        
        private readonly int _id;
        private string libelle; // public ?

        public MenuItem(string libelle)
        {
            this._id = ++ ID_GENERATOR;
            this.Libelle = libelle;
        }

        public int Id { get { return this._id; } }

        public string Libelle
        {
            get => this.libelle;
            set => this.libelle = value;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Libelle}";
        }
    }
}
