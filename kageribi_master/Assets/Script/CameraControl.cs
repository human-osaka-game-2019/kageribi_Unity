using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera Camera;
    public GameObject CameraObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.transform.position.x >= 150)
        {
            CameraObj.GetComponent<Camera>.enabled = false;

            if (Camera.orthographicSize < 10)
            {
                Camera.orthographicSize += 0.1f;
                CameraObj.transform.Translate(0f, 0.5f, 0f);
            }
        }
    }
}
