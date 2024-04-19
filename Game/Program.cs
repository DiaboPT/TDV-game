using JetBoxer2D.Engine;
using JetBoxer2D.Game.States;

//Window resolution in pixels
const int Width = 1280;
const int Height = 720;

//Creates a game variable with Width and Height, and then runs it
using var game = new MainGame(Width, Height, new GameplayState());
game.Run();