using UnityEngine;

public class Explosion : MonoBehaviour
{    
    private ParticleSystem explosion;

    void Start()
    {
        explosion = GetComponent<ParticleSystem>();
        explosion.Play();
    }
}
