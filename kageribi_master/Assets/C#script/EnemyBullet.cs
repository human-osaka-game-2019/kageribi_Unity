using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBullet : MonoBehaviour
{

    GameObject traceTarget;
    public GameObject bullet;
    public Transform bulletPos;
    private bool FireState;

    public float BulletSpeed;
    int bulletFlag = 0;

    public float BulletMaxCount;
    public float BCount;

    Animator animator;
    Rigidbody2D rigidbody;
    int attackFlag = 0;


    void Start()
    {
        FireState = true;
        animator = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    //transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    //transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.left * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.down * MoveSpeed * Time.deltaTime);

    void Update()
    {
        Flameshot();
        BulletMove();
    }

    void Flameshot()
    {
        if (FireState)
        {
            BCount += Time.deltaTime;
            if (BulletMaxCount <= BCount)
            {
                Destroy(this.gameObject);
            }

            
           
        }
   
    }      
    
    void BulletMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        string dist = "";

        if(FireState)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Right";
            else if (playerPos.x > transform.position.x)
                dist = "Left";
        }
        else
        {
            if (bulletFlag == 1)
                dist = "Right";
            else if (bulletFlag == 2)
                dist = "Left";
        }

        if (dist == "Right")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1);
        }
        else if (dist == "Left")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y * -1);

        }

        transform.position += moveVelocity * BulletSpeed * Time.deltaTime;
    }

    IEnumerator Movement()
    {
        bulletFlag = Random.Range(0, 3);

        if (bulletFlag == 0)
        {
            animator.SetBool( "isMoving" , false);
        }
        else if (bulletFlag == 1)
        {
            animator.SetBool("isMoving", true);
        }
        else if (bulletFlag == 2)
        {
            animator.SetBool("isMoving", true);
        }
                
        yield return new WaitForSeconds(3f);

        StartCoroutine("E_Movement");
    }

    IEnumerator Attacking()
    {
        if (attackFlag == 0)
        {
            animator.SetBool("isMoving", true);
        }
        else if (attackFlag == 1)
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("Thung");
        }
        else if (attackFlag == 2)
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("Fireball");
        }

        yield return new WaitForSeconds(2.5f);

        StartCoroutine("E_Movement");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // 弾が接触したら弾は消滅する
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Contact Bullet");
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "floor")
        {
            Destroy(this.gameObject);
        }

    }

}

