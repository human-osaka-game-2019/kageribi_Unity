using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundGradation : MonoBehaviour
{
    public GameObject Filter;

    float alpha = 0.0f;
    public float speed;
    bool ismax;

    // Start is called before the first frame update
    void Start()
    {
        ismax = false;
    }

    // Update is called once per frame
    void Update()
    {
        Filter.GetComponent<Renderer> ().material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        
        if (ismax == false)
        {
            alpha += speed;
            if (alpha > 1.0f)
            {
                ismax = true;
            }
        }
        else
        {
            alpha -= speed;
            if (alpha < 0.0f)
            {
                ismax = false;
            }
        }
    }
}
