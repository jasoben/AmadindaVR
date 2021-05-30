using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStrikeDetector : MonoBehaviour
{
    KeySoundLoader keySoundLoader;
    int keyNumberIndex;
    AudioSource audioSource;
    bool canReactivateStick; // The stick "dies" after colliding with a key, but that key can also reactivate it 
    // once the stick collider exits

    public Material originalMaterial, strikeMaterial, aiMaterial;
    Renderer renderer;

    public float aiColorTime;

    // Start is called before the first frame update
    void Start()
    {
        keySoundLoader = GetComponentInParent<KeySoundLoader>();
        keyNumberIndex = GetComponent<KeySpacer>().number - 1; // Minus one because we want it's index, starting 
        // at zero, since we're talking with an array to get the sound clip

        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAiColor()
    {
        renderer.material = aiMaterial;
        Invoke("ReturnToRegularColor", aiColorTime);
    }

    void ReturnToRegularColor()
    {
        renderer.material = originalMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StickCollisionData>().IsActive == true)
        {
            float stickSpeed = collision.gameObject.GetComponent<StickCollisionData>().GetStickSpeed();
            if (stickSpeed < .03f)
                audioSource.clip = keySoundLoader.KeySounds[keyNumberIndex].KeyVolume[0];
            else if (stickSpeed > .03f && stickSpeed < .05f)
                audioSource.clip = keySoundLoader.KeySounds[keyNumberIndex].KeyVolume[1];
            else if (stickSpeed > .05f)
                audioSource.clip = keySoundLoader.KeySounds[keyNumberIndex].KeyVolume[2];
            audioSource.Play();
            collision.gameObject.GetComponent<StickCollisionData>().IsActive = false;

            renderer.material = strikeMaterial;

            canReactivateStick = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (canReactivateStick)
        {
            collision.gameObject.GetComponent<StickCollisionData>().IsActive = true;

            renderer.material = originalMaterial;

            canReactivateStick = false;
        }
        
    }
}
