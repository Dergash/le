using System;

namespace LE {
    public enum AbilityType {
        Unknown,
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    public abstract class Ability : GameEntity {
        public readonly AbilityType Type;
        public ushort BaseValue; 
        public ushort EffectiveValue {
            get { return BaseValue; }
        }

        public Ability(AbilityType Type, int BaseValue) {
            this.Type = Type;
            this.BaseValue = (ushort) BaseValue;
        }

        public static bool operator ==(Ability a, Ability b) {
            return (a.EffectiveValue == b.EffectiveValue);
        }

        public static bool operator !=(Ability a, Ability b) {
            return (a.EffectiveValue != b.EffectiveValue);
        }
    }

    public class Strength : Ability {
        public Strength(int BaseValue) : base(AbilityType.Strength, BaseValue) { }
        public static implicit operator Strength(int abilityScore) {
            return new Strength(abilityScore);
        }
    }
    public class Dexterity : Ability {
        public Dexterity(int BaseValue) : base(AbilityType.Dexterity, BaseValue) { }
        public static implicit operator Dexterity(int abilityScore) {
            return new Dexterity(abilityScore);
        }
    }
    public class Constitution : Ability {
        public Constitution(int BaseValue) : base(AbilityType.Constitution, BaseValue) { }
        public static implicit operator Constitution(int abilityScore) {
            return new Constitution(abilityScore);
        }
    }
    public class Intelligence : Ability {
        public Intelligence(int BaseValue) : base(AbilityType.Intelligence, BaseValue) { }
        public static implicit operator Intelligence(int abilityScore) {
            return new Intelligence(abilityScore);
        }
    }
    public class Wisdom : Ability {
        public Wisdom(int BaseValue) : base(AbilityType.Wisdom, BaseValue) { }
        public static implicit operator Wisdom(int abilityScore) {
            return new Wisdom(abilityScore);
        }
    }
    public class Charisma : Ability {
        public Charisma(int BaseValue) : base(AbilityType.Charisma, BaseValue) { }
        public static implicit operator Charisma(int abilityScore) {
            return new Charisma(abilityScore);
        }
    }
}