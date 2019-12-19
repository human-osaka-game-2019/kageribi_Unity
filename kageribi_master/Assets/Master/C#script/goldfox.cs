using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldfox : MonoBehaviour
{
    public int HP;
    public float speed = 0.1f;

    public RuntimeAnimatorController   Fire;
    public RuntimeAnimatorController  Water;
    public RuntimeAnimatorController  Grass;
    public GameObject Gin;

    private Animator animator;

    Rigidbody2D rigid2D;
    public float jumpForce;
    public float jumpForce2;
    int jumpCounts = 0;

    private bool Attack_Flag;
    private bool AttackFinish_Flag;
    int Run_Flag;

    float Counts = 0;
    float MaxCount = 1;


    // Start is called before the first frame update
    void Start() //�?初�?�?回�?み呼び出され�?
    {
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();
        Attack_Flag = false;
        Run_Flag = 1;
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
        //Animator animator = GetComponent<Animator>();
        //float GetAxis ("Horizintal") ←と→�??を同時に取得できる�?
        if (Attack_Flag == false)
        {
            if (right == true)
            {
                Debug.Log("aaa");
                transform.Translate(speed, 0.0f, 0.0f);//座標�?更新�?rigidbody .Addforce 
                animator.SetInteger("Right", 1);
                animator.SetInteger("Left", 0);
                Run_Flag = 1;
            }
            else if (left == true)
            {
                transform.Translate(-speed, 0.0f, 0.0f);
                animator.SetInteger("Left", 1);
                animator.SetInteger("Right", 0);
                Run_Flag = -1;
            }
            else
            {           
                animator.SetInteger("Right", 0);
                animator.SetInteger("Left", 0);
            }
        }

        if (attack == true)
        {
            Attack_Flag = true;
            AttackFinish_Flag = false;
            animator.SetTrigger("Attack");
            rigid2D.velocity = Vector2.zero;
            
            
        }
        if (special_attack == true)
        {
            Attack_Flag = true;
            AttackFinish_Flag = false;
            animator.SetTrigger("SpecialAttack");
            rigid2D.velocity = Vector2.zero;
        }


        if (up == true)
        {

            jumpCounts = jumpCounts + 1;

            if(jumpCounts == 1)
            {
                animator.SetTrigger("Jump");
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce);

            }
            if (jumpCounts == 2)
            {
                animator.SetTrigger("Jump");
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce2);

            }  

        }

                //以下テストコー�?
                  if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("XBOXRB"))
        {
           
            if(animator.runtimeAnimatorController == Fire)
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


        if (AttackFinish_Flag == true)
        {
            Counts += Time.deltaTime;
            if (Counts >= MaxCount)
            {
                Attack_Flag = false;
                AttackFinish_Flag = false;
                Counts = 0;
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
            animator.SetBool("Jumping", true);
        }
    }

    void FinishJump()
    {
    }

    void FinishAttack()
    {
        AttackFinish_Flag = true;
        if (Run_Flag == 1)
        {
            if (animator.runtimeAnimatorController == Fire)
            {
                GameObject prefab = Resources.Load("prefabs/FireBullet_Right") as GameObject;
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            if (animator.runtimeAnimatorController == Water)
            {
                GameObject prefab = Resources.Load("prefabs/WaterBullet_Right") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x,transform .position .y,transform .position .z), Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Grass)
            {
                GameObject prefab = Resources.Load("prefabs/GrassBullet_Right") as GameObject;
                Instantiate(prefab, transform.position, Quaternion.identity);

            }

        }
        if (Run_Flag == -1)
        {
            if (animator.runtimeAnimatorController == Fire)
            {
                GameObject prefab = Resources.Load("prefabs/FireBullet_Left") as GameObject;
                Instantiate(prefab, transform.position, Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Water)
            {
                GameObject prefab = Resources.Load("prefabs/WaterBullet_Left") as GameObject;
                Instantiate(prefab, transform.position, Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Grass)
            {
                GameObject prefab = Resources.Load("prefabs/GrassBullet_Left") as GameObject;
                Instantiate(prefab, transform.position, Quaternion.identity);

            }

        }
    }
    void FinishSpecialAttack()
    {
        AttackFinish_Flag = true;
        if (Run_Flag == 1)
        {
            if (animator.runtimeAnimatorController == Fire)
            {
                GameObject prefab = Resources.Load("prefabs/FireSpecialBullet_Right") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            }
            if (animator.runtimeAnimatorController == Water)
            {
                GameObject prefab = Resources.Load("prefabs/WaterSpecialBullet_Right") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Grass)
            {
                GameObject prefab = Resources.Load("prefabs/GrassSpecialBullet_Right") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            }

        }
        if (Run_Flag == -1)
        {
            if (animator.runtimeAnimatorController == Fire)
            {
                GameObject prefab = Resources.Load("prefabs/FireSpecialBullet_Left") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Water)
            {
                GameObject prefab = Resources.Load("prefabs/WaterSpecialBullet_Left") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            }
            if (animator.runtimeAnimatorController == Grass)
            {
                GameObject prefab = Resources.Load("prefabs/GrassSpecialBullet_Left") as GameObject;
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            }

        }

    }

}

