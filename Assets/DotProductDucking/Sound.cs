//-----------------------------------------------------------------
// The Sound class of Audio System. It is used by the Audio Manager to
// easily pool together a bunch of sounds with each their settings.
//-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    /// <summary>
    /// holder class for clips with names and some settings
    /// </summary>
    [System.Serializable]
    public class Sound
    {
        [Tooltip("Name that triggers use to switch")]
        public string name;

        public AudioClip sound;

        [Range(0f, 1f)]
        public float baseVolume = 0.7f;
        [Range(0f, 0.5f)]
        public float volumeVariance = 0.1f;

        public float basePitch = 1f;
        [Range(0f, 0.5f)]
        public float pitchVariance = 0.1f;

        public Sound()
        {
            baseVolume = 0.7f;
            volumeVariance = 0.1f;

            basePitch = 1f;
            pitchVariance = 0.1f;
        }
    }

}
