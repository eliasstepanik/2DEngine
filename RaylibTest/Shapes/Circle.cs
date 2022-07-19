using System.Numerics;
using Raylib_cs;
using RaylibTest.Support;

namespace RaylibTest.Shapes;

public class Circle : GameObject
{
    public float Radius { get; set; }
    public Color Color { get; set; }
    
    public Circle(Vector2 position, float radius, Color color) : base(position)
    {
        Radius = radius;
        Color = color;
    }
    
    public override void Draw()
    {
        base.Draw();
        Raylib.DrawCircleV(Position,Radius, Color);
    }
    
    public bool Intersects(Circle other)
    {
        return Raylib.CheckCollisionCircles(Position, Radius, other.Position, other.Radius);
    }
    
    public bool Intersects(Rectangle other)
    {
        return Raylib.CheckCollisionCircleRec(Position, Radius, new Raylib_cs.Rectangle(other.Position.X,other.Position.Y,other.Size.X,other.Size.Y));
    }
}