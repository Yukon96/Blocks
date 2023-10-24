using PokeTypes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PokeTypes
{
    public class PokeType
    {

        //*******************************PROPERTIES*******************************\\




        public List<PokeType> Immune { get; set; } = new List<PokeType>() { };
        public List<PokeType> QuadWeak { get; set; } = new List<PokeType>() { };
        public List<PokeType> MixedCoverage { get; set; }
        public List<PokeType> Resistances { get; set; }
        public List<PokeType> WeakTo { get; set; }
        public List<PokeType> DealsSuperEffectiveTo
        {
            get
            {
                return FormDSET(ChooseType(Name));
            }
        }
        public string Name { get; set; }




        //***************************************CONSTRUCTORS****************************************\\




        public PokeType(List<PokeType> immune, List<PokeType> weak, List<PokeType> resisted)
        {
            Immune = immune;
            WeakTo = weak;
            Resistances = resisted;

        }
        public PokeType() { }




        //*************************************METHODS***********************************\\



        public static PokeType WeaknessAddedUp(PokeType type1, PokeType type2)
        {
            PokeType mixedResult = new PokeType();

            mixedResult.WeakTo = type1.WeakTo;

            mixedResult.Immune = type1.Immune;
            if (type2 != null)
            {
                foreach (PokeType item in type2.WeakTo)
                {
                    
                    {
                        if (!mixedResult.Immune.Contains(item))
                        {
                            if (mixedResult.WeakTo.Contains(item))
                            {
                                mixedResult.QuadWeak.Add(item);
                                mixedResult.WeakTo.Remove(item);
                            }
                            else if (mixedResult.WeakTo.Contains(item) && type2.Resistances.Contains(item))
                            {

                            }
                            else mixedResult.WeakTo.Add(item);
                        }
                    }
                }
                
                {
                    foreach (PokeType immunity in type2.Immune)
                    {
                        if (type2.Immune != null)
                            mixedResult.Immune.Add(immunity);
                    }
                }
            }

            return mixedResult;
        }


        public static PokeType SuperEffectiveCoverage(PokeType type1, PokeType type2)
        {
            PokeType mixedResult = new PokeType();

            mixedResult.MixedCoverage = type1.DealsSuperEffectiveTo;
            if (type2 != null)
            {
                foreach (PokeType effective in type2.DealsSuperEffectiveTo)
                {

                    if (!mixedResult.MixedCoverage.Contains(effective) && type2.DealsSuperEffectiveTo.Contains(effective))
                    {
                        mixedResult.MixedCoverage.Add(effective);
                    }
                }
            }
            return mixedResult;
        }
        public static PokeType ChooseType(string typeName)
        {
            PokeType result = new PokeType();

            foreach (PokeType item in SummonTypelist())
            {
                if (item.Name.ToUpper() == typeName.ToUpper())
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        public static List<PokeType> SummonTypelist()
        {
            List<PokeType> ListOfTypes = new List<PokeType>
            {
                Bug, Dark, Dragon, Electric, Fairy, Fighting,
                Fire, Flying, Ghost, Grass, Ground, Ice,
                Normal, Poison, Psychic, Rock, Steel, Water
            };

            return ListOfTypes;
        }
        public string GetName()
        {

            return Name;
        }
        public static List<PokeType> FormDSET(PokeType currentType)
        {

            List<PokeType> result = new List<PokeType>();  //result.Add(ChooseType("Flying")); result.Add(ChooseType("water"));
            foreach (PokeType item in SummonTypelist())
            {


                if (item.WeakTo != null)
                {

                    if (item.WeakTo.Contains(currentType))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public List<PokeType> GetDSET()
        {
            return DealsSuperEffectiveTo;
        }
        public List<PokeType> GetWT()
        {
            return WeakTo;
        }
        public List<PokeType> GetRES()
        {
            return Resistances;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
        public static void AssembleTypes()
        {

            Bug.WeakTo = bugW; Bug.Resistances = bugR;
            Dark.WeakTo = darkW; Dark.Resistances = darkR; Dark.Immune = darkI;
            Dragon.WeakTo = dragonW; Dragon.Resistances = dragonR;
            Electric.WeakTo = electricW; Electric.Resistances = electricR;
            Fairy.WeakTo = fairyW; Fairy.Resistances = fairyR; Fairy.Immune = fairyI;
            Fighting.WeakTo = fightingW; Fighting.Resistances = fightingR;
            Fire.WeakTo = fireW; Fire.Resistances = fireR;
            Flying.WeakTo = flyingW; Flying.Resistances = flyingR; Flying.Immune = flyingI;
            Ghost.WeakTo = ghostW; Ghost.Resistances = ghostR; Ghost.Immune = ghostI;
            Grass.WeakTo = grassW; Grass.Resistances = grassR;
            Ground.WeakTo = groundW; Ground.Resistances = groundR; Ground.Immune = groundI;
            Ice.WeakTo = iceW; Ice.Resistances = iceR;
            Normal.WeakTo = normalW; Normal.Resistances = normalR;
            Poison.WeakTo = poisonW; Poison.Resistances = poisonR;
            Psychic.WeakTo = psychicW; Psychic.Resistances = poisonR;
            Rock.WeakTo = rockW; Rock.Resistances = rockR;
            Steel.WeakTo = steelW; Steel.Resistances = steelR; Steel.Immune = steelI;
            Water.WeakTo = waterW; Water.Resistances = waterR;
        }
        public static PokeType ElectricGet()
        {
            return Electric;
        }


        //******************************TYPE LIST**************************************\\


        public static List<PokeType> ListOfTypes = new List<PokeType>
            {
                
                Bug, Dark, Dragon, Electric, Fairy, Fighting,
                Fire, Flying, Ghost, Grass, Ground, Ice,
                Normal, Poison, Psychic, Rock, Steel, Water
            };


        //**********************TYPE INITIALIZATION*************************\\
       

        public static PokeType Bug = new PokeType() { Name = "Bug" };
        public static PokeType Dark = new PokeType() { Name = "Dark" };
        public static PokeType Dragon = new PokeType() { Name = "Dragon" };
        public static PokeType Electric = new PokeType() { Name = "Electric" };
        public static PokeType Fairy = new PokeType() { Name = "Fairy" };
        public static PokeType Fighting = new PokeType() { Name = "Fighting" };
        public static PokeType Fire = new PokeType() { Name = "Fire" };
        public static PokeType Flying = new PokeType() { Name = "Flying" };
        public static PokeType Ghost = new PokeType() { Name = "Ghost" };
        public static PokeType Grass = new PokeType() { Name = "Grass" };
        public static PokeType Ground = new PokeType() { Name = "Ground" };
        public static PokeType Ice = new PokeType() { Name = "Ice" };
        public static PokeType Normal = new PokeType() { Name = "Normal" };
        public static PokeType Poison = new PokeType() { Name = "Poison" };
        public static PokeType Psychic = new PokeType() { Name = "Psychic" };
        public static PokeType Rock = new PokeType() { Name = "Rock" };
        public static PokeType Steel = new PokeType() { Name = "Steel" };
        public static PokeType Water = new PokeType() { Name = "Water" };


       


        //***********************WEAKNESSES********************\\


        public static List<PokeType> NoImmunity = new List<PokeType> { };

        public static List<PokeType> bugW = new List<PokeType> { Fire, Flying, Rock };
        public static List<PokeType> darkW = new List<PokeType> { Bug, Fairy, Fighting };
        public static List<PokeType> dragonW = new List<PokeType> { Dragon, Ice };
        public static List<PokeType> electricW = new List<PokeType> { Ground };
        public static List<PokeType> fairyW = new List<PokeType> { Poison, Steel };
        public static List<PokeType> fightingW = new List<PokeType> { Fairy, Flying, Psychic };
        public static List<PokeType> fireW = new List<PokeType> { Ground, Rock, Water };
        public static List<PokeType> flyingW = new List<PokeType> { Electric, Ice, Rock };
        public static List<PokeType> ghostW = new List<PokeType> { Dark, Ghost };
        public static List<PokeType> grassW = new List<PokeType> { Bug, Fire, Flying, Ice, Poison };
        public static List<PokeType> groundW = new List<PokeType> { Grass, Ice, Water };
        public static List<PokeType> iceW = new List<PokeType> { Fighting, Fire, Rock, Steel };
        public static List<PokeType> normalW = new List<PokeType> { Fighting};
        public static List<PokeType> poisonW = new List<PokeType> { Ground, Psychic };
        public static List<PokeType> psychicW = new List<PokeType> { Bug, Dark, Ghost };
        public static List<PokeType> rockW = new List<PokeType> { Fighting, Grass, Ground, Steel, Water };
        public static List<PokeType> steelW = new List<PokeType> { Fighting, Fire, Ground };
        public static List<PokeType> waterW = new List<PokeType> { Electric, Grass };




        //*********************************RESISTANCES************************************************\\


        public static List<PokeType> bugR = new List<PokeType> { Fighting, Grass, Ground };
        public static List<PokeType> darkR = new List<PokeType> { Dark, Ghost };
        public static List<PokeType> dragonR = new List<PokeType> { Electric, Fire, Grass, Water };
        public static List<PokeType> electricR = new List<PokeType> { Flying, Water };
        public static List<PokeType> fairyR = new List<PokeType> { Bug, Dark, Rock };
        public static List<PokeType> fightingR = new List<PokeType> { Bug, Dark, Rock };
        public static List<PokeType> fireR = new List<PokeType> { Bug, Fairy, Fire, Grass, Ice, Steel };
        public static List<PokeType> flyingR = new List<PokeType> { Bug, Fighting, Grass };
        public static List<PokeType> ghostR = new List<PokeType> { Ghost, Psychic };
        public static List<PokeType> grassR = new List<PokeType> { Ground, Rock, Water };
        public static List<PokeType> groundR = new List<PokeType> { Electric, Fire, Poison, Rock, Steel };
        public static List<PokeType> iceR = new List<PokeType> { Ice };
        public static List<PokeType> normalR = new List<PokeType> { };
        public static List<PokeType> poisonR = new List<PokeType> { Bug, Fairy, Fighting, Grass, Poison };
        public static List<PokeType> psychicR = new List<PokeType> { Fighting, Psychic };
        public static List<PokeType> rockR = new List<PokeType> { Fire, Flying, Normal, Poison };
        public static List<PokeType> steelR = new List<PokeType> { Bug, Dragon, Fairy, Flying, Grass, Ice, Normal, Psychic, Rock, Steel };
        public static List<PokeType> waterR = new List<PokeType> { Fire, Ice, Steel, Water };


        //***************************IMMUNITY******************************\\


        public static List<PokeType> darkI = new List<PokeType> { Psychic };
        public static List<PokeType> fairyI = new List<PokeType> { Dragon };
        public static List<PokeType> flyingI = new List<PokeType> { Ground };
        public static List<PokeType> ghostI = new List<PokeType> { Fighting, Normal };
        public static List<PokeType> groundI = new List<PokeType> { Electric };
        public static List<PokeType> normalI = new List<PokeType> { Ghost };
        public static List<PokeType> steelI = new List<PokeType> { Poison };

    }

}


