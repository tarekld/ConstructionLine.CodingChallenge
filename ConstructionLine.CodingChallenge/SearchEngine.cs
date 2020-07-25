using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        
        private readonly List<Shirt> _shirts;
        private readonly ShirtCollection _shirtCollection;
        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
            ShirtCollectionBuilder shirtCollectionBuilder = new ShirtCollectionBuilder();
            _shirtCollection = shirtCollectionBuilder.Build(_shirts);
        }


        public SearchResults Search(SearchOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(Constants.ParamNotProvidedExceptionMessage);

            var searchColors = options.Colors.Count == 0 ? Color.All : options.Colors;
            var searchsizes = options.Sizes.Count==0?Size.All: options.Sizes;

            var searchResul = new SearchResults
            {
                ColorCounts = Color.All.Select(color => new ColorCount { Color = color }).ToList(),
                SizeCounts = Size.All.Select(size => new SizeCount { Size = size }).ToList(),
                Shirts = new List<Shirt>()
            };

            foreach (var size in searchsizes)
            {
                if (_shirtCollection.ShirtSizes.ContainsKey(size))
                {
                    ShirtSize colorSizesShirt = _shirtCollection.ShirtSizes[size];
                    foreach (var color in searchColors)
                    {
                        var colorCount = searchResul.ColorCounts.First(x => x.Color == color);
                        SizeCount sizeCount = searchResul.SizeCounts.First(s => s.Size == size);
                        if (colorSizesShirt.ShirtColors.ContainsKey(color))
                        {

                            searchResul.Shirts.AddRange(colorSizesShirt.ShirtColors[color].Shirts);
                            sizeCount.Count += colorSizesShirt.ShirtColors[color].Shirts.Count;
                            colorCount.Count += colorSizesShirt.ShirtColors[color].Shirts.Count;
                        }
                    }
                }
            }

            return searchResul;
        }
    }
}