using System.Numerics;

namespace RaylibTest.Support;

public class UiObject
{
    public Vector2 Position;
    public UiObject(Vector2 position)
    {
        Position = position;
    }
    public virtual void Draw()
    {
        
    }
}