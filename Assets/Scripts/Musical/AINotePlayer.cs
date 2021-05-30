using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINotePlayer : MonoBehaviour
{
    KeySoundLoader keySoundLoader;

    int[] topKeys = new int[3] { 10, 9, 8 };
    int[] bottomKeys = new int[3] { 5, 4, 3 };

    public float speed;

    int currentNote = 0;

    public AudioSource topAudioSource, bottomAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        keySoundLoader = GetComponent<KeySoundLoader>();

        StartCoroutine(PlaySounds());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator PlaySounds()
    {
        while(true)
        {
            topAudioSource.clip = keySoundLoader.KeySounds[topKeys[currentNote] - 1].KeyVolume[1];
            transform.GetChild(topKeys[currentNote] - 1).GetComponent<KeyStrikeDetector>().SetAiColor();
            topAudioSource.Play();

            bottomAudioSource.clip = keySoundLoader.KeySounds[bottomKeys[currentNote] - 1].KeyVolume[1];
            transform.GetChild(bottomKeys[currentNote] - 1).GetComponent<KeyStrikeDetector>().SetAiColor();
            bottomAudioSource.Play();

            currentNote++;

            if (currentNote > 2)
                currentNote = 0;

            yield return new WaitForSeconds(speed);
        }
    }
}
