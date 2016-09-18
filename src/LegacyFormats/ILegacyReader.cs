 using System.IO;

namespace LE {
    public interface ILegacyReader<T> where T: GameEntity {
        T readFromLegacy(byte[] binary);
    }
}