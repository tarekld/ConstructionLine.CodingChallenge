using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{

    public class ShirtCollectionBuilder
    {

        public ShirtCollection Build(List<Shirt> shirts)
        {
            ShirtCollection shirtCollection = new ShirtCollection() { ShirtSizes = new Dictionary<Size, ShirtSize>() };

            if (shirts == null || shirts.Count == 0)
                return shirtCollection;


            foreach (var shirt in shirts)
            {
                if (!shirtCollection.ShirtSizes.ContainsKey(shirt.Size))
                {
                    shirtCollection.ShirtSizes.Add(shirt.Size, new ShirtSize()
                    {
                        Size = shirt.Size,
                        ShirtColors = new Dictionary<Color, ShirtColor>()
                    });
                }

                ShirtSize shirtSize = shirtCollection.ShirtSizes[shirt.Size];
                if (!shirtSize.ShirtColors.ContainsKey(shirt.Color))
                {
                    shirtSize.ShirtColors.Add(shirt.Color,
                        new ShirtColor()
                        {
                            Color = shirt.Color,
                            Shirts = new List<Shirt>()
                        });
                }
                ShirtColor shirtColor = shirtSize.ShirtColors[shirt.Color];
                shirtColor.Shirts.Add(shirt);

            }
            return shirtCollection;

        }
    }
}
