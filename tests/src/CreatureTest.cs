using System;
using System.IO;
using LE;

namespace LETest {

    public class CreatureTest : ITest {
        const String sampleMale = @"samples/DRIZZDEF.cre";
        const String sampleFemale = @"samples/VICONI.cre";

        public Verbose Verbose {get; set;}

        public CreatureTest() {
            this.Verbose = Verbose.METHODS;
        }

        public bool testAll() {
            var genderReading = testGenderReading();
            if(this.Verbose == Verbose.METHODS) {   
                Console.WriteLine("----Gender Reading: " + ((genderReading) ? "SUCCES" : "FAIL"));
            }
            return genderReading;
        }

        public bool testGenderReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var femaleBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            Creature Viconia = creatureFactory.importFromLegacy(femaleBinary);
            return (Drizzt.Gender == Gender.MALE && Viconia.Gender == Gender.FEMALE);
        }

        public override String ToString() {
            return "Creature class test";
        }
    }
}