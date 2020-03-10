namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        private float Potential;
        public float potential { get => Potential ;
            set { Potential = value;} }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            UniqueHumanClass();                    
            Potential = _potential;
            StatsSetter();
            SetStats();
            MaxPotential();
        }

        private void MaxPotential()
        {
            if (Potential > 10)
            {
                Potential = 10;
            }

        }
        private void SetStats()
        {
            Attack = (Attack +Attack* (potential / 100));
            Defense = (Defense +Defense * (potential / 100));

            if (Attack > 255)
            {
                Attack = 255;
            }
            if (Defense > 255)
            {
                Defense = 255;
            }
        }
        private void UniqueHumanClass()
        {
            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    break;
                case EUnitClass.Squire:
                    break;
                case EUnitClass.Soldier:
                    break;
                case EUnitClass.Ranger:
                    break;
                case EUnitClass.Mage:
                    break;
                case EUnitClass.Imp:
                    UnitClass = 0;

                    break;
                case EUnitClass.Orc:
                    UnitClass = 0;
                    break;
                case EUnitClass.Dragon:
                    UnitClass = 0;
                    break;
                default:
                    break;
            }


        }
        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool cambiar = false;

            if (UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
            {
                cambiar = true;
            }
            if (UnitClass == EUnitClass.Soldier && newClass == EUnitClass.Squire)
            {
                cambiar = true;
            }
            if (UnitClass == EUnitClass.Mage && newClass == EUnitClass.Ranger)
            {
                cambiar = true;
            }
            if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
            {
                cambiar = true;
            }

            return cambiar;
        }
    }
}