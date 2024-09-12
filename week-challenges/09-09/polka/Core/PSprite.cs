using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Polka;

public class PSprite : PObject 
{
    #region Sprite
    public Texture2D sprite;
    public Vector2 origin;
    public Vector2 position;
    public float scale = 1f;
    public float rotation = 0f;
    public Color color = Color.White;
    public bool flipped = false;
    #endregion
    #region Animation
    public bool animated = false;
    public int anmSlices = 1;
    public int anmSpeed = 30;
    public int anmFrame = 0;
    public int[] anm = {};
    private int _anmCounter = 0;
    private int _anmIdx = 0;
    #endregion
    public override void Update(float deltaTime)
    {
        if ( animated )
        {
            _anmCounter++;
            if ( _anmCounter > anmSpeed-1 )
            {
                _anmCounter = 0;
                
                if ( anm.Length > 0 )
                {
                    _anmIdx++;
                    if ( _anmIdx > anm.Length-1 ) _anmIdx = 0;
                    anmFrame = anm[_anmIdx];
                }
                else
                {
                    anmFrame++;
                }
                
                if ( anmFrame == anmSlices ) 
                {
                    anmFrame = 0; 
                }
            }
        }

        base.Update(deltaTime);
    }
    public override void Draw( SpriteBatch spriteBatch )
    {
        SpriteEffects spriteEffect = SpriteEffects.None;
        if ( flipped )
        {
            spriteEffect = SpriteEffects.FlipHorizontally;
        }

        Rectangle rect = new Rectangle( 0, 0, sprite.Width, sprite.Height );
        if ( animated )
        {
            int _sliceWidth = sprite.Width / anmSlices;
            rect = new Rectangle(
                anmFrame * _sliceWidth,
                0,
                _sliceWidth,
                sprite.Height
            );
        }

        position.Round(); // Funciona melhor em resoluçoes baixas :p

        spriteBatch.Draw(
            sprite, 
            position, 
            rect, 
            color, 
            rotation, 
            origin, 
            scale, 
            spriteEffect, 
            0f
            );

        base.Draw( spriteBatch );
    }
}