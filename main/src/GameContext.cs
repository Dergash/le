using System;

namespace LE {
    public class GameContext {

        static GameContext context;
        
        public bool ShowFPS { get; set; }
        public ILogger logger;

        private GameContext() {
            this.logger = new ConsoleLogger();
        }
        
        public static GameContext getInstance() {
            if (GameContext.context == null) {
                GameContext.context = new GameContext();
            }
            return GameContext.context;
        }

        const String pathToFont = @"assets\fonts\Now-Regular.otf";
        Font font;

        public Font getFont() {
            if (font == null) {
                try {
                    this.font = new Font(pathToFont);
                    this.font.initAtlas(16);
                } catch (Exception e) {
                    GameContext.getInstance().logger.WriteException(e);
                    return null;
                }
            }
            return font;
        }

    }
}
