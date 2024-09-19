using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Polka;

public class PObject : IDisposable 
{
    public virtual void Load ( GraphicsDevice graphicsDevice, ContentManager content ) {}
    public virtual void Update ( float deltaTime ) {}
    public virtual void Draw ( SpriteBatch spriteBatch ) {}
    public virtual void Dispose() {}
}