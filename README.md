# AudioInteractions
Some interactive audio behaviours

## Copyright

All the sound files used are from [freesound](https://freesound.org/), if you use them in any projects you must credit the creators! Files will be named as they are in freesound.

## Examples

### Dot Product Ducking

Method for using orientation to objects to duck volume, set up to do inverse panning once you are within the trigger area. Simply, if you look at the source its quiet if you turn away it gets louder. This is achieved using a [Dot Product](https://docs.unity3d.com/2017.4/Documentation/ScriptReference/Vector3.Dot.html) between the player and the object.

The triggering system changes clips between two intensities, when inside the trigger volume "Calm" clips are played, when you leave the trigger volume "Choppy" clips are played.

In the scene, orientation ducking is on when the object is coloured red and off when blue, white is dormant. Look at how the AudioSources reference mixer groups and exposed parameters.

Key scripts:

+ Sound.cs - holder class for clips with names and some settings
+ DotFade.cs - controls orientation ducking, script to be placed on the object that has the sound interaction with the player
+ MuliClipSource.cs - controls clip playing based on triggering, script to be placed on the object that has the sound interaction with the player
+ SwitchClipTrigger.cs - uses BoxCollider Trigger to change clips, script to be placed on the object that has the sound interaction with the player

Unity package in folder can be used to take the scripts described above.
To remake, you must use specific [audio mixer](https://docs.unity3d.com/2017.4/Documentation/Manual/AudioMixer.html) groups with exposed parameters.
