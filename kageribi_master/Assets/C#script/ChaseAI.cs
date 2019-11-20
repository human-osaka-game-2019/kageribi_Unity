using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{

    public float movePower = 1f;
    bool isTracing;
    GameObject traceTarget;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;  // 0:　停止　1:　左へ　2:　右へ

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()   // Coroutine
    {
        movementFlag = Random.Range(0, 3); // ランダムな動き

        if (movementFlag == 0)      //Animation Mapping
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);

        Debug.Log("Front Logic :" + Time.time);

        yield return new WaitForSeconds(3f);  // 3秒間待機

        Debug.Log("Behind Logic :" + Time.time);

        StartCoroutine("ChangeMovement");　// Logicの再スタート

    }

    void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;
            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (movementFlag == 1)

                dist = "Left";

            else if (movementFlag == 2)

                dist = "Right";
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        };

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            animator.SetBool("isMoving", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }

}