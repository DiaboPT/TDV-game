// Importing necessary namespaces
using System;
using JetBoxer2D.Engine.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Declaring a namespace for the BaseGameObject class
namespace JetBoxer2D.Engine.Objects
{
    // Defining the BaseGameObject class
    public class BaseGameObject
    {
        // Fields to store texture and position of the game object
        protected Texture2D _texture;
        protected Vector2 _position;

        // Property to get and set the position of the game object
        public virtual Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        // Properties for width and height of the game object
        public int Width { get; set; }
        public int Height { get; set; }

        // Property to calculate the center of the game object
        public Vector2 Centre => new Vector2(Width / 2f, Height / 2f);

        // Field to store the z-index of the game object
        public int zIndex;

        // Event to notify subscribers of game state events
        public event EventHandler<BaseGameStateEvent> Notify;

        // Method to notify subscribers of game state events
        public virtual void OnNotify(BaseGameStateEvent eventType)
        {
            Notify?.Invoke(this, eventType);
        }

        // Event triggered when the object changes
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        // Method to send events related to game state changes
        public void SendEvent(BaseGameStateEvent e)
        {
            OnObjectChanged?.Invoke(this, e);
        }

        // Virtual method called when the object is enabled
        protected virtual void OnEnable()
        {
        }

        // Virtual method called when the object is disabled
        protected virtual void OnDisable()
        {
        }

        // Virtual method to update the game object
        public virtual void Update()
        {
        }

        // Virtual method to render the game object using a SpriteBatch
        public virtual void Render(SpriteBatch spriteBatch)
        {
            // Render the texture at the specified position with white color
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else
                throw new Exception($"{ToString()} texture field wasn't defined");
        }
    }
}
