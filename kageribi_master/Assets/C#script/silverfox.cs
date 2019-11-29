using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silverfox : MonoBehaviour
{
    public GameObject AttackRange;

    public float speed = 0.1f;

    public RuntimeAnimatorController Fire;
    public RuntimeAnimatorController Water;
    public RuntimeAnimatorController Grass;
    public GameObject Kin;

    private Animator animator;

    Rigidbody2D rigid2D;
    public float jumpForce;
    public float jumpForce2;
    int jumpCounts = 0;
    int attackCounts = 0;
    [SerializeField ]
    private bool Attack_Flag;

    int RunFlag = 0;

    // Start is called before the first frame update
    void Start() 
    {
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();
      
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("HorizontalL") > 0.19;
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("HorizontalL") < -0.19;
        bool up = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("XBOXA");
        bool attack = Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("XBOXB");

        if (Attack_Flag == false)
        {
            if (right == true)
            {
                Debug.Log("abs");
                transform.Translate(speed, 0.0f, 0.0f);
                animator.SetInteger("Right", 1);
                RunFlag = 1;
            }
            else if (left == true)
            {
                transform.Translate(-speed, 0.0f, 0.0f);
                animator.SetInteger("Left", 1);
                RunFlag = -1;
            }
            else
            {
                animator.SetInteger("Right", 0);
                animator.SetInteger("Left", 0);
            }

        }

        if (attack==true)
        {

            transform.Translate(speed, 0.0f, 0.0f);
            animator.SetInteger("Right", 1);
            RunFlag = 1;
        }
        else if (left == true)
        {
            transform.Translate(-speed, 0.0f, 0.0f);
            animator.SetInteger("Left", 1);
            RunFlag = -1;
        }
        
        if(attack==true)
        {

            Attack_Flag = true;
            animator.SetTrigger("Attack");
            AttackRange.SetActive(true);
            rigid2D.velocity = Vector2.zero;
        }

      

        if (up == true)
        {
            jumpCounts = jumpCounts + 1;
            if (jumpCounts == 1)
            {
                animator.SetTrigger("Jump");
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce);

            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("XBOXRB"))
        {
            if(RunFlag==1)

            if (animator.runtimeAnimatorController == Fire)
            {
                Debug.Log("aa");
                if (animator.runtimeAnimatorController == Fire)
                {
                    animator.runtimeAnimatorController = Water;
                    animator.SetInteger("Right", 1);
                }

                else if (animator.runtimeAnimatorController == Water)
                {
                    animator.runtimeAnimatorController = Grass;
                    animator.SetInteger("Right", 1);

                }

                else if (animator.runtimeAnimatorController == Grass)
                {
                    animator.runtimeAnimatorController = Fire;
                    animator.SetInteger("Right", 1);

                }

            }



        }

        if (Input.GetButtonDown("XBOXLB"))
        {

            if (animator.runtimeAnimatorController == Fire)
            {
                animator.runtimeAnimatorController = Grass;
            }

            else if (animator.runtimeAnimatorController == Grass)
            {
                animator.runtimeAnimatorController = Water;
            }

            else if (animator.runtimeAnimatorController == Water)
            {
                animator.runtimeAnimatorController = Fire;
            }

            /*
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (animator.runtimeAnimatorController == Fire)//もし�?アニメーターがFireな�?
                        {
                            GameObject prefab = Resources.Load("prefabs/Gold") as GameObject;
                            Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                            Destroy(this.gameObject);
                            Debug.Log("kieta");
                            animator.runtimeAnimatorController = Fire;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (animator.runtimeAnimatorController == Water)//もし�?アニメーターがFireな�?
                        {
                            GameObject prefab = Resources.Load("prefabs/Gold") as GameObject;
                            Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                            Destroy(this.gameObject);
                            Debug.Log("kieta");
                            animator.runtimeAnimatorController = Water;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (animator.runtimeAnimatorController == Grass)//もし�?アニメーターがFireな�?
                        {
                            GameObject prefab = Resources.Load("prefabs/Gold") as GameObject;
                            Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                            Destroy(this.gameObject);
                            Debug.Log("kieta");
                            animator.runtimeAnimatorController = Grass;
                        }
                    }*/


        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            jumpCounts = 0;
            animator.SetBool("Jumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            animator.SetBool("Jumping",true);
        }
    }

    void FinishJump()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("JumpRight", false);
        animator.SetBool("JumpLeft", false);
    }
    void FinishAttack()
    {
        AttackRange.SetActive(false);
        Attack_Flag = false;
    }

}

