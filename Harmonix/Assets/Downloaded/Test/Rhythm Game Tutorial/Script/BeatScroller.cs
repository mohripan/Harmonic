using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField] private float beatTempo;
    [SerializeField] internal bool hasStarted;

    private void Awake()
    {
        beatTempo = beatTempo / 60f;
    }

    private void Update()
    {
        CheckStart();
    }

    private void CheckStart()
    {
        if (!hasStarted)
        {
            /*if (Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
