using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChouChinAI : MonoBehaviour
{
    

    int attackFlag = 0;
    int movementFlag = 0;

    bool isTracing;
    public float movePower;

    private int[] bullet;

    Animator animator;
    Rigidbody2D rigidbody;

    public RuntimeAnimatorController Thung;
    public RuntimeAnimatorController Fireball;
    public RuntimeAnimatorController isMoving;

    GameObject traceTarget;
    public GameObject player;
    public GameObject enemy;

    private class Bullet : MonoBehaviour
    {

        GameObject traceTarget;
        public GameObject bullet;
        public Transform bulletPos;

        public float BulletSpeed;
        int bulletFlag = 0;

        private bool FireState;

        public float BulletMaxCount;
        public float BCount;

        Animator animator;
        Rigidbody2D rigidbody;

        int attackFlag = 0;

        void BulletMove()
        {
            Vector3 moveVelocity = Vector3.zero;

            string dist = "";

            if (FireState)
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

        void Shot()
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

        void Bullet_Damage()
        {
          
        }

        void Start()
        {
            FireState = true;
            animator = gameObject.GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            BulletMove();
            Shot();
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

    private class Player : MonoBehaviour
    {
        void Player_HP()
        {

        }

        void Player_Damage()
        {

        }
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
            EnemyMove();
        }

    }

    

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine("E_Movement");
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

        StartCoroutine("E_Movement");
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

        yield return new WaitForSeconds(2.5f);

        StartCoroutine("E_Movement");
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("E_Movement");

            StartCoroutine("E_Attack");
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            EnemyMove();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = false;

            StopCoroutine("E_Attack");

            StartCoroutine("E_Movement");
        }
    }

}
