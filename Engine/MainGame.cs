// Importing necessary libraries and namespaces
using JetBoxer2D.Engine.Events;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Defining the namespace for the game
namespace JetBoxer2D.Engine;

// MainGame class inherits from the Game class in the Microsoft.Xna.Framework namespace
public class MainGame : Microsoft.Xna.Framework.Game
{
    // Declaring private variables for managing graphics, drawing sprites, and game state
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private BaseGameState currentGameState;

    // Declaring variables for rendering target and scale rectangle
    private RenderTarget2D renderTarget;
    private Rectangle renderScaleRectangle;

    // Declaring variables for initial resolution and aspect ratio
    private int _initialResolutionWidth;
    private int _initialResolutionHeight;
    private float _initialResolutionAspectRatio;
    private BaseGameState _initialGameState;

    // Constructor for the MainGame class
    public MainGame(int width, int height, BaseGameState initialGameState)
    {
        // Setting the root directory for game content
        Content.RootDirectory = "Content";
        // Initializing the GraphicsDeviceManager
        graphics = new GraphicsDeviceManager(this);

        // Setting the initial resolution and aspect ratio
        _initialResolutionWidth = width;
        _initialResolutionHeight = height;
        _initialResolutionAspectRatio = width / (float) height;

        // Setting the initial game state
        _initialGameState = initialGameState;

        // Initializing singletons
        SingletonManager.InitializeSingletons();
    }

    // Overriding the Initialize method from the Game class
    protected override void Initialize()
    {
        // Setting the preferred back buffer width and height
        graphics.PreferredBackBufferWidth = _initialResolutionWidth;
        graphics.PreferredBackBufferHeight = _initialResolutionHeight;
        // Setting the game to windowed mode
        graphics.IsFullScreen = false;
        // Applying the changes to the graphics device
        graphics.ApplyChanges();

        // Initializing the render target
        renderTarget = new RenderTarget2D(graphics.GraphicsDevice,
            _initialResolutionWidth, _initialResolutionHeight,
            false, SurfaceFormat.Color, DepthFormat.None, 0,
            RenderTargetUsage.DiscardContents);

        // Getting the scale rectangle
        renderScaleRectangle = GetScaleRectangle();

        // Calling the base Initialize method
        base.Initialize();
    }

    // Overriding the LoadContent method from the Game class
    protected override void LoadContent()
    {
        // Initializing the SpriteBatch
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // Switching to the initial game state
        SwitchState(_initialGameState);
    }

    // Overriding the UnloadContent method from the Game class
    protected override void UnloadContent()
    {
        // Unloading the content of the current game state
        currentGameState?.UnloadContent();
    }

    // Overriding the Update method from the Game class
    protected override void Update(GameTime gameTime)
    {
        // Updating the singletons
        SingletonManager.UpdateSingletons(gameTime);
        // Updating the current game state
        currentGameState?.Update();

        // Calling the base Update method
        base.Update(gameTime);
    }

    // Overriding the Draw method from the Game class
    protected override void Draw(GameTime gameTime)
    {
        // Setting the render target
        GraphicsDevice.SetRenderTarget(renderTarget);
        // Clearing the graphics device with a specific color
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Beginning the drawing of sprites
        spriteBatch.Begin(samplerState: SamplerState.PointWrap);
        // Rendering the current game state
        currentGameState.Render(spriteBatch);
        // Ending the drawing of sprites
        spriteBatch.End();

        // Resetting the render target and clearing it
        graphics.GraphicsDevice.SetRenderTarget(null);
        graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1.0f, 0);
        // Beginning the drawing of sprites with specific parameters
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
        // Drawing the render target onto the screen
        spriteBatch.Draw(renderTarget, renderScaleRectangle, Color.White);
        // Ending the drawing of sprites
        spriteBatch.End();

        // Calling the base Draw method
        base.Draw(gameTime);
    }

    // Method for getting the scale rectangle
    private Rectangle GetScaleRectangle()
    {
        // Declaring a variance variable
        var variance = 0.5;
        // Calculating the actual aspect ratio
        var actualAspectRatio = Window.ClientBounds.Width / (float) Window.ClientBounds.Height;

        // Declaring a rectangle variable
        Rectangle scaleRectangle;

        // Checking if the actual aspect ratio is less than or equal to the initial aspect ratio
        if (actualAspectRatio <= _initialResolutionAspectRatio)
        {
            // Calculating the present height and bar height
            var presentHeight = (int) (Window.ClientBounds.Width / _initialResolutionAspectRatio + variance);
            var barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

            // Setting the scale rectangle
            scaleRectangle = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
        }
        else
        {
            // Calculating the present width and bar width
            var presentWidth = (int) (Window.ClientBounds.Height * _initialResolutionAspectRatio + variance);
            var barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

            // Setting the scale rectangle
            scaleRectangle = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
        }

        // Returning the scale rectangle
        return scaleRectangle;
    }

    // Event handler for when the game state is switched
    private void CurrentGameState_OnStateSwitched(object sender, BaseGameState newState)
    {
        // Switching the game state
        SwitchState(newState);
    }

    // Event handler for when a game state event is notified
    private void CurrentGameState_OnEventNotification(object sender, BaseGameStateEvent eventType)
    {
        // Switching on the event type
        switch (eventType)
        {
            // Case for when the game is quit
            case BaseGameStateEvent.GameQuit:
                // Exiting the game
                Exit();
                break;
        }
    }

    // Method for switching the game state
    private void SwitchState(BaseGameState gameState)
    {
        // Checking if the current game state is not null
        if (currentGameState != null)
        {
            // Removing the event handlers and unloading the content of the current game state
            currentGameState.OnStateSwitched -= CurrentGameState_OnStateSwitched;
            currentGameState.OnEventNotification -= CurrentGameState_OnEventNotification;
            currentGameState.UnloadContent();
        }

        // Setting the current game state
        currentGameState = gameState;

        // Initializing and loading the content of the current game state
        currentGameState.Initialize(this, graphics, Content);
        currentGameState.LoadContent(spriteBatch);

        // Adding the event handlers
        currentGameState.OnStateSwitched += CurrentGameState_OnStateSwitched;
        currentGameState.OnEventNotification += CurrentGameState_OnEventNotification;
    }
}
