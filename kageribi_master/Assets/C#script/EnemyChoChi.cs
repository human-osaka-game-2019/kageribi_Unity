using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChoChi : MonoBehaviour
{
    int attackFlag = 0;
    int movementFlag = 0;

    bool isTracing;
    //bool isAttacking;

    public float movePower;

    Animator animator;
    Rigidbody2D rigidbody;

    public RuntimeAnimatorController Thung;
    public RuntimeAnimatorController Fireball;
    public RuntimeAnimatorController isMoving;

    public GameObject player;
    public GameObject enemy;

    public GameObject bulletPrefab;

    private float timer;
    private float waitingTime;
    

    /////////////////////////////////
    ///  Start, Update, Functions 
    /////////////////////////////////



    //////////////////////////   MOVE     ////////////////////////////




    void MoveRoutine()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = player.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Right";
            else if (playerPos.x > transform.position.x)
                dist = "Left";
        }
        else
        { 
            if(movementFlag == 1)
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


    IEnumerator E_Movement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
        {
            animator.SetBool("isMoving", false);
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

        StartCoroutine(E_Movement());
    }

    //////////////////////////   ATTACK     ////////////////////////////


    void Attack()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = enemy.transform.position;
        Vector3 moveVelocity = Vector3.zero;
        timer += Time.deltaTime;
        waitingTime = 0.2f;

        if (Mathf.Abs(playerPos.x - enemyPos.x) < 7 &&
            Mathf.Abs(playerPos.y - enemyPos.y) < 7)
        {
            if (timer > waitingTime)
            {
                if (Mathf.Abs(playerPos.x - enemyPos.x) <= 4 &&
                Mathf.Abs(playerPos.y - enemyPos.y) <= 4)
                {
                   attackFlag = 1;

                   animator.runtimeAnimatorController = Thung;
                }

            //if (Mathf.Abs(playerPos.x - transform.position.x) > 4 &&
            //    Mathf.Abs(playerPos.y - transform.position.y) > 4)
                else
                {
                    attackFlag = 2;
                
                    animator.runtimeAnimatorController = Fireball;
                }

                //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                timer = 0;

            }
        }
        else
        {
            animator.runtimeAnimatorController = isMoving;
            MoveRoutine();
        }
    }

    void BulletPref()
    {

            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

    }

    IEnumerator E_Attack()
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

        yield return new WaitForSeconds(2);

        StartCoroutine(E_Movement());
    }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(E_Movement());
    }

    void FixedUpdate()
    {
        MoveRoutine();

        Attack();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;

            StopCoroutine(E_Movement());

            StartCoroutine(E_Attack());
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;

            MoveRoutine();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;

            StopCoroutine(E_Attack());

            StartCoroutine(E_Movement());
        }
    }
}

