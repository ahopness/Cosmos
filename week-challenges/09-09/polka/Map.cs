//using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Squared.Tiled;

namespace Polka;

public class PScene_Test : PScene
{

    public Map map;
    public PSprite bg;
    public PSprite deco;
    public PSprite solids;
    public Player player;

    public PScene_Test()
    {
        player = new Player();
        bg = new PSprite();
        deco = new PSprite();
        solids = new PSprite();
       
        // Ordem de desenho
        objectList.Add(bg);
        objectList.Add(player);
        objectList.Add(deco);
        objectList.Add(solids);
    }

    public override void Load(GraphicsDevice graphicsDevice, ContentManager content)
    {
        map = Map.Load("Content/Maps/map_01.tmx", content);

        Object playerObject = map.ObjectGroups["object"].Objects["player"];
        player.position = new Vector2( playerObject.X, playerObject.Y );

        base.Load(graphicsDevice, content);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        foreach (Layer layer in map.Layers.Values)
        {
            layer.Draw(
                spriteBatch,
                map.Tilesets.Values,
                new Rectangle(
                    0, 
                    0, 
                    256, 
                    144
                    ),
                Vector2.Zero,
                map.TileWidth, 
                map.TileHeight
                );
        }

        base.Draw(spriteBatch);
    }
}