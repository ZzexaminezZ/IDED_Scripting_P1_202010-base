using System;


namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
         private int baseAtk;
         private int baseDef;
         private int baseSpd;
         private int moveRange;
        public int BaseAtk { get => baseAtk ;

             protected set { 
                if (value < 255)
                {
                    baseAtk = value;
                }
                else
                {
                    if (value >= 255)
                    {
                        baseAtk = 255;
                    }
                }
                           
             }
        }
        public int BaseDef { get => baseDef;
            protected set{
                if (value < 255)
                {
                    baseDef = value;
                }
                else
                {
                    if (value >= 255)
                    {
                        baseDef = 255;
                    }
                }

            }
        }
        public int BaseSpd { get => baseSpd;
            protected set
            {
                if (value < 255)
                {
                    baseSpd = value;
                }
                else
                {
                    if (value >= 255)
                    {
                        baseSpd = 255;
                    }
                }
            }
        }

        public int MoveRange { get => moveRange;
            protected set
            {
                moveRange = value;   
            }
        }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }

        public Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }
     

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {



            //Lo ideal para probar este metodo de movimiento es poner estos X y Y como numero conocidos, para compararlos con posiciones 
            //Dentro del
            int x =new Random().Next();
            int y = new Random().Next();
            Position StartPosition = new Position(x, y);
            CurrentPosition = StartPosition;


            UnitClass = _unitClass;
            baseAtk = _atk;
            baseDef = _def;
            baseSpd = _spd;
            moveRange = _moveRange;          
            StatsSetter();
            MaxMovRang();
            
        }

        private void MaxMovRang()
        {
            if (moveRange <0)
            {
                moveRange = 1;

            }
            if (moveRange > 10)
            {
                moveRange = 10;
            }

        }
        public virtual bool Interact(Unit otherUnit)
        {

            bool interactuar = true;
            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    interactuar = false;
                    break;
                case EUnitClass.Squire:
                    if (otherUnit.UnitClass == EUnitClass.Villager)
                    {
                        interactuar =  false;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (otherUnit.UnitClass == EUnitClass.Villager)
                    {
                        interactuar = false;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (otherUnit.UnitClass == EUnitClass.Ranger || otherUnit.UnitClass == EUnitClass.Dragon)
                    {
                        interactuar = false;
                    }
                    break;
                case EUnitClass.Mage:
                    if (otherUnit.UnitClass == EUnitClass.Mage)
                    {
                        interactuar = false;
                    }
                    break;
                case EUnitClass.Imp:
                    if (otherUnit.UnitClass == EUnitClass.Dragon)
                    {
                        interactuar = false;
                    }
                    break;
                case EUnitClass.Orc:
                    if (otherUnit.UnitClass == EUnitClass.Dragon)
                    {
                        interactuar = false;
                    }
                    break;
                case EUnitClass.Dragon:
                    break;
                default:
                    break;
            }

            return interactuar;
        }

        public virtual bool Interact(Prop prop)
        {
            if (UnitClass!= EUnitClass.Villager)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Move(Position targetPosition)
        {
            bool movimiento = false;

            int x = CurrentPosition.x - targetPosition.x;
            int y = CurrentPosition.y - targetPosition.y;

            if ((x >= -(moveRange) && x <= moveRange) && (y >= -(moveRange) && y <= moveRange))
            {
                movimiento = true;
                CurrentPosition = targetPosition;
            }
            else
            {
                movimiento = false;
            }




            return movimiento;
        }


        protected void StatsSetter ()
        {
           

            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    BaseAtkAdd = 0.0f;
                    BaseDefAdd = 0.0F;
                    BaseSpdAdd = 0.0F;
                    AtkRange = 0;
                    break;
                case EUnitClass.Squire:
                    BaseAtkAdd = 0.02F;
                    BaseDefAdd = 0.01F;
                    BaseSpdAdd = 0.00F;
                    AtkRange = 1;
                    break;
                case EUnitClass.Soldier:
                    BaseAtkAdd = 0.03F;
                    BaseDefAdd = 0.02F;
                    BaseSpdAdd = 0.01F;
                    AtkRange = 1;
                    break;
                case EUnitClass.Ranger:
                    BaseAtkAdd = 0.01F;
                    BaseDefAdd = 0.00F;
                    BaseSpdAdd = 0.03F;
                    AtkRange = 3;
                    break;
                case EUnitClass.Mage:
                    BaseAtkAdd = 0.03F;
                    BaseDefAdd = 0.01F;
                    BaseSpdAdd = -0.01F;
                    AtkRange = 3;
                    break;
                case EUnitClass.Imp:
                    BaseAtkAdd = 0.01F;
                    BaseDefAdd = 0.00F;
                    BaseSpdAdd = 0.00F;
                    AtkRange = 1;
                    break;
                case EUnitClass.Orc:
                    BaseAtkAdd = 0.04F;
                    BaseDefAdd = 0.02F;
                    BaseSpdAdd = -0.02F;
                    AtkRange = 1;
                    break;
                case EUnitClass.Dragon:
                    BaseAtkAdd = 0.5F;
                    BaseDefAdd = 0.3F;
                    BaseSpdAdd = 0.2F;
                    AtkRange = 5;
                    break;
                default:
                    break;
            }

            if (UnitClass != EUnitClass.Villager)
            {
                Attack = (baseAtk + (baseAtk * BaseAtkAdd));
                if (Attack > 255)
                {
                    Attack = 255;
                }
                Defense = (baseDef + (baseDef * BaseDefAdd));
                if (Defense > 255)
                {
                    Defense = 255;
                }              
            }
            else
            {
                Attack = 0;
                Defense = 0;
                AtkRange = 0;
            }
            Speed = (baseSpd + (baseSpd * BaseSpdAdd));
            if (Speed > 255)
            {
                Speed = 255;
            }


        }
    }
}