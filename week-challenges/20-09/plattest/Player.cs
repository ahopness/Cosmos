using System.Numerics;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Textures;
using Raylib_CSharp.Transformations;

using static Platformer.Config;

namespace Platformer
{
    public class Player : Actor
    {
        public int[] anmIdle = { 0 };
        public int[] anmJump = { 1 };
        public int[] anmWalk = { 2, 0, 3, 0 };

        public override void Create()
        {
            sprite = Texture2D.Load("Content/Sprites/char.png");
            origin = new Vector2( 4, 8 );
            animated = true;
            anmSlices = 4;
            anmSpeed = 10;
            anm = anmIdle;

            base.Create();
        }

        const float moveSpeed = 50f;
        const float jumpSpeed = 16f;
        bool jumping = false;
        public override void Update(float deltaTime)
        {
            bool onFloor = IsOnFloor();
            if ( !onFloor )
                velocity.Y -= gravity.Y * 7f * deltaTime;
            
            int axis = getAxis(Input.IsKeyDown(KeyboardKey.Left), Input.IsKeyDown(KeyboardKey.Right));
            velocity.X += (float)axis * moveSpeed * deltaTime;

            // if ( Input.IsKeyPressed(KeyboardKey.Space) && onFloor )
            //     velocity.Y -= jumpSpeed;

            base.Update(deltaTime);
        }

        int getAxis(bool negative, bool positive)
        {
            if ( negative && positive ) return 0;
            if ( negative )             return -1;
            if ( positive )             return 1;
            return 0;
        }
    }
}