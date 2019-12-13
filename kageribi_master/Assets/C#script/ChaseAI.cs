using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaseAI : MonoBehaviour
{
    public float movePower;
    bool isTracing;
    GameObject traceTarget;

    private Animator animator;
    Rigidbody2D rigidbody;
    Vector3 movement;

    int movementFlag = 0; // 0:Idle 1:Left 2:Right
    int attackFlag = 0;

    public GameObject Player;
    public GameObject Enemy;

    public RuntimeAnimatorController Thung;
    public RuntimeAnimatorController Fireball;
    public RuntimeAnimatorController isMoving;

    EnemyBullet eBullet;

    void Start()
    {

        animator = gameObject.GetComponentInChildren<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine("Movement");

    }


    void FixedUpdate()
    {

        Move();

        Attack();

    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if(isTracing)
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

        if(dist == "Right")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(dist == "Left")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
         
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

    }

    public void Attack()
    {
        Vector3 playerPos = traceTarget.transform.position;
        Vector3 moveVelocity = Vector3.zero;

        if (Mathf.Abs(playerPos.x - transform.position.x) < 7 &&
            Mathf.Abs(playerPos.y - transform.position.y) < 7)
        {
            if (Mathf.Abs(playerPos.x - transform.position.x) <= 4 &&
                Mathf.Abs(playerPos.y - transform.position.y) <= 4)
            {

                animator.runtimeAnimatorController = Thung;

            }
            else
            {

                animator.runtimeAnimatorController = Fireball;
                

            }
        }
        else
        {
            animator.runtimeAnimatorController = isMoving;
            Move();
        }

    }


    IEnumerator Movement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
        {
            animator.SetBool( "isMoving" , false);
        }
        else if (movementFlag == 1)
        {
            animator.SetBool("isMoving", true);
        }
        else if (movementFlag == 2)
        {
            animator.SetBool("isMoving", true);
        }
                
        yield return new WaitForSeconds(3f);

        StartCoroutine("Movement");
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

        StartCoroutine("Movement");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("Movement");

            StartCoroutine("Attacking");
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            isTracing = true;
            Move();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            isTracing = false;

            StopCoroutine("Attacking");

            StartCoroutine("Movement");
        }
    }

}