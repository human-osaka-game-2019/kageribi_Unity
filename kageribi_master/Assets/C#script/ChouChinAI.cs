using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChouChinAI : MonoBehaviour
{

    int attackFlag = 0;
    int movementFlag = 0;
    int bulletFlag = 0;

    bool isTracing;
    public float movePower;

    Animator animator;
    Rigidbody2D rigidbody;

    public RuntimeAnimatorController Thung;
    public RuntimeAnimatorController Fireball;
    public RuntimeAnimatorController isMoving;

    GameObject traceTarget;
    public GameObject player;
    public GameObject enemy;
   
    public GameObject bulletPrefab;
    public GameObject targetCheck;

    // public bool canShoot = true;

    // public int MaxBulletPool;
    // private MemoryPool MPool;
    // private GameObject[] BulletArray;


    ///////////////////////////////////////////////////
    ///  関数、Start、Update　　　　　　　　　　　　　 ///
    ///////////////////////////////////////////////////
    ///

    /*private void OnApplicationQuit()
    {
        MPool.Dispose();
    }*/

    /*void ShootControl()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 enemyPos = enemy.transform.position;

        if (Mathf.Abs(playerPos.x - enemyPos.x) < 7.0f &&
            Mathf.Abs(playerPos.y - enemyPos.y) < 7.0f)
        {

            if(Mathf.Abs(playerPos.x - transform.position.x) <= 4.0f &&
                Mathf.Abs(playerPos.y - transform.position.y) <= 4.0f)
            {
                animator.runtimeAnimatorController = Thung;
            }

            if (Mathf.Abs(playerPos.x - transform.position.x) > 4.0f &&
                Mathf.Abs(playerPos.y - transform.position.y) > 4.0f)
            {

                for (int i = 0; i < MaxBulletPool; i++)
                {

                    animator.runtimeAnimatorController = Fireball;

                    if (BulletArray[i] == null)
                    {
                        BulletArray[i] = MPool.NewItem();
                        BulletArray[i].transform.position = transform.position;
                        
                        //gameObject.SetActive(true);

                        break;
                    }
                }

                for (int i = 0; i < MaxBulletPool; i++)
                {

                    if (BulletArray[i])
                    {
                        if (BulletArray[i].GetComponent<Collider2D>().enabled == false)
                        {
                            BulletArray[i].GetComponent<Collider2D>().enabled = true;
                            MPool.RemoveItem(BulletArray[i]);
                            BulletArray[i] = null;

                            break;
                        }

                    }
                }
            }
        }

        else
        {
            animator.runtimeAnimatorController = isMoving;

            EnemyMove();

        }
    }*/

    void Bullet_Damage()
    {

    }

    void EnemyMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Left")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);

        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

    }

   void EnemyAtk()
    {
        Vector3 playerPos = traceTarget.transform.position;

        if (Mathf.Abs(playerPos.x - transform.position.x) < 7 &&
            Mathf.Abs(playerPos.y - transform.position.y) < 7)
        {

            attackFlag = 0;


            if (Mathf.Abs(playerPos.x - transform.position.x) <= 4 &&
                Mathf.Abs(playerPos.y - transform.position.y) <= 4)
            {
                attackFlag =  1;
                animator.runtimeAnimatorController = Thung;
   
            }
            else
            {
                attackFlag = 2;
                animator.runtimeAnimatorController = Fireball;
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                //bulletPrefab.SetActive(true);

            }
        }
        else
        {
            animator.runtimeAnimatorController = isMoving;
           
            EnemyMove();

        }

    }
    

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(E_Movement());

        
        /*
        MPool = new MemoryPool();
        MPool.Create(bulletPrefab, MaxBulletPool);
        BulletArray = new GameObject[MaxBulletPool];
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();

        EnemyAtk();
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

    /*IEnumerator E_Attack()
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
            //bulletPrefab.SetActive(true);
            ShootControl();
        }

        yield return new WaitForSeconds(2.5f);

        StartCoroutine(E_Movement());
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine(E_Movement());
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = false;

            StartCoroutine(E_Movement());
        }

    }

}
