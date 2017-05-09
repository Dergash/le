namespace LE {
    public interface ILegacyFactory<T> where T: GameEntity {
        T importFromLegacy(byte[] binary);
    }
}
