using System;
using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

namespace AudioSystem
{
    /// <summary>
    /// Controls clip playing based on triggering 
    /// Script to be placed on the object that has the sound interaction with the player
    /// </summary>
    public class MuliClipSource : MonoBehaviour
    {
        #region Private Variables
        AudioSource[] audioSources;
        int currentSource = 0;
        int nextSource = 1;
        #endregion

        #region Editor Variables
        [Tooltip("The sound files you want to switch between for close and far")]
        public Sound[] audioClips;
        #endregion
        
        #region MonoBehaviour Methods
        // Use this for initialization
        void Start()
        {
            audioSources = GetComponents<AudioSource>();
            for (int i = 1; i < audioSources.Length; i++)
            {
                audioSources[i].volume = audioSources[0].volume;
            }
        }
        #endregion

        #region Audio Control Methods
        // Play a sound from the pool
        public void Play(string _soundName)
        {
            Sound _sound = Array.Find(audioClips,  element => element.name == _soundName);

            if (_sound == null)
            {
                Debug.LogWarning("Sound: '" + _soundName + "' couldn't be played because it wasn't found.");
                return;
            }

            AudioSource _source = audioSources[nextSource];
            _source.clip = _sound.sound;
            _source.volume = UnityEngine.Random.Range(_sound.baseVolume - _sound.volumeVariance, _sound.baseVolume + _sound.volumeVariance);
            // _source.pitch = UnityEngine.Random.Range(_sound.basePitch - _sound.pitchVariance, _sound.basePitch + _sound.pitchVariance);

            nextSource = currentSource;
            // Currently only works for two audiosources
            currentSource = nextSource == 0 ? 1 : 0;

            StartCoroutine(FadeOutIn(_source.volume));
        }

        IEnumerator FadeOutIn(float targetIn)
        {
            audioSources[currentSource].volume = 0;
            audioSources[currentSource].Play();
            while (audioSources[currentSource].volume < targetIn)
            {
                audioSources[currentSource].volume += 0.01f;
                audioSources[nextSource].volume -= 0.01f;
                yield return new WaitForSeconds(0.001f);
            }
            audioSources[nextSource].volume = 0;
            audioSources[nextSource].Stop();
        }

        public float CurrentVolume()
        {
            return audioSources[currentSource].volume;
        }

        #endregion
    }
}
