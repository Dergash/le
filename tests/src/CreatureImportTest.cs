using System;
using System.IO;
//using NUnit.Framework;
using LE;

namespace LETest {
   // [TestFixture]
    public class CreatureImportTest {

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

        //[Test]
        public void testAlignmentReading() {
            var goodBinary = File.ReadAllBytes(sampleMale);
            var evilBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(goodBinary);
            Creature Viconia = creatureFactory.importFromLegacy(evilBinary);
            //Assert.That(Drizzt.Alignment == Alignment.ChaoticGood && Viconia.Alignment == Alignment.NeutralEvil);
        }

        // [Test]
        public void testGenderReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var femaleBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            Creature Viconia = creatureFactory.importFromLegacy(femaleBinary);
           // Assert.That((Drizzt.Gender == Gender.MALE && Viconia.Gender == Gender.FEMALE));
        }

        // [Test]
        public void testAbilitiesReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
          /*  Assert.That(Drizzt.Strength == IdealDrizzt.Strength
                && Drizzt.Dexterity == IdealDrizzt.Dexterity
                && Drizzt.Constitution == IdealDrizzt.Constitution
                && Drizzt.Intelligence == IdealDrizzt.Intelligence
                && Drizzt.Wisdom == IdealDrizzt.Wisdom
                && Drizzt.Charisma == IdealDrizzt.Charisma);*/
        }

        // [Test]
        public void testFallenReading() {
            var sample = File.ReadAllBytes(fallenRanger);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sample);
            // Assert.IsTrue(Drizzt.Fallen);
        }


        // [Test]
        public void testRaceReading() {
            var sampleCre = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sampleCre);
            // Assert.AreEqual(Drizzt.Race, Race.Elf);
        }

        // [Test]
        public void testClassReading() {
            var sampleCre = File.ReadAllBytes(necromancer);
            var creatureFactory = new CreatureFactory();
            Creature Xzar = creatureFactory.importFromLegacy(sampleCre);
           /* Assert.That(Xzar.Class != null
                && Xzar.Class.Count == 1
                && Xzar.Class[0] == Class.Mage
                && Xzar.Kit == Kit.Necromancer); */
        }
    }
}
