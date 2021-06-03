using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicSounds : MonoBehaviour
{
    private bool micConnected = false;

    [SerializeField] private int minFreq;
    [SerializeField] private int maxFreq;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if(Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not connected!");
        }
        else
        {
            micConnected = true;

            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            if(minFreq == 0 && maxFreq == 0)
            {
                maxFreq = 44100;
            }
        }
    }

    private void OnGUI()
    {
        if (micConnected)
        {
            if(!Microphone.IsRecording(null))
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Record"))
                {
                    audioSource.clip = Microphone.Start(null, true, 20, maxFreq);
                }

                else
                {
                    if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Stop and Play!"))
                    {
                        Microphone.End(null);
                        audioSource.Play();
                    }

                    GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 50), "Recording in progress...");
                }
            }
            else
            {
                GUI.contentColor = Color.red;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
            }
        }
    }
}
