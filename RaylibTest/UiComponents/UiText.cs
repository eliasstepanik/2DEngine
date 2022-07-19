using System.Numerics;
using Raylib_cs;
using RaylibTest.Support;

namespace RaylibTest.UiComponents;

public class UiText : UiObject
{
    public string Text;
    public int FontSize;
    public Color Color;
    
    public UiText(Vector2 position, string text, int fontSize, Color color) : base(position)
    {
        Text = text;
        FontSize = fontSize;
        Color = color;
    }

    public override void Draw()
    {
        base.Draw();
        Raylib.DrawText(Text, (int)Position.X, (int)Position.Y, FontSize, Color);
    }
}