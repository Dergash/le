namespace LE {
    public class Area {

        public Texture Texture;

        public Area() {
            var texture = new Texture("assets/forest.png");
            if (texture.Id != -1) {
                this.Texture = texture;
            }
        }
    }
}
