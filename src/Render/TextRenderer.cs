using System;
using OpenTK;

namespace LE {

    public class TextRenderer {

        Font font;
        Texture letterTexture;

        public TextRenderer(Font font) {
            this.font = font;
            this.font.Color = Color.HotPink;
        }

        public TextRenderer(Font font, Color color) {
            this.font = font;
            this.font.Color = color;
        }

        public  Texture getTextTexture(String text) {
            return getLetterTexture();
        }

        Texture getLetterTexture() {
            var letter = this.font.Atlas['B'];
            return new Texture(letter);
        }

    }
}
