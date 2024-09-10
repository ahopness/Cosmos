using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace sprtest;

public class SpriteTest : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RenderTarget2D _renderTarget;
    public SpriteTest()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "res";
        IsMouseVisible = true;
    }

    const int SCREEN_WIDTH = 160;
    const int SCREEN_HEIGHT = 120;
    const int WIN_SCALE = 4;
    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = SCREEN_WIDTH * WIN_SCALE;
        _graphics.PreferredBackBufferHeight = SCREEN_HEIGHT * WIN_SCALE;
        _graphics.ApplyChanges();

        _renderTarget = new RenderTarget2D(GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);

        base.Initialize();
    }

    Texture2D spr_bg;
    Texture2D spr_char;
    Texture2D spr_overlay;
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        spr_bg = Texture2D.FromFile(GraphicsDevice, "res/bg.png");
        spr_char = Texture2D.FromFile(GraphicsDevice, "res/char.png");
        spr_overlay = Texture2D.FromFile(GraphicsDevice, "res/overlay.png");

    }

    Vector2 player_pos = new Vector2(16, 60);
    float player_speed = 40f;
    protected override void Update(GameTime gameTime)
    {
        KeyboardState kb = Keyboard.GetState();
        if ( kb.IsKeyDown(Keys.Escape) ) Exit();


        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if ( kb.IsKeyDown( Keys.Up ) )
            player_pos.Y -= player_speed * deltaTime;
        else if ( kb.IsKeyDown( Keys.Down ) )
            player_pos.Y += player_speed * deltaTime;
        
        if ( kb.IsKeyDown( Keys.Left ) )
            player_pos.X -= player_speed * deltaTime;
        else if ( kb.IsKeyDown( Keys.Right ) )
            player_pos.X += player_speed * deltaTime;

        player_pos.Round();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GraphicsDevice.SetRenderTarget(_renderTarget);
        _spriteBatch.Begin(blendState: BlendState.NonPremultiplied);
        _spriteBatch.Draw(spr_bg, Vector2.Zero, Color.White);
        _spriteBatch.Draw(spr_char, player_pos, null, Color.White, 0f, new Vector2(8, 16), .5f, SpriteEffects.None, 0f);
        _spriteBatch.Draw(spr_overlay, Vector2.Zero, Color.White);
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, SCREEN_WIDTH * WIN_SCALE, SCREEN_HEIGHT * WIN_SCALE), Color.White);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
