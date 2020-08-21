using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_book
{
    public class Recipe
    {
        public int Id { get; set; }
        public Categories Category { get; set; }
        public string Name { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public string Description { get; set; }
    }
}
