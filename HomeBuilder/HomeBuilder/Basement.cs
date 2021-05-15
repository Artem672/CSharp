using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilder
{
    enum BasementType
    {
        Tape = 0,
        Columnar,
        Solid
    }
    class Basement : IPart
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
