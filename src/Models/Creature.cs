using System;
using System.Collections.Generic;

namespace LE {
    public class Creature : GameObject {
        public String Name;
        public String ShortName;
        public Alignment Alignment;
        public Gender Gender;
        public Race Race;
        public List<Class> Class;
        public Kit Kit;
        public Strength Strength;
        public Dexterity Dexterity;
        public Constitution Constitution;
        public Wisdom Wisdom;
        public Intelligence Intelligence;
        public Charisma Charisma;
        public int Luck;
        public Int16 BaseTHAC0;
        public Int16 NaturalAC;
        public Boolean Fallen;
    }
}