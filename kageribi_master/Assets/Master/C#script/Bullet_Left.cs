using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Left : MonoBehaviour
{
    public float speed;
    public float Counts;
    public float MaxCount;
    GameObject boss;
    bossAI scr;
    Animator Banim;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("狐_待機_04_火_01");
        scr = boss.GetComponent<bossAI>();
        Banim = boss.GetComponent<Animator>();
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
        if (collision.gameObject.tag == "MonsterD_Fire" || collision.gameObject.tag == "boss" && Banim.runtimeAnimatorController == scr.Boss[0]) 
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterD_Water" || collision.gameObject.tag == "boss" && Banim.runtimeAnimatorController == scr.Boss[0])
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "MonsterD_Grass" || collision.gameObject.tag == "boss" && Banim.runtimeAnimatorController == scr.Boss[0])
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
