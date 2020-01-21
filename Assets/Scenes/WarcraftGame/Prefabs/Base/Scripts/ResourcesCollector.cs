using System;
using UnityEngine;

public class ResourcesCollector : MonoBehaviour
{
    protected float collectPerSecond = 2f;
    protected Action onResourceCollect;

    private void Update()
    {
        Timer();
    }

    private float time;

    private void Timer()
    {
        time += Time.deltaTime;
        if (time >= 1f / collectPerSecond)
        {
            time = 0f;
            onResourceCollect();
        }
    }
}
