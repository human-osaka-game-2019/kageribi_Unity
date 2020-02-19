using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= 160)
        {
            if (Camera.orthographicSize < 10)
            {
                Camera.orthographicSize += 0.1f;
                this.transform.Translate(0f, 0.5f, 0f);
            }
        }
    }
}
