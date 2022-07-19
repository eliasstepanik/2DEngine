using System.Numerics;
using Raylib_cs;
using RaylibTest;

Game game = new Game(1024, 768, "Raylib Game Template", 60, new Camera2D(new Vector2(0f,0f), new Vector2(0,0), 0f, 1f));
game.Start();

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Raylib.BeginMode2D(game.Camera);
        game.Update();
    Raylib.EndMode2D();
    
    game.UpdateUi();
    Raylib.EndDrawing();
}