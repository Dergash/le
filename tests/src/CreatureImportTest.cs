using System;
using System.IO;
using Xunit;
using LE;

namespace LETest {
    public class CreatureImportTest {

        const String sampleMale = @"samples/DRIZZT.cre";
        const String sampleFemale = @"samples/VICONI.cre";
        const String fallenRanger = @"samples/FALLEN_DRIZZT.cre";
        const String necromancer = @"samples/XZAR.cre";
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

        [Fact]
        public void testAlignmentReading() {
            var goodBinary = File.ReadAllBytes(sampleMale);
            var evilBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(goodBinary);
            Creature Viconia = creatureFactory.importFromLegacy(evilBinary);
            Assert.True(Drizzt.Alignment == Alignment.ChaoticGood && Viconia.Alignment == Alignment.NeutralEvil);
        }

        [Fact]
        public void testGenderReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var femaleBinary = File.ReadAllBytes(sampleFemale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            Creature Viconia = creatureFactory.importFromLegacy(femaleBinary);
            Assert.True((Drizzt.Gender == Gender.MALE && Viconia.Gender == Gender.FEMALE));
        }

        [Fact]
        public void testAbilitiesReading() {
            var maleBinary = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(maleBinary);
            Assert.True(Drizzt.Strength == IdealDrizzt.Strength
                && Drizzt.Dexterity == IdealDrizzt.Dexterity
                && Drizzt.Constitution == IdealDrizzt.Constitution
                && Drizzt.Intelligence == IdealDrizzt.Intelligence
                && Drizzt.Wisdom == IdealDrizzt.Wisdom
                && Drizzt.Charisma == IdealDrizzt.Charisma);
        }

        [Fact]
        public void testFallenReading() {
            var sample = File.ReadAllBytes(fallenRanger);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sample);
            Assert.True(Drizzt.Fallen);
        }


        [Fact]
        public void testRaceReading() {
            var sampleCre = File.ReadAllBytes(sampleMale);
            var creatureFactory = new CreatureFactory();
            Creature Drizzt = creatureFactory.importFromLegacy(sampleCre);
            Assert.Equal(Drizzt.Race, Race.Elf);
        }

        [Fact]
        public void testClassReading() {
            var sampleCre = File.ReadAllBytes(necromancer);
            var creatureFactory = new CreatureFactory();
            Creature Xzar = creatureFactory.importFromLegacy(sampleCre);
            Assert.True(Xzar.Class != null
                && Xzar.Class.Count == 1
                && Xzar.Class[0] == Class.Mage
                && Xzar.Kit == Kit.Necromancer);
        }
    }
}
