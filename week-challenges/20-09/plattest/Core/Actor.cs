using System.Numerics;
using Raylib_CSharp.Transformations;

namespace Platformer
{
    public class Actor : Sprite
    {
        public Vector2 velocity;
        public Rectangle collisionShape;

        public bool IsOnFloor()
        {
            // Pengando ponto pouco mais embaixo do player
            return Game.currentScene.physicsWorld.IsBodyOnFloor( new Vector2( position.X, position.Y + 0.1f ) );
        }
        public bool IsOnCollding()
        {
            Rectangle rect = new Rectangle(
                position.X - origin.X,
                position.Y - origin.Y,
                sprite.Width,
                sprite.Height
            );
            
            return Game.currentScene.physicsWorld.IsBodyOnColliding( rect );
        }

        private Vector2 remainder;
        public void Move(Vector2 value)
        {
            remainder += value;
            Vector2 move = (remainder);
            move.X = MathF.Floor(move.X);
            move.X = MathF.Floor(move.Y);
            remainder -= move;

            while (move.X != 0)
            {
                var sign = Math.Sign(move.X);
                if (!MovePixel(new Vector2(sign, 0)))
                {
                    velocity.X = 0;
                    remainder.X = 0;
                    break;
                }
                else
                {
                    move.X -= sign;
                }
            }

            while (move.Y != 0)
            {
                var sign = Math.Sign(move.Y);
                if (!MovePixel(new Vector2(0, sign)))
                {
                    velocity.Y = 0;
                    remainder.Y = 0;
                    break;
                }
                else
                {
                    move.Y -= sign;
                }
            }
        }

        bool MovePixel(Vector2 sign)
        {
            if (IsOnCollding())
            {
                if (sign.Y > 0 && IsOnFloor())
                    return false;
            }

            position += sign;
            return true;
        }

        public override void Update(float deltaTime)
        {
            Move( velocity * deltaTime );

            base.Update(deltaTime);
        }
    }
}