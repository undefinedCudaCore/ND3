using System;
using System.Collections.Generic;
using System.Linq;

namespace ND3
{
    class Program
    {
        static void Main(string[] args)
        {
			var items = new List<SellableItem>()
			{
				new SellableItem()
				{
					Id = 1,
					Name = "Sellable1"
				},
				new SellableItem()
				{
					Id = 2,
					Name = "Sellable2"
				},
				new SellableItem()
				{
					Id = 3,
					Name = "Sellable3"
				},
				new SellableItem()
				{
					Id = 12,
					Name = "Sellable3"
				}
			};

			var linqIds = items.Where(item => item.Name == "Sellable3").Select(item => item.Id).ToList();

			var a = 0;
		}
    }
}
