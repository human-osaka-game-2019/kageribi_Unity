?¿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldfox : MonoBehaviour
{
    public float speed = 0.1f;

    public RuntimeAnimatorController   Fire;
    public RuntimeAnimatorController  Water;
    public RuntimeAnimatorController  Grass;
    public GameObject Gin;

    private Animator animator;

    public Rigidbody2D rigid2D;
    public float jumpForce;
    public float jumpForce2;
    int jumpCounts = 0;


    // Start is called before the first frame update
    void Start() //æ?åã?ä¸?åã?ã¿å¼ã³åºããã?
    {
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void Update()
    {

        bool right = Input.GetAxisRaw("HorizontalL") > 0.19;
        bool left = Input.GetAxisRaw("HorizontalL") < -0.19;
        bool up = Input.GetButtonDown("XBOXA");
        //Animator animator = GetComponent<Animator>();
        //float GetAxis ("Horizintal") âã¨âã??ãåæã«åå¾ã§ããã?

        if (right == true)
        {
            transform.Translate(speed, 0.0f, 0.0f);//åº§æ¨ã?æ´æ°ã?rigidbody .Addforce 
            animator.SetInteger("Right", 1);
        }
        else if (left == true)
        {
            transform.Translate(-speed, 0.0f, 0.0f);
            animator.SetInteger("Left", 1);
        }
        else
        {           
            animator.SetInteger("Right", 0);
            animator.SetInteger("Left", 0);
        }

       
        if (up == true)
        {

            jumpCounts = jumpCounts + 1;

            if(jumpCounts == 1)
            {
                animator.SetBool("JumpRight", true);
                animator.SetBool("JumpLeft", true);
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce);

            }
            if (jumpCounts == 2)
            {
                animator.SetBool("JumpRight", true);
                animator.SetBool("JumpLeft", true);
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * jumpForce2);

            }  

        }


                //ä»¥ä¸ãã¹ãã³ã¼ã?
        if (Input.GetButtonDown("XBOXRB"))
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

        }
        /*
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (animator.runtimeAnimatorController == Fire)//ããã?ã¢ãã¡ã¼ã¿ã¼ãFireãªã?
                    {
                        GameObject prefab = Resources.Load("prefabs/Silver") as GameObject;
                        Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                        Debug.Log("kieta");
                        animator.runtimeAnimatorController = Fire;
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (animator.runtimeAnimatorController == Water)//ããã?ã¢ãã¡ã¼ã¿ã¼ãFireãªã?
                    {
                        GameObject prefab = Resources.Load("prefabs/Silver") as GameObject;
                        Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                        Debug.Log("kieta");
                        animator.runtimeAnimatorController = Water;
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (animator.runtimeAnimatorController == Grass)//ããã?ã¢ãã¡ã¼ã¿ã¼ãFireãªã?
                    {
                        GameObject prefab = Resources.Load("prefabs/Silver") as GameObject;
                        Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                        Debug.Log("kieta");
                        animator.runtimeAnimatorController = Grass;
                    }
                }*/

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
        animator.SetBool("JumpRight", false);
        animator.SetBool("JumpLeft", false);
    }

}

