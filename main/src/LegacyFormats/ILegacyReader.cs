 using System.Collections.Generic;

namespace LE {
    public interface ILegacyReader<T> where T: GameEntity {
        IEnumerable<LegacyField> fields { get; set; }
        T readFromLegacy(byte[] binary);
    }
}
