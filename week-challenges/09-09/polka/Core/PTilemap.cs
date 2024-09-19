using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Polka;

/*
public class PTilemap : PObject
{
    public Dictionary<Vector2, int> tilemapInfo;
    public Texture2D tilemapSprite;

    public string infoFilePath;
    public string spriteFilePath;

    public int tileSize = 8;
    public Vector2 bounds = new Vector2( 29, 19 );

    public PTilemap( string _infoFilePath, string _spriteFilePath, int _tileSize = 8 )
    {
        infoFilePath = _infoFilePath;
        spriteFilePath = _spriteFilePath;
        tileSize = _tileSize;
    }

    public override void Load(GraphicsDevice graphicsDevice)
    {
        // Carregando Imagem
        tilemapSprite = Texture2D.FromFile( graphicsDevice, spriteFilePath );

        // Carregando Informações
        tilemapInfo = new Dictionary<Vector2, int>();
        StreamReader streamReader = new StreamReader(infoFilePath);

        int y = 0;
        string line;

        while( ( line = streamReader.ReadLine() ) != null )
        {
            string[] items = line.Split(',');

            for( int x = 0; x < items.Length; x++ )
            {
                if( int.TryParse( items[x] , out int value) )
                {
                    if( value > -1 )
                    {
                        tilemapInfo[new Vector2( x, y )] = value;
                    }
                }
            }

            y++;
        }

        base.Load(graphicsDevice);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        foreach (var item in tilemapInfo)
        {
            Rectangle tileRect = new Rectangle(
                (int)item.Key.X * tileSize,
                (int)item.Key.Y * tileSize,
                tileSize,
                tileSize
            );

            int x = item.Value % (int)bounds.X;
            int y = item.Value / (int)bounds.Y;
            Rectangle tileSource = new Rectangle(
                x * tileSize,
                y * tileSize,
                tileSize,
                tileSize
            );

            spriteBatch.Draw(
                tilemapSprite,
                tileRect,
                tileSource,
                Color.White
                );
        }

        base.Draw(spriteBatch);
    }
}
*/