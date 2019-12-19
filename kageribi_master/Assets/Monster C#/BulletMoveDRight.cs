﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveDRight : MonoBehaviour
{
    public float moveSpeed;
    float Counts = 0;
    float MaxCount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        transform.Translate(Vector2.right * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Counts += Time.deltaTime;

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "floor")
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("destroyed");
        }
        else if (Counts >= MaxCount)
        {
            Destroy(gameObject);
        }

    }

}