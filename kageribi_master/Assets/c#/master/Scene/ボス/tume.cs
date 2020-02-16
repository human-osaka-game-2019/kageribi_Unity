using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tume : MonoBehaviour
{
    GameObject Boss;
    bossAI script;
    public float attacktime;
    Vector3[] fox;
    float attackjuge;
    // Start is called before the first frame update
    void Start()
    {
        Boss = transform.root.gameObject;
        script = Boss.GetComponent<bossAI>();
    }

    // Update is called once per frame
    void Update()
    {
        attacktime += Time.deltaTime;
        fox[0] = script.goldpos;
        fox[1] = script.silverpos;
        attackjuge = Boss.transform.position.x - fox[0].x;
        if (attackjuge <= 10 )
        {
            if (attacktime >= 5)
            {
                script.shortrange();
            }
            
        }
        else
        {
            if (attacktime >= 5)
            {
                script.longrange();
            }
                
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            
        }
    }
}
