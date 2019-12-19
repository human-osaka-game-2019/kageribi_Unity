using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShot : MonoBehaviour
{

    public float moveSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       BulletMove();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "floor")
        {
            this.gameObject.SetActive(false);
        }
    }
    void BulletMove()
    {
        transform.Translate(Vector2.left * moveSpeed);
        transform.Translate(Vector2.down * moveSpeed);
    }
}

