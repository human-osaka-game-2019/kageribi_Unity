using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public RuntimeAnimatorController[] Boss;
    public float Change;
    public GameObject[] Player;
    public bothHP damage;
    Animator anim;

    bool isAnim;

    float tacklespeed = 0.5f;
    public float tackletime;
    float ChangeTime;
    float ScaleX;

    public Vector3 goldpos;
    public Vector3 silverpos;

    // Start is called before the first frame update
    void Start()
    {
        ScaleX = transform.localScale.x;
        anim = GetComponent<Animator>();
        isAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("taiatari");

    }

    // Update is called once per frame
    void Update()
    {
        float ChangeCount;
        goldpos = Player[0].transform.position;
        silverpos = Player[1].transform.position;
        ChangeTime += Time.deltaTime;
        tackletime += Time.deltaTime;

        if (transform.position.x < goldpos.x || transform.position.x < silverpos.x)
        {
            Vector3 scale = transform.localScale;
            scale.x = ScaleX * -1.0f;
            transform.localScale = scale;
        }
        if(transform.position.x > goldpos.x || transform.position.x > silverpos.x)
        {
            Vector3 scale = transform.localScale;
            scale.x = ScaleX;
            transform.localScale = scale;
        }

        if (ChangeTime >= Change || Input.GetKeyDown(KeyCode.A))
        {
            ChangeCount = Random.value;
            if (ChangeCount <= 0.3)
            {
                anim.SetInteger("change", 1);
                anim.runtimeAnimatorController = Boss[0];
                ChangeTime = 0;
            }
            else if (ChangeCount >= 0.7)
            {
                anim.SetInteger("change", 1);
                anim.runtimeAnimatorController = Boss[2];
                ChangeTime = 0;
            }
            else
            {

                anim.SetInteger("change", 1);
                anim.runtimeAnimatorController = Boss[1];
                ChangeTime = 0;
                
            }

            
        }

        if (tackletime >= 30)
        {
            if (transform.position.x > goldpos.x || transform.position.x > silverpos.x)
            {
                anim.SetInteger("Attack", 2);
                transform.Translate(-tacklespeed, 0.0f, 0.0f);
                if(transform.position.x <= goldpos.x || transform.position.x <= silverpos.x)
                {
                    tackletime = 0;
                    anim.SetInteger("Attack", 0);
                }
            }
            else if (transform.position.x < goldpos.x || transform.position.x < silverpos.x)
            {
                anim.SetInteger("Attack", 2);
                transform.Translate(tacklespeed, 0.0f, 0.0f);
                if (transform.position.x >= goldpos.x || transform.position.x >= silverpos.x)
                {
                    tackletime = 0;
                    anim.SetInteger("Attack", 0);
                }
            }
                
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isAnim == true)
            {
                damage.BigDamage();
            }

            damage.NormalDamage();
        }
    }

    public void shortrange()
    {
        anim.SetInteger("Attack", 1);
    }

    public void longrange()
    {
        anim.SetInteger("Attack", 3); 
    }
}
