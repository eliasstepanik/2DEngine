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
    UiText playerDebugText = new UiText(new Vector2(0,0), "Hello World!", 20, Color.RED);
    UiText playerInputText = new UiText(new Vector2(0,30), "Hello World!", 20, Color.RED);
    UiText playerVelocityText= new UiText(new Vector2(0,60), "Hello World!", 20, Color.RED);


    Circle circle = new Circle(new Vector2(0,0), 20, Color.RED);
    Circle circleD = new Circle(new Vector2(0,0), 2, Color.RED);
    Rectangle _cube = new Rectangle(new Vector2(100,100), new Vector2(10,20), Color.BLUE);

    private List<Rectangle> _cubes;

    public override void Start()
    {
        ballPosition = new Vector2((float) Width / 2, (float) Height / 2);
        circle.Position = ballPosition;
        RegisterGameObject(circle);
        RegisterUiObject(playerDebugText);
        RegisterUiObject(playerInputText);
        RegisterUiObject(playerVelocityText);
        RegisterGameObject(_cube);
        RegisterGameObject(circleD);

        _cubes = new List<Rectangle>()
        {
            new Rectangle(new Vector2(0,0), new Vector2(Width,20), Color.BLUE),
            new Rectangle(new Vector2(0,0), new Vector2(20,Height), Color.BLUE),
            new Rectangle(new Vector2(Width - 20 ,0), new Vector2(20,Height), Color.BLUE),
            new Rectangle(new Vector2(0,Height - 20), new Vector2(Width,20), Color.BLUE)
        };

        foreach (var VARIABLE in _cubes)
        {
            RegisterGameObject(VARIABLE);
        }
        
        
        
        
        base.Start();
    }
    
    Vector2 playerVelocity = new Vector2(0,0);
    Vector2 playerInput = new Vector2(0,0);
    float speed = 2;
    
    bool _collided = false;
    public override void Update()
    {
        base.Update();
        playerInputText.Text = "Player Input: " + playerInput;
        playerVelocityText.Text = "Player Velocity: " + playerVelocity;
        playerDebugText.Text = "Player Debug: " + circle.Position;
        
        foreach (var rectangle in _cubes)
        {
            if (circle.Intersects(rectangle))
            {
                playerVelocity = new Vector2(0,0);
                playerInput = new Vector2(0,0);
                _collided = true;
            }
            else
            {
                _collided = false;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerInput.X = Raymath.Lerp(playerInput.X, 1, 0.5f * Raylib.GetFrameTime() * 10);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerInput.X = Raymath.Lerp(playerInput.X, -1, 0.5f * Raylib.GetFrameTime() * 10);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) playerInput.Y = Raymath.Lerp(playerInput.Y, -1, 0.5f * Raylib.GetFrameTime() * 10);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerInput.Y = Raymath.Lerp(playerInput.Y, 1, 0.5f * Raylib.GetFrameTime() * 10);
        


        playerVelocity += playerInput;
        
        circle.Position += playerVelocity * Raylib.GetFrameTime() * speed;
        
        
        Camera.target = new Vector2(0, 0);
        Console.Clear();
        Console.WriteLine(@"BallPisiton: {0}",circle.Position);
        Console.WriteLine(@"BallDirection: {0}",circleD.Position);
    }
    
    float Lerp(float start, float end, float amount)
    {
        float result = start + amount*(end - start);

        return result;
    }
}