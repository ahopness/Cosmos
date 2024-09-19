using Raylib_CSharp;
using Raylib_CSharp.Camera.Cam2D;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Logging;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Windowing;

using static Platformer.Config;

namespace Platformer
{
    public class Game : IDisposable
    {
        public static Game Instance { get; private set; }

        public static Scene currentScene;

        public void Run() 
        {
            // Inicialização
            int windowWidth = screenWidth * windowScale;
            int windowHeight = screenHeight * windowScale;

            Logger.SetTraceLogLevel( TraceLogLevel.Error );
            Raylib.SetConfigFlags( ConfigFlags.VSyncHint );
            Window.Init( windowWidth, windowHeight, windowTitle );
            
            Time.SetTargetFPS( targetFPS );

            Camera2D viewport = new Camera2D();
            viewport.Zoom = windowScale;

            // Criação da cena
            currentScene = new Map();

            // Game Loop
            currentScene.Create();

            while (!Window.ShouldClose())
            {
                currentScene.Update( Time.GetFrameTime() );

                Graphics.BeginDrawing();
                Graphics.ClearBackground( Color.Black );

                    Graphics.BeginMode2D(viewport);

                    currentScene.Draw();

                    Graphics.EndMode2D();

                Graphics.EndDrawing();
            }
        }

        public void Dispose() 
        {
            // Finalização
            currentScene.Dispose();
            Window.Close();
        }

        public void ChangeScene(Scene scene)
        {
            currentScene.Dispose();
            currentScene = scene;
            currentScene.Create();
        }
    }
}