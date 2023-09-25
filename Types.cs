using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTypes
{
    public class PokeType
    {
        //properties
        public List<string> weakTo { get; set; }
        public List<string> dealsSupperEffective { get; set; }

        //constuctor
        public PokeType() { }
        /* public PokeType(List<string> weak, List<string> super)
         {
             {
                 weakTo = weak;
                 dealsSupperEffective = super;
             }*/
        //methods
        public PokeType WeaknessAddedUp(PokeType type1, PokeType type2)
        {
            PokeType mixedResult = new PokeType();


            foreach (string weak in type1.weakTo)
            {
                mixedResult.weakTo.Add("x2 " + weak);
            }

            if (type2 != null)
            {
                foreach (string weakTo in type2.weakTo)
                {

                    if (mixedResult.weakTo.Contains("x2 " + weakTo) && type2.weakTo.Contains("x2 " + weakTo))
                    {
                        mixedResult.weakTo.Add("x4 " + weakTo);
                        mixedResult.weakTo.Remove("x2 " + weakTo);
                    }
                    else
                        mixedResult.weakTo.Add("x2 " + weakTo);
                }
            }

            return mixedResult;
        }




        PokeType SuperEffectiveCoverage(PokeType type1, PokeType type2)
        {
            PokeType mixedResult = new PokeType();

            mixedResult.dealsSupperEffective = type1.dealsSupperEffective;
            if (type2 != null)
            {
                foreach (string effective in type2.dealsSupperEffective)
                {

                    if (mixedResult.dealsSupperEffective.Contains("x2 " + weakTo) && type2.dealsSupperEffective.Contains("x2 " + weakTo))
                    {
                        mixedResult.dealsSupperEffective.Add("x2 " + weakTo);

                    }
                    else
                        mixedResult.dealsSupperEffective.Add("x2 " + weakTo);
                }
            }
            return mixedResult;





        }
    }
}

