using System;
using OpenTK;

namespace LE {
    public class TextRenderer {

        Font font;
        Texture letterTexture;
        SpriteRenderer renderer;

        public TextRenderer(Font font, SpriteRenderer renderer) {
            this.font = font;
            this.font.Color = Color.HotPink;
            this.renderer = renderer;
        }

        public TextRenderer(Font font, Color color, SpriteRenderer renderer) {
            this.font = font;
            this.font.Color = color;
            this.renderer = renderer;
        }

        public void DrawTextLine(string text, int x, int y) {
            if (text.Length > 1) {
                throw new NotImplementedException();
            }
            var texture = this.getTextTexture(text);
            renderer.DrawSprite(texture, x, y, texture.Width, texture.Height, 0);
        }

        public Texture getTextTexture(String text) {
            return getLetterTexture(text[0]);
        }

        Texture getLetterTexture(Char character) {
            var letter = this.font.Atlas[character];
            return new Texture(letter);
        }
    }
}
