// Importing the namespace for sending emails
using System.Net.Mail;
// Importing the namespaces for custom game events and interfaces
using JetBoxer2D.Engine.Events;
using JetBoxer2D.Engine.Interfaces;

// Declaring a namespace for the GameplayEvents class
namespace JetBoxer2D.Game.Events
{
    // Defining the GameplayEvents class inheriting from BaseGameStateEvent
    public class GameplayEvents : BaseGameStateEvent
    {
        // Defining a nested class PlayerShoots under GameplayEvents
        public class PlayerShoots : GameplayEvents
        {
            // This class represents the event when a player shoots
        }

        // Defining a nested class EnemyHitBy under GameplayEvents
        public class EnemyHitBy : GameplayEvents
        {
            // Property to store the object that was hit by the enemy
            public IDamageable HitBy { get; private set; }

            // Constructor to initialize the EnemyHitBy event with the object that was hit
            public EnemyHitBy(IDamageable gameObject)
            {
                HitBy = gameObject;
            }
        }

        // Defining a nested class EnemyLostLife under GameplayEvents
        public class EnemyLostLife : GameplayEvents
        {
            // Property to store the current life of the enemy
            public int CurrentLife { get; private set; }

            // Constructor to initialize the EnemyLostLife event with the current life of the enemy
            public EnemyLostLife(int currentLife)
            {
                CurrentLife = currentLife;
            }
        }
    }
}
