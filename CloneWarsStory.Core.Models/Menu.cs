using CloneWarsStory.Core.Models.Delegates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    /// <summary>
    /// Menu qui affiche sur la console la liste des items
    /// </summary>
    public class Menu : IList<MenuItem>
    {
        #region Fields
        private List<MenuItem> items;
        #endregion

        #region Constructors
        public Menu() { }

        public Menu(List<MenuItem> items): this()
        {
            this.items = items;
        }

        public Menu(params MenuItem[] items): this(new List<MenuItem>(items))
        {
            // this.items = items;
            // this.Display();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Affiche la liste des items du menu
        /// </summary>
        public void Display(Action<object> action) // DisplayAction action)
        {
            var affichageConsole = (MenuItem item) => action(item);

            // this.items.ForEach(item => affichageConsole?.Invoke(item));            

            this.items.ForEach(affichageConsole);

            //foreach (var item in this.items)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int IndexOf(MenuItem item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, MenuItem item)
        {
            this.items.Insert(index, item); 
        }

        public bool Remove(MenuItem item)
        {
            return this.items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(MenuItem item)
        {
            this.items.Add(item);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(MenuItem item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(MenuItem[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }
        #endregion

        #region Properties
        public MenuItem this[int index] 
        { 
            get => this.items[index]; 
            set => this.items[index] = value; 
        }

        public int Count => this.items.Count;

        public bool IsReadOnly => false;
        #endregion
    }
}
