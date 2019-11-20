?�using System.Collections;
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

    int RunFlag=0;

    // Start is called before the first frame update
    void Start() //�?初�?�?回�?み呼び出され�?
    {
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();
      
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        bool right = Input.GetAxisRaw("HorizontalL") > 0.19;
        bool left = Input.GetAxisRaw("HorizontalL") < -0.19;
        bool up = Input.GetButtonDown("XBOXA");
		bool attack = Input.GetButtonDown("XBOXB");

        //Animator animator = GetComponent<Animator>();
        //float GetAxis ("Horizintal") ←と→�??を同時に取得できる�?

        if (right == true)
        {
            transform.Translate(speed, 0.0f, 0.0f);//座標�?更新�?rigidbody .Addforce 
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

        if (up == true)
        {
            jumpCounts = jumpCounts + 1;
            if (jumpCounts == 1)
            {
                animator.SetBool("JumpRight", true);
                animator.SetBool("JumpLeft", true);
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce);

            }
        }
        if(attack==true)
        {
            animator.SetTrigger("Attack");
            AttackRange.SetActive(true);
            rigid2D.velocity = Vector2.zero;
        }



        //以下テストコー�?
        if (Input.GetButtonDown("XBOXRB"))
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
        if (collision.gameObject.name == "floor")
        {
            jumpCounts = 0;
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
    }

}

