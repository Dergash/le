
using System;

using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class Game : GameWindow {

        GameContext context;
        Graphics graphics;
        Area area;
        Vector3 cameraPosition;
        Vector3 cameraTarget;
        Vector3 cameraDirection;

        SpriteRenderer renderer;
        TextRenderer textRenderer;
        Texture player;

        public Game(GameContext context) {
            base.Title = "Princess colour";
            this.context = context;
        }

        protected override void OnLoad(EventArgs e) {
            VSync = VSyncMode.On;
            this.cameraPosition = new Vector3(0.0f, 0.0f, 3.0f);
            this.cameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
            this.cameraDirection = OpenTK.Vector3.Normalize(this.cameraPosition - this.cameraTarget);
            this.area = new Area();
            this.graphics = new Graphics();
            this.renderer = new SpriteRenderer(graphics.getAreaShader());
            this.renderer.SetProjection(Width, Height);

            Font font = GameContext.getInstance().getFont();
            this.textRenderer = new TextRenderer(font, Color.White, this.renderer);

            player = new Texture(@"assets\player.png");
            GL.Viewport(0, 0, Width, Height);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Texture2D);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            this.graphics.ClearBackground();
            if (this.area != null) {
                this.renderer.DrawSprite(this.area.Texture, 0, 0, this.area.Texture.Width, this.area.Texture.Height, 0.0f);
            }
            this.SwapBuffers();
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            this.graphics.ClearBackground();
            if (this.area != null) {
                this.renderer.DrawSprite(this.area.Texture, 0, 0, this.area.Texture.Width, this.area.Texture.Height, 0.0f);
            }
            renderPlayer();
            renderFPS(1.0f / e.Time);
            this.SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e) {
            if (e.Key == Key.Escape) {
                this.Exit();
            }
            if (e.Key == Key.F5) {
                this.WindowState = (this.WindowState == WindowState.Fullscreen)
                    ? WindowState.Normal
                    : WindowState.Fullscreen;
            }
            if (e.Key == Key.F12) {
                this.context.ShowFPS = !this.context.ShowFPS;
            }
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e) {

        }

        void renderPlayer() {
            renderer.DrawSprite(player, 100, 100, player.Width, player.Height, 0);
        }

        // TODO :: Change when text renderer ready
        void renderFPS(double fps) {
            if (!this.context.ShowFPS) {
                return;
            }
            String fpsText = fps.ToString();
            this.textRenderer.DrawTextLine("F", 10, 10);
            this.textRenderer.DrawTextLine("P", 30, 10);
            this.textRenderer.DrawTextLine("S", 50, 10);
            if (fpsText.Length > 0) {
                this.textRenderer.DrawTextLine(fpsText[0].ToString(), 70, 10);
            }
            if (fpsText.Length > 1) {
                this.textRenderer.DrawTextLine(fpsText[1].ToString(), 90, 10);
            }
        }
    }
}
