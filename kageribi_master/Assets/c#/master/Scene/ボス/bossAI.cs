using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public RuntimeAnimatorController[] Boss;
    public float Change;
    public GameObject[] Player;
    public GameObject Attackjuge;
    public GameObject[] BossBulet;
    public GameObject BulletFactory;
    public GameObject tackle;
    tume script; 
    public bothHP damage;
    Animator anim;

    bool isAnim;
    bool tacklestop;

  
    float tacklespeed = 0.5f;
    public float tackletime;
    float ChangeTime;
    float ScaleX;    
    public double[] TacklePos;
    int bulletcount;

    public Vector3 goldpos;
    public Vector3 silverpos;
    public Vector3 BulletPos;

    // Start is called before the first frame update
    void Start()
    {
        ScaleX = transform.localScale.x;
        anim = GetComponent<Animator>();
        script = Attackjuge.GetComponent<tume>();
    }

    // Update is called once per frame
    void Update()
    {
        float ChangeCount;
        goldpos = Player[0].transform.position;
        silverpos = Player[1].transform.position;
        BulletPos = BulletFactory.transform.position;
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
            pos();
            if (transform.position.x > TacklePos[0] || transform.position.x > TacklePos[1])
            {
                isAnim = true;
                anim.SetInteger("Attack", 2);
                transform.Translate(-tacklespeed, 0.0f, 0.0f);
                if(tackle.transform.position.x <= TacklePos[0] || tackle.transform.position.x <= TacklePos[1] || tacklestop == true)
                {
                    tackletime = 0;
                    anim.SetInteger("Attack", 0);
                    isAnim = false;
                    tacklestop = false;
                }
            }
            else if (transform.position.x < TacklePos[0] || transform.position.x < TacklePos[1])
            {
                isAnim = true;
                anim.SetInteger("Attack", 2);
                transform.Translate(tacklespeed, 0.0f, 0.0f);
                if (tackle.transform.position.x >= TacklePos[0] || tackle.transform.position.x >= TacklePos[1] || tacklestop == true)
                {
                    tackletime = 0;
                    anim.SetInteger("Attack", 0);
                    isAnim = false;
                    tacklestop = false;
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
                tacklestop = true;
            }

            damage.NormalDamage();
        }
    }

    void pos()
    {
        TacklePos[0] = goldpos.x;
        TacklePos[1] = silverpos.x;
    }

    public void shortrange()
    {
        anim.SetInteger("Attack", 1);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("tume"))
        {   
            anim.SetInteger("Attack", 0);
            script.RangeTime();
        }
    }

    public void longrange()
    {
        anim.SetInteger("Attack", 3);
        bulletcount += 1;
        if (anim.runtimeAnimatorController == Boss[0])
        {
            Instantiate(BossBulet[0],BulletPos , Quaternion.identity);
            if (bulletcount < 3)
            {
                Invoke("longrange", 0.5f);
            }
            
            if (bulletcount >= 3)
            {
                anim.SetInteger("Attack", 0);                
                bulletcount = 0;
            }
            
        }
        else if (anim.runtimeAnimatorController == Boss[1])
        {
            Instantiate(BossBulet[1], BulletPos, Quaternion.identity);
            if (bulletcount < 3)
            {
                Invoke("longrange", 0.5f);
            }

            if (bulletcount >= 3)
            {
                anim.SetInteger("Attack", 0);
                bulletcount = 0;
            }
        }
        else if (anim.runtimeAnimatorController == Boss[2])
        {
            Instantiate(BossBulet[2], BulletPos, Quaternion.identity);
            if (bulletcount < 3)
            {
                Invoke("longrange", 0.5f);
            }

            if (bulletcount >= 3)
            {
                anim.SetInteger("Attack", 0);
                bulletcount = 0;
            }
        }
        
        
    }
    public void bulletdamege()
    {
        damage.SmallDamage();
    }
}
