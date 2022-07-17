using System.Numerics;
using Raylib_cs;

namespace RaylibTest;

public class Sphere : GameObject
{
    public float Radius { get; set; }
    public Color Color { get; set; }
    
    public Sphere(Vector2 position, float radius, Color color) : base(position)
    {
        Radius = radius;
        Color = color;
    }
    
    public override void Draw()
    {
        base.Draw();
        Raylib.DrawCircleV(Position,Radius, Color);
    }
}