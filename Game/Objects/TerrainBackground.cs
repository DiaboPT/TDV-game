using System;
using JetBoxer2D.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetBoxer2D.Game.Objects
{
    // TerrainBackground class inheriting from BaseGameObject
    public class TerrainBackground : BaseGameObject
    {
        // Constant for scrolling speed
        private const float ScrollingSpeed = 2.0f;
        private SpriteBatch _spriteBatch;

        // Constructor for TerrainBackground class
        public TerrainBackground(Texture2D texture)
        {
            _texture = texture;
            Position = new Vector2(0, 0);
        }

        // Override Render method
        public override void Render(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            if (_texture == null)
                throw new Exception($"{ToString()} texture field wasn't defined");

            // Get the viewport dimensions
            var viewport = _spriteBatch.GraphicsDevice.Viewport;
            var sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);

            // Render the background by tiling the texture
            for (var numVert = -1; numVert < viewport.Height / _texture.Height + 1; numVert++)
            {
                var y = (int)Position.Y + numVert * _texture.Height;

                for (var numHor = -1; numHor < viewport.Width / _texture.Width + 1; numHor++)
                {
                    var x = (int)Position.X + numHor * _texture.Width;
                    var destinationRectangle = new Rectangle(x, y, _texture.Width, _texture.Height);
                    _spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Centre, SpriteEffects.None, zIndex);
                }
            }

            // Update the position for scrolling effect
            _position.Y = (int)(Position.Y + ScrollingSpeed) % _texture.Height;
        }
    }
}
