using System.Numerics;
using Raylib_cs;
using RaylibTest.Shapes;
using RaylibTest.Support;
using RaylibTest.UiComponents;
using Rectangle = RaylibTest.Shapes.Rectangle;

namespace RaylibTest;

public class Game : Window
{
    public Game(int width, int height, string title, int targetFps, Camera2D camera) : base(width, height, title, targetFps, camera)
    {
    }
    
    Vector2 ballPosition = new Vector2(100, 100);
    UiText _text = new UiText(new Vector2(0,0), "Hello World!", 20, Color.RED);
    
    Circle circle = new Circle(new Vector2(0,0), 20, Color.RED);
    Circle circleD = new Circle(new Vector2(0,0), 2, Color.RED);
    Rectangle _cube = new Rectangle(new Vector2(100,100), new Vector2(10,20), Color.BLUE);

    public override void Start()
    {
        ballPosition = new Vector2((float) Width / 2, (float) Height / 2);
        RegisterGameObject(circle);
        RegisterUiObject(_text);
        RegisterGameObject(_cube);
        RegisterGameObject(circleD);
        base.Start();
    }
    
    public override void Update()
    {
        base.Update();
        if (!circle.Intersects(_cube))
        {
            
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) ballPosition.X += 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) ballPosition.X -= 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) ballPosition.Y -= 2.0f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) ballPosition.Y += 2.0f;

        double dir = _cube.DirectionTo(circle);
        Vector2 dirVec = new Vector2((float) Math.Cos(dir), (float) Math.Sin(dir));
        
        circleD.Position = circle.Position + dirVec * circle.Radius;
        
        circle.Position = ballPosition;
        Camera.target = new Vector2(0, 0);
        Console.Clear();
        Console.WriteLine(@"BallPisiton: {0}",circle.Position);
        Console.WriteLine(@"BallDirection: {0}",circleD.Position);
    }
}