using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulet : MonoBehaviour
{
    public GameObject boss;
    bossAI scr;
    float speed = 5f;
    Vector3 gold;
    Vector3 silver;
    float step;
    float destroytime;
    Vector3 shotForward;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("狐_待機_04_火_01");
        scr = boss.GetComponent<bossAI>();
        gold = scr.goldpos;
        silver = scr.silverpos;
        if (scr.Player[0].activeSelf == true)
        {
            shotForward = Vector3.Scale((gold - transform.position) , new Vector3(1, 1, 0)).normalized;
        }
        else if (scr.Player[1].activeSelf == true)
        {
            Vector3 shotForward = Vector3.Scale((silver - transform.position), new Vector3(1, 1, 0)).normalized;
        }
          
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        destroytime += Time.deltaTime;
        
        if (destroytime>=5) 
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scr.bulletdamege();
            Destroy(gameObject);
        }
    }
}
