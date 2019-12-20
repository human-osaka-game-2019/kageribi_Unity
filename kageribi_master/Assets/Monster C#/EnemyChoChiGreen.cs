using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChoChiGreen : MonoBehaviour
{
    int attackFlag = 0;
    int movementFlag = 0;

    bool isTracing;
    //bool isAttacking;

    public float movePower;
    public float moveSpeed;

    Animator animator;
    Rigidbody2D rigidbody;

    public RuntimeAnimatorController Thung;
    public RuntimeAnimatorController FireballUp;
    public RuntimeAnimatorController FireballDown;
    public RuntimeAnimatorController isMoving;

    public GameObject player;
    public GameObject enemy;

    public GameObject bulletPLeft;
    public GameObject bulletPRight;
    public GameObject bulletDLeft;
    public GameObject bulletDRight;

    private float timer;
    private float waitingTime;
    string dist = "";

    public int maxCount;
    public float Count;

    

    /////////////////////////////////
    ///  Start, Update, Functions 
    /////////////////////////////////

        //  해야 할 일 : fireball 하나로 합치기 , 데미지 정보 입력, 

    //////////////////////////   MOVE     ////////////////////////////



    void MoveRoutine()
    {
        
        Vector3 moveVelocity = Vector3.zero;

        if (isTracing)
        {
            Vector3 playerPos = player.transform.position;

            if (playerPos.x < transform.position.x)
            {
                dist = "Right";
            }

            else if (playerPos.x > transform.position.x)
            {
                dist = "Left";
            }
        }
        else
        {
            if (movementFlag == 1)
            {
                dist = "Right";
            }
            else if (movementFlag == 2) 
            {
                dist = "Left";
            }

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
        
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

    }

    void MovGimicDown()
    {
        Vector3 enemyPos = transform.position;
        Vector3 moveVelocity = Vector3.zero;

        if (Count > 18)
        {

            moveVelocity = Vector3.down;
            transform.Translate(0, -movePower, 0);

            //enemyPos.y = enemy.transform.position.y - (movePower * Time.deltaTime);

            dist = "Down";

            if (-1 >= transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, -1, transform.position.z);
            }

            StartCoroutine(E_Attack());

        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

    }

    void MovGimicUp()
    {
        Vector3 enemyPos = transform.position;
        Vector3 moveVelocity = Vector3.zero;

        if (Count > 38)
        {

            moveVelocity = Vector3.up;
            transform.Translate(0, movePower, 0);

            dist = "Up";

            if (5 <= transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            }

            StartCoroutine(E_Attack());
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


    void AttackP()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = enemy.transform.position;
        Vector3 moveVelocity = Vector3.zero;


        if (Mathf.Abs(playerPos.x - enemyPos.x) < 7 &&
            Mathf.Abs(playerPos.y - enemyPos.y) < 7)
        {

            if (Mathf.Abs(playerPos.x - enemyPos.x) <= 3 &&
                Mathf.Abs(playerPos.y - enemyPos.y) <= 3)
            {
                attackFlag = 1;

                animator.runtimeAnimatorController = Thung;
            }
            //else if (Mathf.Abs(playerPos.x - enemyPos.x) > 3 &&
            //Mathf.Abs(playerPos.y - enemyPos.y) > 3)

            else
            {
                attackFlag = 2;

                animator.runtimeAnimatorController = FireballUp;
            }

            //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        }
        else
        {
            animator.runtimeAnimatorController = isMoving;
            MoveRoutine();
        }
    }

    void AttackD()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = enemy.transform.position;
        Vector3 moveVelocity = Vector3.zero;


        if (Mathf.Abs(playerPos.x - enemyPos.x) < 7 &&
            Mathf.Abs(playerPos.y - enemyPos.y) < 7)
        {
            if (Mathf.Abs(playerPos.x - enemyPos.x) <= 3 &&
              Mathf.Abs(playerPos.y - enemyPos.y) <= 3)
            {
                attackFlag = 1;

                animator.runtimeAnimatorController = Thung;
            }
            //else if (Mathf.Abs(playerPos.x - enemyPos.x) > 3 &&
            //Mathf.Abs(playerPos.y - enemyPos.y) > 3)

            else
            {
                attackFlag = 3;

                animator.runtimeAnimatorController = FireballDown;
            }

            //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        }
        else
        {
            animator.runtimeAnimatorController = isMoving;
            MoveRoutine();
        }
    }

    void PBulletPref()
    {
        if (attackFlag == 2)
        {
            if (dist == "Right") // Right
            {
                Instantiate(bulletPLeft, transform.position, Quaternion.identity);
            }
            else if (dist == "Left") // Left
            {
                Instantiate(bulletPRight, transform.position, Quaternion.identity);
            }
        }

    }

    void DBulletPref()
    {

        if (attackFlag == 3)
        {
            if (dist == "Right") // Right
            {
                Instantiate(bulletDLeft, transform.position, Quaternion.identity);
            }
            else if (dist == "Right") // Left
            {
                Instantiate(bulletDRight, transform.position, Quaternion.identity);
            }
        }

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
        else if (attackFlag == 3)
        {
            animator.SetBool("isMoving", false);

            animator.SetTrigger("DFireball");
        }

        yield return new WaitForSeconds(2);

        StartCoroutine(E_Movement());
    }

    void Start()
    {
        Count = 0.0f;
        maxCount = 40;
        animator = gameObject.GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(E_Movement());
    }

    void FixedUpdate()
    {
        Count += Time.deltaTime;

        MovGimicDown();

        AttackD();

        MovGimicUp();

        AttackP();
       
        if (Count >= maxCount)
        {
           Count = 0.0f;
        }

        MoveRoutine();

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

            if (dist == "Up")
            {
                AttackP();
            }
            else if (dist == "Down")
            {
                AttackD();
            }
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

