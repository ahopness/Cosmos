using System.Numerics;

namespace Platformer
{
    public static class Config
    {
        public const int screenWidth = 256;
        public const int screenHeight = 144;

        public const string windowTitle = "Platformer Demo";
        public const int windowScale = 4;

        public const int targetFPS = 60;

        public static Vector2 gravity = new Vector2( 0, -9.8f );
    }
}