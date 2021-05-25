using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySoundLoader : MonoBehaviour
{
    public List<KeyVolumes> KeySounds { get; set; } = new List<KeyVolumes>();

    void Start()
    {
        Object[] soundFiles = Resources.LoadAll("Sounds", typeof(AudioClip));

        int tempIndex = 0;// Let's us track which key we're on as we go through the files
        foreach(Object soundFile in soundFiles)
        {
            if (soundFile.name.Contains("_1"))
            {
                KeyVolumes keyVolumes = new KeyVolumes();
                KeySounds.Add(keyVolumes);
                keyVolumes.KeyVolume[0] = (AudioClip)soundFile;
            }
            else if (soundFile.name.Contains("_2"))
            {
                KeySounds[tempIndex].KeyVolume[1] = (AudioClip)soundFile;
            }
            else if (soundFile.name.Contains("_3"))
            {
                KeySounds[tempIndex].KeyVolume[2] = (AudioClip)soundFile;
                tempIndex++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class KeyVolumes
{
    public AudioClip[] KeyVolume { get; set; } = new AudioClip[3];
}
