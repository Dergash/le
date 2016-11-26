namespace LE {
    public struct LegacyField {

        public string name;
        public uint offset;
        public uint size;
        
        public LegacyField(uint offset, uint size, string name) {
            this.name = name;
            this.offset = offset;
            this.size = size;
        }
    }
}
