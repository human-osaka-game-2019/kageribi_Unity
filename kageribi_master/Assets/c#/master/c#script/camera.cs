using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject gold;
    public GameObject silver;
    public GameObject camera_move;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gold.activeSelf == true)
        {
            Vector3 playerPos = gold.transform.position;
            transform.position = new Vector3(playerPos.x, playerPos.y+2.6f, transform.position.z);           
        }
        else if (silver.activeSelf == true)
        {
            Vector3 playerPos = silver.transform.position;
            transform.position = new Vector3(playerPos.x, playerPos.y+2.6f, transform.position.z);
        }

        
    }
}
