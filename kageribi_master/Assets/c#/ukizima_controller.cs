using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class ukizima_controller : MonoBehaviour
{
    public GameObject gold;
    public GameObject silver;
    public float timeout;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        silver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeout)
        {
            if (gold.activeSelf==true)
            {
                silver.SetActive(true);
                gold.SetActive(false);
                time = 0;
            }
            else
            {
                gold.SetActive(true);
                silver.SetActive(false);
                time = 0;
            }
        }

    }
    /*void switching()
    {


    }*/
}

