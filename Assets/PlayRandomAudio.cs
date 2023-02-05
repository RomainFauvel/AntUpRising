using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{

    public int delayRangeMin=3;
    public int delayRangeMax=6;
    private float delay;
    private int soundToPlay;

    public AudioSource source;
    public AudioClip[] audioArray;
    

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {
            soundToPlay = Random.Range(0, audioArray.Length);
            delay = Random.Range(delayRangeMin, delayRangeMax);
            source.clip = audioArray[soundToPlay];
            source.PlayOneShot(source.clip);
        }
        else
        {
            delay = delay - Time.deltaTime;
        }
    }
}
