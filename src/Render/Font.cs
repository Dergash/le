using System;
using SharpFont;

namespace LE {
    public class Font {
        Face face;
        public Font(String pathToFont) {
            Library library = new Library();
            this.face = new Face(library, pathToFont);
        }
        public Face getFont() {
            return this.face;
        }
    }
}