using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSoundfields : MonoBehaviour {
    public AudioSource soundfieldAtmos;
    public AudioSource soundfieldSteps;
    public float distance = 10;
    // Use this for initialization
    void Start ()
    {
        distance = Vector3.Distance(soundfieldAtmos.transform.position, soundfieldSteps.transform.position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        soundfieldAtmos.volume =  GetDistanceAttenuation(soundfieldAtmos.transform.position);
        soundfieldSteps.volume =  GetDistanceAttenuation(soundfieldSteps.transform.position);
    }

    float GetDistanceAttenuation(Vector3 pos)
    {
        // log(1/10) = -1, log(1) = 0
        return Mathf.Abs(Mathf.Log(Mathf.Clamp(Vector3.Distance(transform.position, pos), 1f, distance) / distance));
    }
}
