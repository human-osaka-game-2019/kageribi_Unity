using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBullet : MonoBehaviour
{

    GameObject traceTarget;
    public GameObject bullet;
    public Transform bulletPos;
    private bool FireState;

    public float MoveSpeed;
    int movementFlag = 0;

    public float MaxCount;
    public float Count;

    Animator animator;
    Rigidbody2D rigidbody;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    //transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    //transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.left * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.down * MoveSpeed * Time.deltaTime);

    void Update()
    {
        FireState = true;
        Flameshot();
        BulletMove();
    }

    void Flameshot()
    {
        if (FireState)
        {
            Count += Time.deltaTime;
            if (MaxCount <= Count)
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
            if (movementFlag == 1)
                dist = "Right";
            else if (movementFlag == 2)
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

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
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

