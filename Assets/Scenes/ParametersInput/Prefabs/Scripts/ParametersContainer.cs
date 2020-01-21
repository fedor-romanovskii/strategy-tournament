using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersContainer : MonoBehaviour
{
    public static ParametersContainer instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }


}
