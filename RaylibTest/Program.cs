using Raylib_cs;
using RaylibTest;

Game game = new Game(1024, 768, "Raylib Game Template", 60);
game.Start();

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    game.Update();
    Raylib.EndDrawing();
}