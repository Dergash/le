/* Thanks to http://gibberlings3.net/iesdp/file_formats/ie_formats/cre_v1.htm */

using System;
using System.Collections.Generic;

namespace LE {
    public class LegacyFields {
        public static readonly String CreatureSignature = "CRE ";
        public static readonly List<LegacyField> CreatureV1_0 = new List<LegacyField> {
            new LegacyField(0x0000, 4, "Signature"), 
            new LegacyField(0x0004, 4, "Version"),
            new LegacyField(0x0008, 4, "LongName"),
            new LegacyField(0x000C, 4, "ShortName"),
            new LegacyField(0x0010, 4, "CreatureFlags"),
            new LegacyField(0x0014, 4, "ExpirienceReward"),
            new LegacyField(0x0018, 4, "PowerLevel"),
            new LegacyField(0x001C, 4, "GoldCarried"),
            new LegacyField(0x0020, 4, "PermanentStatusFlags"),
            new LegacyField(0x0024, 2, "CurrentHitPoints"),
            new LegacyField(0x0026, 2, "MaximumHitPoints"),
            new LegacyField(0x0028, 4, "AnimationId"),
            new LegacyField(0x002C, 1, "MetalColour"),
            new LegacyField(0x002D, 1, "MinorColour"),
            new LegacyField(0x002E, 1, "MajorColour"),
            new LegacyField(0x002F, 1, "SkinColour"),
            new LegacyField(0x0030, 1, "LeatherColour"),
            new LegacyField(0x0031, 1, "ArmorColour"),
            new LegacyField(0x0032, 1, "HairColour"),
            new LegacyField(0x0033, 4, "VersionEff"),
            new LegacyField(0x0034, 8, "SmallPortrait"),
            new LegacyField(0x003C, 8, "LargePortrait"),
            new LegacyField(0x0044, 1, "Reputation"),
            new LegacyField(0x0045, 1, "HideInShadows"),
            new LegacyField(0x0046, 2, "ArmorClassNatural"),
            new LegacyField(0x0048, 2, "ArmorClassEffective"),
            new LegacyField(0x004A, 2, "ArmorClassModifierCrushing"),
            new LegacyField(0x004C, 2, "ArmorClassModifierMissile"),
            new LegacyField(0x004E, 2, "ArmorClassModifierPiercing"),
            new LegacyField(0x0050, 2, "ArmorClassModifierSlashing"),
            new LegacyField(0x0052, 1, "THAC0"),
            new LegacyField(0x0053, 1, "NumberOfAttacks"),
            new LegacyField(0x0054, 1, "SaveVsDeath"),
            new LegacyField(0x0055, 1, "SaveVsWands"),
            new LegacyField(0x0056, 1, "SaveVsPolymorph"),
            new LegacyField(0x0057, 1, "SaveVsBreath"),
            new LegacyField(0x0058, 1, "SaveVsSpells"),
            new LegacyField(0x0059, 1, "ResistFire"),
            new LegacyField(0x005A, 1, "ResistCold"),
            new LegacyField(0x005B, 1, "ResistElectricity"),
            new LegacyField(0x005C, 1, "ResistAcid"),
            new LegacyField(0x005D, 1, "ResistMagic"),
            new LegacyField(0x005E, 1, "ResistMagicFire"),
            new LegacyField(0x005F, 1, "ResistMagicCold"),
            new LegacyField(0x0060, 1, "ResistSlashing"),
            new LegacyField(0x0061, 1, "ResistCrushing"),
            new LegacyField(0x0062, 1, "ResistPiercing"),
            new LegacyField(0x0063, 1, "ResistMissile"),
            new LegacyField(0x0064, 1, "DetectIllusion"),
            new LegacyField(0x0065, 1, "SetTraps"),
            new LegacyField(0x0066, 1, "Lore"),
            new LegacyField(0x0067, 1, "Lockpicking"),
            new LegacyField(0x0068, 1, "Stealth"),
            new LegacyField(0x0069, 1, "FindTraps"),
            new LegacyField(0x006A, 1, "PickPockets"),
            new LegacyField(0x006B, 1, "Fatigue"),
            new LegacyField(0x006C, 1, "Intoxication"),
            new LegacyField(0x006D, 1, "Luck"),
            new LegacyField(0x006E, 1, "ProfiencyLargeSwords"),
            new LegacyField(0x006F, 1, "ProfiencySmallSwords"),
            new LegacyField(0x0070, 1, "ProfiencyBows"),
            new LegacyField(0x0071, 1, "ProfiencySpears"),
            new LegacyField(0x0072, 1, "ProfiencyBlunt"),
            new LegacyField(0x0073, 1, "ProfiencySpiked"),
            new LegacyField(0x0074, 1, "ProfiencyAxe"),
            new LegacyField(0x0075, 1, "ProfiencyMissile"),
            new LegacyField(0x0076, 1, "ProfiencyUnused1"),
            new LegacyField(0x0077, 1, "ProfiencyUnused2"),
            new LegacyField(0x0078, 1, "ProfiencyUnused3"),
            new LegacyField(0x0079, 1, "ProfiencyUnused4"),
            new LegacyField(0x007A, 1, "ProfiencyUnused5"),
            new LegacyField(0x007B, 1, "ProfiencyUnused6"),
            new LegacyField(0x007C, 1, "ProfiencyUnused7"),
            new LegacyField(0x007D, 1, "ProfiencyUnused8"),
            new LegacyField(0x007E, 1, "ProfiencyUnused9"),
            new LegacyField(0x007F, 1, "ProfiencyUnused10"),
            new LegacyField(0x0080, 1, "ProfiencyUnused11"),
            new LegacyField(0x0081, 1, "ProfiencyUnused12"),
            new LegacyField(0x0082, 1, "TurnUndead"),
            new LegacyField(0x0083, 1, "Tracking"),
            new LegacyField(0x0084, 32, "TrackingTarget"), // ??? What the hell is that :)
            new LegacyField(0x00A4, 400, "SounsetLines"),
            new LegacyField(0x0234, 1, "HighestAttainedClass1"),
            new LegacyField(0x0235, 1, "HighestAttainedClass2"),
            new LegacyField(0x0236, 1, "HighestAttainedClass3"),
            new LegacyField(0x0237, 1, "Gender"),
            new LegacyField(0x0238, 1, "Strength"),
            new LegacyField(0x0239, 1, "StrengthExceptional"),
            new LegacyField(0x023A, 1, "Intelligence"),
            new LegacyField(0x023B, 1, "Wisdom"),
            new LegacyField(0x023C, 1, "Dexterity"),
            new LegacyField(0x023D, 1, "Constitution"),
            new LegacyField(0x023E, 1, "Charisma"),
            new LegacyField(0x023F, 1, "Morale"),
            new LegacyField(0x0240, 1, "MoraleBreak"), // Courage?
            new LegacyField(0x0241, 1, "RacialEnemy"),
            new LegacyField(0x0242, 1, "MoraleRecoveryTime"),
            new LegacyField(0x0244, 4, "Kit"),
            new LegacyField(0x0248, 8, "ScriptOverride"),
            new LegacyField(0x0250, 8, "ScriptClass"),
            new LegacyField(0x0258, 8, "ScriptRace"),
            new LegacyField(0x0260, 8, "ScriptGeneral"),
            new LegacyField(0x0268, 8, "ScriptDefault"),
            new LegacyField(0x0270, 8, "EnemyAlly"),
            new LegacyField(0x0271, 1, "General"),
            new LegacyField(0x0272, 1, "Race"),
            new LegacyField(0x0273, 1, "Class"),
            new LegacyField(0x0274, 1, "Specific"),
            new LegacyField(0x0275, 1, "Gender"),
            new LegacyField(0x0276, 5, "ObjectReferences"),
            new LegacyField(0x027B, 1, "Alignment"),
            new LegacyField(0x027C, 2, "GlobalActor"),
            new LegacyField(0x027E, 2, "LocalActor"),
            new LegacyField(0x0280, 32, "DeathVariable"),
            new LegacyField(0x02A0, 4, "KnownSpellsOffset"),
            new LegacyField(0x02A4, 4, "KnownSpellsCount"),
            new LegacyField(0x02A8, 4, "SpellMemorizationInfoOffset"), // Different from memorized spells?
            new LegacyField(0x02AC, 4, "SpellMemorizationInfoCount"),
            new LegacyField(0x02B0, 4, "MemorizedSpellsOffset"),
            new LegacyField(0x02B4, 4, "MemorizedSpellsCount"),
            new LegacyField(0x02B8, 4, "ItemsSlotsOffset"),
            new LegacyField(0x02BC, 4, "ItemsOffset"),
            new LegacyField(0x02C0, 4, "ItemsCount"),
            new LegacyField(0x02C4, 4, "EffectsOffset"),
            new LegacyField(0x02C8, 4, "EffectsCount"),
            new LegacyField(0x02CC, 8, "DialogFile")
        };
    }
}