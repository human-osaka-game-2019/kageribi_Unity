using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silverfox : MonoBehaviour
{
    public int HP;
    public GameObject[] AttackRange;

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
        Attack_Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("Damage", true);
        }

        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("HorizontalL") > 0.19;
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("HorizontalL") < -0.19;
        bool up = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("XBOXA");
        bool attack = Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("XBOXB");
        bool special_attack = Input.GetKeyDown(KeyCode.D);

        if (Attack_Flag == false)
        {
            if (right == true)
            {
                transform.Translate(speed, 0.0f, 0.0f);
                animator.SetInteger("Right", 1);
                animator.SetInteger("Left", 0);
                RunFlag = 1;
            }
            else if (left == true)
            {
                transform.Translate(-speed, 0.0f, 0.0f);
                animator.SetInteger("Left", 1);
                animator.SetInteger("Right", 0);
                RunFlag = -1;
            }
            else
            {
                animator.SetInteger("Right", 0);
                animator.SetInteger("Left", 0);
            }

        }

        
        if(attack==true)
        {

            Attack_Flag = true;
            animator.SetTrigger("Attack");
            rigid2D.velocity = Vector2.zero;

            if (RunFlag == 1)
            {
                if (animator.runtimeAnimatorController == Fire)
                {
                    AttackRange[0].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Water)
                {
                    AttackRange[1].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Grass)
                {
                    AttackRange[2].SetActive(true);
                }
            }
            else if (RunFlag == -1)
            {
                if (animator.runtimeAnimatorController == Fire)
                {
                    AttackRange[3].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Water)
                {
                    AttackRange[4].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Grass)
                {
                    AttackRange[5].SetActive(true);
                }
            }

        }
        if (special_attack == true)
        {
            Attack_Flag = true;
            animator.SetTrigger("SpecialAttack");
            rigid2D.velocity = Vector2.zero;
            if (RunFlag == 1)
            {
                if (animator.runtimeAnimatorController == Fire)
                {
                    AttackRange[6].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Water)
                {
                    AttackRange[7].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Grass)
                {
                    AttackRange[8].SetActive(true);
                }
            }
            else if (RunFlag == -1)
            {
                if (animator.runtimeAnimatorController == Fire)
                {
                    AttackRange[9].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Water)
                {
                    AttackRange[10].SetActive(true);
                }
                if (animator.runtimeAnimatorController == Grass)
                {
                    AttackRange[11].SetActive(true);
                }
            }

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

                if (animator.runtimeAnimatorController == Fire)
                {
                    animator.runtimeAnimatorController = Water;
                }

                else if (animator.runtimeAnimatorController == Water)
                {
                    animator.runtimeAnimatorController = Grass;
                }

                else if (animator.runtimeAnimatorController == Grass)
                {
                    animator.runtimeAnimatorController = Fire;
                }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("XBOXLB"))
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
    }
    void FinishAttack()
    {
        Attack_Flag = false;
        AttackRange[0].SetActive(false);
        AttackRange[1].SetActive(false);
        AttackRange[2].SetActive(false);
        AttackRange[3].SetActive(false);
        AttackRange[4].SetActive(false);
        AttackRange[5].SetActive(false);


    }
    void FinishSpecialAttack()
    {
        Attack_Flag = false;
        AttackRange[6].SetActive(false);
        AttackRange[7].SetActive(false);
        AttackRange[8].SetActive(false);
        AttackRange[9].SetActive(false);
        AttackRange[10].SetActive(false);
        AttackRange[11].SetActive(false);

        if (RunFlag == 1)
        {
            rigid2D.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        }
        else if (RunFlag == -1)
        {
            rigid2D.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        }

    }
    void FinishDamage()
    {
        animator.SetBool("Damage", false);
    }

}

