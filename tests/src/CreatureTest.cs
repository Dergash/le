using System;
using System.IO;
using LE;

namespace LETest {

    public class CreatureTest : ITest {
        const String sampleMale = @"samples/DRIZZT.cre";
        const String sampleFemale = @"samples/VICONI.cre";

        Creature IdealDrizzt = new Creature {
            Name = "Drizzt Do'Urden",
            ShortName = "Drizzt",
            Strength = 13,
            Dexterity = 20,
            Constitution = 15,
            Intelligence = 17,
            Wisdom = 17,
            Charisma = 14
        };

        public Verbose Verbose {get; set;}

        public CreatureTest() {
            this.Verbose = Verbose.METHODS;
        }

        public bool testAll() {
            var result = true;

            var genderReading = testGenderReading();
            result &= genderReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Gender Reading: " + ((genderReading) ? "SUCCES" : "FAIL"));
            }

            var abilitiesReading = testAbilitiesReading();
            result &= abilitiesReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Abilities Reading: " + ((abilitiesReading) ? "SUCCES" : "FAIL"));
            }

            return result;
        }

        public bool testGenderReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var femaleBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            Creature Viconia = creatureFactory.importFromLegacy(femaleBinary);
            return (Drizzt.Gender == Gender.MALE && Viconia.Gender == Gender.FEMALE);
        }

        public bool testAbilitiesReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            return Drizzt.Strength == IdealDrizzt.Strength
                && Drizzt.Dexterity == IdealDrizzt.Dexterity
                && Drizzt.Constitution == IdealDrizzt.Constitution
                && Drizzt.Intelligence == IdealDrizzt.Intelligence
                && Drizzt.Wisdom == IdealDrizzt.Wisdom
                && Drizzt.Charisma == IdealDrizzt.Charisma;
        }

        public override String ToString() {
            return "Creature class test";
        }
    }
}