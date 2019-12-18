using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("XBOXA"))
        {
            SceneManager.LoadScene("Beta Release Version");
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Beta Release Version");
        }
    }
}
