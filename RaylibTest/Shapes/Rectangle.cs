using System.Numerics;
using Raylib_cs;
using RaylibTest.Support;

namespace RaylibTest.Shapes;

public class Rectangle : GameObject
{
    public Vector2 Size;
    public Color Color;
    
    public Rectangle(Vector2 position, Vector2 size, Color color) : base(position)
    {
        Size = size;
        Color = color;
    }
    
    public override void Draw()
    {
        base.Draw();
        Raylib.DrawRectangleV(Position, Size, Color);
    }
    
    public bool Intersects(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(
            new Raylib_cs.Rectangle(Position.X,Position.Y,Size.X,Size.Y),
            new Raylib_cs.Rectangle(other.Position.X,other.Position.Y,other.Size.X,other.Size.Y));
    }
    
    public bool Intersects(Circle other)
    {
        return Raylib.CheckCollisionCircleRec(
            other.Position, other.Radius,
            new Raylib_cs.Rectangle(Position.X,Position.Y,Size.X,Size.Y));
    }
    
    public double DirectionTo(Rectangle other)
    {
        Vector2 otherPosition = other.Position;
        Vector2 position = Position;
        
        //Calculate the direction from position to otherPosition
        return Math.Tan((position.Y / position.X));

    }

}