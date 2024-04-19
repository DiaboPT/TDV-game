// Importing the necessary namespaces
using System;
using Microsoft.Xna.Framework;

// Declaring a namespace for the Collider class
namespace JetBoxer2D.Engine.Physics
{
    // Defining the Collider class
    public class Collider
    {
        // Private field to store the rectangle representing the collider
        private Rectangle _rectangle;

        // Event that is triggered when a collision occurs
        public event EventHandler<object> OnCollided;

        // Method to handle the collision event
        private void Collided(Collider collider)
        {
            // Invoke the OnCollided event, passing this Collider instance and empty EventArgs
            OnCollided?.Invoke(this, EventArgs.Empty);
        }
    }
}
