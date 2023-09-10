using System;
using SFML.Audio;

namespace SpaceInvader.Utilities
{
    internal class SoundEffect
    {
        private SoundBuffer buffer;
        private Sound sound;

        public SoundEffect(string filename, float volume)
        {
            buffer = new SoundBuffer(filename);
            sound = new Sound(buffer);
            sound.Volume = volume;
        }

        public void Play() => sound.Play();
        public void Stop() => sound.Stop();
        public void Pause() => sound.Pause();

        
    }
}