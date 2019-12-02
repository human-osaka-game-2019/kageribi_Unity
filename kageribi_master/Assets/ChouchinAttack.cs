using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChouchinAttack : MonoBehaviour
{ 
    bool isTracing;
    GameObject traceTarget;
    Animator animator;
    public RuntimeAnimatorController Attack_A;
    public RuntimeAnimatorController Attack_B;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    [SerializeField]
    private float freezeTime = 0.3f; //攻撃後、フリーズ時間

    // Update is called once per frame
    void FixedUpdate()
    {
        Attack();
    }
    void Attack()
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {

            }
        }
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                isTracing = true;
                animator.SetTrigger("Attack A");

                if (other.gameObject.tag == "Player")
                {
                    isTracing = true;
                    animator.SetTrigger("Attack B");
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {

            }

        }
    }
}
