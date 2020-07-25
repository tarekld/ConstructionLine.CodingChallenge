using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtSize
    {
        public Size Size { get; set; } 

        public Dictionary<Color, ShirtColor> ShirtColors { get; set; }
    }
}
