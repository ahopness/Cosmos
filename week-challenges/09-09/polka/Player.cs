using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace Polka;

public class Player : PSprite
{
    public int[] anmIdle = { 0 };
    public int[] anmJump = { 1 };
    public int[] anmWalk = { 2, 0, 3, 0 };
    public override void Load(GraphicsDevice graphicsDevice)
    {
        position = new Vector2( 256/2, 144/2 );
        sprite = Texture2D.FromFile(graphicsDevice, "Content/Sprites/char.png");
        origin = new Vector2( 4, 8 );
        animated = true;
        anmSlices = 4;
        anmSpeed = 10;
        anm = anmWalk;

        base.Load(graphicsDevice);
    }
}