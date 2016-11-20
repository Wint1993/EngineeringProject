using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarriageCart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines {
            get { return lineCollection; }
        }
        public void AddPackstoCarriage(Packs packs, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Packs.PacksID == packs.PacksID).FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine { Packs = packs, Quantity = quantity/*, Waga = waga*/ });

            } else
            {
                line.Quantity += quantity;
               // line.Waga += waga;

            }
        }

        public void RemoveLine (Packs packs)
        {
            lineCollection.RemoveAll(l => l.Packs.PacksID == packs.PacksID);
        }
        public decimal ComputeTotalWeight()
        {
            return lineCollection.Sum(e => e.Packs.Waga * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

    }
    public class CartLine
    {
        public Packs Packs { get; set; }
        public decimal Waga { get; set; }
        public int Quantity { get; set; }
    }
}
