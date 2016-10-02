using System;
using System.IO;
using LE;

namespace LETest {
    public class CreatureImportTest : ITest {
        const String sampleMale = @"tests/samples/DRIZZT.cre";
        const String sampleFemale = @"tests/samples/VICONI.cre";
        const String fallenRanger = @"tests/samples/FALLEN_DRIZZT.cre";
        const String necromancer = @"tests/samples/XZAR.cre";
        Creature IdealDrizzt = new Creature {
            Name = "Drizzt Do'Urden",
            ShortName = "Drizzt",
            Alignment = Alignment.ChaoticGood,
            Strength = 13,
            Dexterity = 20,
            Constitution = 15,
            Intelligence = 17,
            Wisdom = 17,
            Charisma = 14
        };

        public Verbose Verbose {get; set;}

        public CreatureImportTest() {
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

            var alignmentReading = testAlignmentReading();
            result &= alignmentReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Alignment Reading: " + ((alignmentReading) ? "SUCCES" : "FAIL"));
            }

            var fallenReading = testFallenReading();
            result &= fallenReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Fallen Reading: " + ((fallenReading) ? "SUCCES" : "FAIL"));
            }

            var raceReading = testRaceReading();
            result &= raceReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Race Reading: " + ((raceReading) ? "SUCCES" : "FAIL"));
            }

            var classReading = testClassReading();
            result &= classReading;
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Class Reading: " + ((classReading) ? "SUCCES" : "FAIL"));
            }
            
            return result;
        }

        public bool testAlignmentReading() {
            var goodBinary = File.ReadAllBytes(sampleMale);
            var evilBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(goodBinary);
            Creature Viconia = creatureFactory.importFromLegacy(evilBinary);
            return (Drizzt.Alignment == Alignment.ChaoticGood && Viconia.Alignment == Alignment.NeutralEvil);
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

        public bool testFallenReading() {
            var sample = File.ReadAllBytes(fallenRanger);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sample);
            return Drizzt.Fallen == true;
        }

        public bool testRaceReading() {
            var sampleCre = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sampleCre);
            return Drizzt.Race == Race.Elf;
        }

        public bool testClassReading() {
            var sampleCre = File.ReadAllBytes(necromancer);
            var creatureFactory = new CreatureFactory();
            Creature Xzar = creatureFactory.importFromLegacy(sampleCre);
            return Xzar.Class != null
                && Xzar.Class.Count == 1
                && Xzar.Class[0] == Class.Mage
                && Xzar.Kit == Kit.Necromancer;
        }

        public override String ToString() {
            return "Creature class test";
        }
    }
}