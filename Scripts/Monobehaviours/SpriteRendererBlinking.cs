using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Very simple script that makes a SpriteRenderer to blink continuously
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererBlinking : MonoBehaviour
{
    public float TimeInSeconds;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > TimeInSeconds)
        {
            timer = 0;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
    }
}
