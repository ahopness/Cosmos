using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Polka;

public class PScene : IDisposable 
{
    public List<PObject> objectList = new List<PObject>();
    public virtual void Load ( GraphicsDevice graphicsDevice ) {
        foreach (PObject pObject in objectList)
            pObject.Load(graphicsDevice);
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
    