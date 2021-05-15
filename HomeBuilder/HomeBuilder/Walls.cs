using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilder
{
    public enum WallsMaterial
    {
        Concrete = 0,
        Plastic,
        Ceramic,
        Vinyl
    }
    class Walls : IPart
    {
        public string GetMaterialType(Enum material)
        {
            return $"material :  {material.ToString()}";
        }

        public string GetWorkingPart()
        {
            return $"is working on:  {GetType().Name.ToLower()}";
        }
    }
}
