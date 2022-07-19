using System.Numerics;
using Raylib_cs;
using RaylibTest.Support;

namespace RaylibTest.Support;

public class Window
{
    protected int Width { get; set; }
    protected int Height { get; set; }
    protected string Title { get; set; }
    protected int TargetFps { get; set; }

    public Camera2D Camera;
    
    private List<GameObject> gameObjects = new List<GameObject>();
    private List<UiObject> uiObjects = new List<UiObject>();
    
    public Window(int width, int height, string title, int targetFps, Camera2D camera)
    {
        Width = width;
        Height = height;
        Title = title;
        TargetFps = targetFps;
        Camera = camera;
    }

    public virtual void Start()
    {
        Raylib.InitWindow(Width, Height, Title);
        Raylib.SetTargetFPS(TargetFps);
        Raylib.SetWindowMinSize(Width, Height);
    }
    
    public virtual void Update()
    {
        Parallel.ForEach(gameObjects, gameObject =>
        {
            gameObject.Draw();
        });
    }
    
    public virtual void UpdateUi()
    {
        Parallel.ForEach(uiObjects, uiObject =>
        {
            uiObject.Draw();
        });
    }
    
    public virtual void RegisterGameObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }
    
    public virtual void UnregisterGameObject(GameObject gameObject)
    {
        gameObjects.Remove(gameObject);
    }
    
    public virtual void RegisterUiObject(UiObject uiObject)
    {
        uiObjects.Add(uiObject);
    }

    public virtual void Close()
    {
        Raylib.CloseWindow();
    }
    
}