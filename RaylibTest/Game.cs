using System.Numerics;
using Raylib_cs;

namespace RaylibTest;

public class Game : Window
{
    public Game(int width, int height, string title, int targetFps) : base(width, height, title, targetFps)
    {
    }
    
    Vector2 ballPosition = new Vector2(100, 100);
    
    Sphere sphere = new Sphere(new Vector2(0,0), 20, Color.RED);

    public override void Start()
    {
        ballPosition = new Vector2((float) Width / 2, (float) Height / 2);
        RegisterGameObject(sphere);
        base.Start();
    }
    
    public override void Update()
    {
        base.Update();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) ballPosition.X += 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) ballPosition.X -= 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) ballPosition.Y -= 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) ballPosition.Y += 2.0f;
        
        Raylib.DrawText("move the ball with arrow keys", 10, 10, 20, Color.DARKGRAY);
        sphere.Position = ballPosition;
        Console.Clear();
        Console.WriteLine(@"BallPisiton: {0}",sphere.Position);
    }
}