﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Capstone
{
    class SoundManager
    {
        List<Song> songs;
        List<SoundEffect> soundEffects;
        float maxVolume;

        public SoundManager()
        {
            songs = new List<Song>();
            soundEffects = new List<SoundEffect>();

        }
        //Load a song from Content and add it to the list
        public void LoadSong(string songName)
        {
            songs.Add(ContentHelper.Content.Load<Song>("Assets/Music/" + songName));
        }
        //Load a soundeffect from content and add it to the list
        public void LoadSoundEffect(string soundName)
        {
            soundEffects.Add(ContentHelper.Content.Load<SoundEffect>("Assets/SoundEffects/" + soundName));
        }
        //Play the song at the index provided
        public void PlaySong(int index, bool shouldLoop)
        {
            MediaPlayer.Play(songs[index]);

            //loop the song when its over
            if (shouldLoop)
            {
                MediaPlayer.IsRepeating = true;
            }
            else
            {
                MediaPlayer.IsRepeating = false;
            }
        }
        //stop the current song playing
        public void StopSong()
        {
            MediaPlayer.Stop();
        }
        //pause the current song playing 
        public void PauseSong()
        {
            MediaPlayer.Pause();
        }
        //resume the current song from the position it was paused at
        public void ResumeSong()
        {
            MediaPlayer.Resume();
        }
        //play the soundeffect at the index provided
        public void PlaySoundEffect(int index)
        {
            soundEffects[index].CreateInstance().Play();
        }
        //set the volume of the current song
        public void SetSongVolume(float volumeAmount)
        {
            //assure its a value between 0 and 1
            MathHelper.Clamp(volumeAmount, 0f, 1f);

            MediaPlayer.Volume = volumeAmount;
        }
        //set the max volume you wish for the current
        //used to fade between the current song volume and the max volume desired
        //if the song wont be doing fading just use SetSongVolume method instead
        public float SetMaxVolume(float maxAmount)
        {
            //assure its a value between 0 and 1
            MathHelper.Clamp(maxAmount, 0f, 1f);

            maxVolume = maxAmount;

            return maxAmount;
        }
        //set the volume of the sound effect at the index provided
        public void SetSoundEffectVolume(int index, float volumeAmount)
        {
            //assure its a value between 0 and 1
            MathHelper.Clamp(volumeAmount, 0f, 1f);

            soundEffects[index].CreateInstance().Volume = volumeAmount;
        }
        //fade out the current song playing 
        public void FadeOutSong()
        {
            MediaPlayer.Volume -= 0.005f;

            MathHelper.Clamp(MediaPlayer.Volume, 0f, 1f);
        }
        //fade in the current song playing
        public void FadeInSong()
        {
            MediaPlayer.Volume += 0.005f;

            //assure that the volume of the song will not be any louder than the amount specifed in the SetMaxVolume method 
            MathHelper.Clamp(MediaPlayer.Volume, 0f, SetMaxVolume(maxVolume));
        }




    }
}
