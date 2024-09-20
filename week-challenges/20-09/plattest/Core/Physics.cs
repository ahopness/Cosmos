using System.Numerics;
using Raylib_CSharp.Collision;
using Raylib_CSharp.Transformations;

namespace Platformer
{
    public class PhysicsWorld : IDisposable
    {
        public SortedList<string, Rectangle> bodyList = new SortedList<string, Rectangle>();
        public List<Rectangle> collisionList = new List<Rectangle>();
        
        public bool IsBodyOnColliding( Rectangle body )
        {
            foreach ( Rectangle collision in collisionList )
            {       
                if ( ShapeHelper.CheckCollisionRecs( body, collision ) )
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsBodyOnFloor( Vector2 point )
        {
            foreach ( Rectangle collision in collisionList )
            {       
                if ( ShapeHelper.CheckCollisionPointRec( point, collision ) )
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            bodyList.Clear();
            collisionList.Clear();
        }
        public void Dispose() 
        { 
            Clear(); 
        }
    }
}