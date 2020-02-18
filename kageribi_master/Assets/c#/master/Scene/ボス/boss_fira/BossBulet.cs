using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulet : MonoBehaviour
{
    public GameObject boss;
    bossAI scr;
    float speed = 5f;
    Vector3 Playerpos;

    float step;
    float destroytime;
    Vector3 shotForward;
    int BossHP;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("狐_待機_04_火_01");
        scr = boss.GetComponent<bossAI>();
        Playerpos = scr.playerpos;
        shotForward = Vector3.Scale((Playerpos - transform.position) , new Vector3(1, 1, 0)).normalized;
        //if (scr.Player[0].activeSelf == true)
        //{
            
        //}
        //else if (scr.Player[1].activeSelf == true)
        //{
        //    shotForward = Vector3.Scale((silve - transform.position), new Vector3(1, 1, 0)).normalized;
        //}
          
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
            Debug.Log("出力");
            Destroy(gameObject);
            scr.bulletdamege();
            
        }
    }
}
