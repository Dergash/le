using System;
using System.Collections.Generic;
using NUnit.Framework;

using LE;

namespace LETest {

    [TestFixture]
    public class CharacterImportTest {
        const string sampleBronn = @"tests/samples/BRONN.CHR";
        Creature Bronn = new Creature {
            Gender = Gender.MALE,
            Race = Race.Human,
            Class = new List<Class> { Class.Thief },
            Alignment = Alignment.ChaoticNeutral,
            Strength = 15,
            Dexterity = 17,
            Constitution = 12,
            Intelligence = 12,
            Wisdom = 14,
            Charisma = 13
        };

        [Test]
        public void testBG1CharacterImport() {
            LegacyCharacter bronn = new LegacyCharacter(sampleBronn);
            var bg1Bronn = bronn.getCreature();
            Assert.That(bg1Bronn.Gender == Bronn.Gender
                && bg1Bronn.Race == Bronn.Race
                && (bg1Bronn.Class != null
                    && bg1Bronn.Class.Count == 1
                    && bg1Bronn.Class[0] == Bronn.Class[0])
                && bg1Bronn.Alignment == Bronn.Alignment
                && bg1Bronn.Strength == Bronn.Strength
                && bg1Bronn.Dexterity == Bronn.Dexterity
                && bg1Bronn.Constitution == Bronn.Constitution
                && bg1Bronn.Intelligence == Bronn.Intelligence
                && bg1Bronn.Wisdom == Bronn.Wisdom
                && bg1Bronn.Charisma == Bronn.Charisma);
        }
    }
}