using System.Numerics;

namespace RaylibTest;

public class GameObject
{
    public Vector2 Position;
    public GameObject(Vector2 position)
    {
        Position = position;
    }
    public virtual void Draw()
    {
        
    }
}