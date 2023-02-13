using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource backgroundMusic;
    public AudioSource[] sfx;

    public static AudioManager reference;
    private void Awake()
    {
        if (reference == null)
            reference = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int numeroSonido)
    {
        sfx[numeroSonido].Play();
    }
}
