using System.Numerics;
using Raylib_cs;

namespace RaylibTest;

public class Window
{
    protected int Width { get; set; }
    protected int Height { get; set; }
    protected string Title { get; set; }
    protected int TargetFps { get; set; }
    
    private List<GameObject> gameObjects = new List<GameObject>();
    
    public Window(int width, int height, string title, int targetFps)
    {
        Width = width;
        Height = height;
        Title = title;
        TargetFps = targetFps;
    }

    public virtual void Start()
    {
        Raylib.InitWindow(Width, Height, Title);
        Raylib.SetTargetFPS(TargetFps);
        Raylib.SetWindowMinSize(Width, Height);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Update();
            Raylib.EndDrawing();
        }
    }
    
    public virtual void Update()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw();
        }
    }
    
    public virtual void RegisterGameObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }

    public virtual void Stop()
    {
        Raylib.CloseWindow();
    }
    
}