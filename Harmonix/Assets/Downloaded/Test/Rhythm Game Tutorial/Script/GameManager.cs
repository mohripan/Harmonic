using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    public AudioSource music;

    public bool startPlaying;

    public BeatScroller scroller;
    public int currentScore;

    public int scorePerNote = 100;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                scroller.hasStarted = true;

                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        currentScore += scorePerNote;
    }

    public void NoteMissed()
    {

    }
}
