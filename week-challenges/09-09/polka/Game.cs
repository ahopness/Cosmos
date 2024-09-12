using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Polka;

public class PolkaGame : Game
{
    GraphicsDeviceManager _graphics;
    SpriteBatch _spriteBatch;
    RenderTarget2D _renderTarget;
    public PScene currentScene;
    public PolkaGame()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        IsMouseVisible = true;
        Window.Title = "Polka :: DEMO";

        IsFixedTimeStep = true;
        TargetElapsedTime = TimeSpan.FromSeconds( 1d / (double)TARGET_FPS );

        currentScene = new PScene_Test();
    }
    ~PolkaGame()
    {
        currentScene.Dispose();
    }

    const int SCREEN_WIDTH = 256;
    const int SCREEN_HEIGHT = 144;
    const int WINDOW_SCALE = 4;
    const int TARGET_FPS = 60;
    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = SCREEN_WIDTH * WINDOW_SCALE;
        _graphics.PreferredBackBufferHeight = SCREEN_HEIGHT * WINDOW_SCALE;
        _graphics.ApplyChanges();

        _renderTarget = new RenderTarget2D(GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        currentScene.Load( GraphicsDevice );
    }

    protected override void Update(GameTime gameTime)
    {
        if ( Keyboard.GetState().IsKeyDown(Keys.Escape) ) Exit();

        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        currentScene.Update( delta );

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(21, 14, 16));

        GraphicsDevice.SetRenderTarget(_renderTarget);
        _spriteBatch.Begin(blendState: BlendState.NonPremultiplied);
        currentScene.Draw( _spriteBatch );
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_renderTarget, 
            new Rectangle(0, 0, 
            SCREEN_WIDTH * WINDOW_SCALE, 
            SCREEN_HEIGHT * WINDOW_SCALE),
            Color.White
            );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
