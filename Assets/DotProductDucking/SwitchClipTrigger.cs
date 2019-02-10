using UnityEngine;
using AudioSystem;
/// <summary>
/// uses Trigger Collider to change clips
/// script to be placed on the object that has the sound interaction with the player
/// </summary>
public class SwitchClipTrigger : MonoBehaviour
{
    #region Private Variables
    MuliClipSource source;
    DotFade dot;
    #endregion

    #region Editor Variables
    [Tooltip("Name of Sound class for being close to object, inside trigger area")]
    public string nearSoundName = "Calm";
    [Tooltip("Name of Sound class for being far to object, outside trigger area")]
    public string farSoundName = "Choppy";
    #endregion
    #region MonoBehaviour Methods
    private void Start()
    {
        source = GetComponent<MuliClipSource>();
        dot = GetComponent<DotFade>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Debug.Log(gameObject.name + " " + nearSoundName);

            source.Play(nearSoundName);

            gameObject.GetComponent<Renderer>().material.color = Color.red;

            dot.EnableDot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log(gameObject.name + " " + farSoundName);

            source.Play(farSoundName);

            gameObject.GetComponent<Renderer>().material.color = Color.blue;

            dot.DisableDot();
        }
    }
    #endregion
}
