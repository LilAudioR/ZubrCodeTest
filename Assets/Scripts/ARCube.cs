using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCube : MonoBehaviour
{
    void Update()
    {
        Touch[] touch = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = touch[i];
            if (t.deltaTime > 1.0f) // if long touch 
            {
                // do stuff. 
            }
        }
    }
}
