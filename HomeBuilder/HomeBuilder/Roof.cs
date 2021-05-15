using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilder
{
    public enum RoofMaterial
    {
        slate = 0,
        straw
    }
    class Roof : IPart
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
