using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0.19)
        {
            transform.Translate(0.5f, 0, 0);
        }
        
        if (Input.GetAxisRaw("Horizontal") < -0.19)
        {
            transform.Translate(-0.5f, 0, 0);
        }
        
        if (Input.GetAxisRaw("Vertical") > 0.19)
        {

        }

        if (Input.GetAxisRaw("Vertical") < -0.19)
        {

        }
    }
}
