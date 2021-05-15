using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilder
{
    public enum WindowMaterial
    {
        Aluminium = 0,
        Vinyl,
        Fiberglass,
        Fibrex
    }
    class Window : IPart
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
