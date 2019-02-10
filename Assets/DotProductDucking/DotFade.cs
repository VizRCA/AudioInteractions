using UnityEngine.Audio;
using UnityEngine;
/// <summary>
/// controls orientation ducking
/// script to be placed on the object that has the sound interaction with the player
/// </summary>
public class DotFade : MonoBehaviour {
    #region Private Variables
    float dot;
    bool isDotEnabled;
    #endregion

    #region Editor Variables
    public Transform player;

    [Tooltip("The mixer group you have assigned this objects audio sources to output to")]
    public AudioMixerGroup mixer;

    [Tooltip("The exposed parameter that controls the mixer groups attenuation")]
    public string parameter;

    [Range(-80f, 20f)]
    public float duckToVolume = -18f;

    [Range(-80f, 20f)]
    public float defaultVolume = 0;
    #endregion

    #region MonoBehaviour Methods
    void Update()
    {
        if (!isDotEnabled) return;

        if (player)
        {
            Vector3 playerForward = player.TransformDirection(Vector3.forward);
            Vector3 objectPlayerDirection =  transform.position - player.position;
            dot = Vector3.Dot(playerForward, objectPlayerDirection.normalized);
            
            // Requires that parameter is setup in editor and mixer!
            mixer.audioMixer.SetFloat(parameter, Mathf.Lerp(duckToVolume, defaultVolume, 1f * (1.0f - dot)));
        }
    }
    #endregion

    #region Switching variables
    public void EnableDot()
    {
        isDotEnabled = true;
    }

    public void DisableDot()
    {
        isDotEnabled = false;
        mixer.audioMixer.SetFloat(parameter, defaultVolume);
    }
    #endregion
}
