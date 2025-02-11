using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource outsideSrc;
    public AudioSource insideSrc;

    private bool startedPlaying;
    // Start is called before the first frame update
    void Start()
    {
        outsideSrc.Stop();
        insideSrc.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.isFinished && !startedPlaying) {
            outsideSrc.Play();
            insideSrc.Play();
            startedPlaying = true;
        }

        if (!PlayerHealth.isInside) {
            insideSrc.volume = 0;
            outsideSrc.volume = 1;
        }
        else {
            outsideSrc.volume = 0;
            insideSrc.volume = 0.2f;
        }
    }
}
