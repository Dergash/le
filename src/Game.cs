
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
        public Game(GameContext context) {
            base.Title = "Princess colour";
            this.context = context;
        }
        protected override void OnLoad(EventArgs e) {
            this.cameraPosition = new Vector3(0.0f, 0.0f, 3.0f);
            this.cameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
            this.cameraDirection = OpenTK.Vector3.Normalize(this.cameraPosition - this.cameraTarget);
            this.area = new Area();
            GL.Viewport(0, 0, Width, Height);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Texture2D);
            this.graphics = new Graphics();
        }
        protected override void OnRenderFrame(FrameEventArgs e) {
            this.graphics.ClearBackground();
            if (this.area != null) {
                this.graphics.DrawSprite(this.area.Texture, 0, 0, this.area.Texture.Width, this.area.Texture.Height);
            }
            this.graphics.DrawTextLine("b", 0, 0);
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
        }
        protected override void OnKeyUp(KeyboardKeyEventArgs e) {

        }
    }
}