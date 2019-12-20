using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Left : MonoBehaviour
{
    public float speed;
    public float Counts;
    public float MaxCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0.0f, 0.0f);
        Counts += Time.deltaTime;
        if (MaxCount <= Counts)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MonsterD_Fire")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterD_Water")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterD_Grass")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterC_Fire")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterC_Water")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterC_Grass")
        {
            Destroy(gameObject);
        }

    }

}
