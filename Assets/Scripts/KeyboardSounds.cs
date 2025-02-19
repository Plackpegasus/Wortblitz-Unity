using UnityEngine;
using UnityEngine.Audio;

public class KeyboardSounds : MonoBehaviour
{
    public float pitchVariation = 0.2f;
    public AudioResource keyClickSound;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.resource = keyClickSound;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.anyKeyDown)
        {
            var randomPitch = Random.Range(1 - pitchVariation, 1 + pitchVariation);
            audioSource.pitch = randomPitch;
            audioSource.Play();
        }
    }
}
