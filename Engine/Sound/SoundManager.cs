// Importing the necessary namespaces
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Events;
using Microsoft.Xna.Framework.Audio;

// Declaring a namespace for the SoundManager class
namespace JetBoxer2D.Engine.Sound
{
    // Defining the SoundManager class
    public class SoundManager
    {
        // Private fields to manage soundtracks and sound effects
        private int _soundtrackIndex;
        private List<SoundEffectInstance> _soundTracks;
        private Dictionary<Type, SoundEffect> _soundBank = new();

        // Method to set the soundtrack for the SoundManager
        public void SetSoundtrack(List<SoundEffectInstance> tracks)
        {
            // Set the list of sound effect instances as the soundtrack
            _soundTracks = tracks;
            // Initialize the soundtrack index to the last track in the list
            _soundtrackIndex = tracks.Count - 1;
        }

        // Method to stop the current soundtrack
        public void StopSoundTrack()
        {
            // Stop playback for each sound effect instance in the soundtrack
            foreach (var track in _soundTracks)
            {
                track.Stop();
            }
        }

        // Method to register a sound effect for a specific game event
        public void RegisterSound(BaseGameStateEvent gameEvent, SoundEffect soundEffect)
        {
            // Associate a sound effect with a specific type of game event
            _soundBank.Add(gameEvent.GetType(), soundEffect);
        }

        // Method to play the sound associated with a game event
        public void OnNotify(BaseGameStateEvent gameEvent)
        {
            // Check if the sound bank contains a sound effect for the given game event type
            if (_soundBank.ContainsKey(gameEvent.GetType()))
            {
                // Retrieve the associated sound effect and play it
                var sound = _soundBank[gameEvent.GetType()];
                sound.Play();
            }
        }

        // Method to play the soundtrack
        public void PlaySoundtrack()
        {
            // Get the total number of tracks in the soundtrack
            var numbOfTracks = _soundTracks.Count;

            // Retrieve the current track to play
            var currentTrack = _soundTracks[_soundtrackIndex];
            // Determine the next track to be played in a looping manner
            var nextTrack = _soundTracks[(_soundtrackIndex + 1) % numbOfTracks];

            // Check if the current track is in a stopped state
            if (currentTrack.State == SoundState.Stopped)
            {
                // Start playing the next track in the soundtrack
                nextTrack.Play();

                // Move to the next track index for the next iteration
                _soundtrackIndex++;

                // Reset the track index to the beginning if it exceeds the total number of tracks
                if (_soundtrackIndex >= _soundTracks.Count)
                {
                    _soundtrackIndex = 0;
                }
            }
        }
    }
}
