namespace Platformer
{
    public class Scene : IDisposable
    {
        public List<Object> objectList = new List<Object>();
        public virtual void Create() {
            foreach (Object _object in objectList)
                _object.Create();
        }
        public virtual void Update( float deltaTime ) {
            foreach (Object _object in objectList)
                _object.Update(deltaTime);
        }
        public virtual void Draw() {
            foreach (Object _object in objectList)
                _object.Draw();
        }
        public virtual void Dispose() {
            foreach (Object _object in objectList)
                _object.Dispose();
        }
    }
}