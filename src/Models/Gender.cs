namespace LE {
    public enum Gender {
        UNKNOWN = -1,
        MALE = 1,
        FEMALE = 2, 
        OTHER = 3,
        NIETHER = 4,
        BOTH = 5
        /* Derg :  Types below are legacy - their should be used only for import purposes:
         * SUMMONED = 6,
         * ILLUSIONARY = 7,
         * EXTRA = 8,
         * SUMMONED_DEMON = 9
         * Our implementation will not store them in 'gender' field
        */
    }
}