namespace Platformer
{
    public class Object : IDisposable
    {
        public virtual void Create() {}
        public virtual void Update( float deltaTime ) {}
        public virtual void Draw() {}
        public virtual void Dispose() {}
    }
}