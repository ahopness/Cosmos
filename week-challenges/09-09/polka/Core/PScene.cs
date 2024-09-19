using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Polka;

public class PScene : IDisposable 
{
    public List<PObject> objectList = new List<PObject>();
    public virtual void Load ( GraphicsDevice graphicsDevice, ContentManager content ) {
        foreach (PObject pObject in objectList)
            pObject.Load( graphicsDevice, content );
    }
    public virtual void Update ( float deltaTime ) {
        foreach (PObject pObject in objectList)
            pObject.Update(deltaTime);
    }
    public virtual void Draw ( SpriteBatch spriteBatch ) {
        foreach (PObject pObject in objectList)
            pObject.Draw(spriteBatch);
    }
    public virtual void Dispose() {
        foreach (PObject pObject in objectList)
            pObject.Dispose();
    }
}
    