using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silverfox : MonoBehaviour
{
    public float speed = 0.1f;

    public RuntimeAnimatorController   Fire;
    public RuntimeAnimatorController  Water;
    public RuntimeAnimatorController  Grass;
    public GameObject Kin;

    private Animator animator;

    Rigidbody2D rigid2D;
    public float jumpForce = 390.0f;
    int jumpCounts = 0;


    // Start is called before the first frame update
    void Start() //最初の一回のみ呼び出される
    {
      animator =  GetComponent<Animator>();
      rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        //Animator animator = GetComponent<Animator>();
        //float GetAxis ("Horizintal") ←と→　を同時に取得できる。

        if (right == true)
        {
            transform.Translate(speed, 0.0f, 0.0f);//座標の更新　rigidbody .Addforce 
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
        
        if(up==true)
        {
            jumpCounts=jumpCounts+1;
            if(jumpCounts==1)
            {
                animator.SetBool("Jump", true);
                rigid2D.AddForce(transform.up * jumpForce);

            }
            if (jumpCounts==2)
            {
                animator.SetBool("Jump", true);
                rigid2D.AddForce(transform.up * jumpForce);
            }
        }


                //以下テストコード
                if (Input.GetKeyDown(KeyCode.A))
        {
            animator.runtimeAnimatorController = Fire;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            animator.runtimeAnimatorController = Water;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.runtimeAnimatorController = Grass;
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            if(animator.runtimeAnimatorController==Fire)//もし　アニメーターがFireなら
            {
                Instantiate(Kin, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Debug.Log("kieta");
                animator.runtimeAnimatorController = Fire;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (animator.runtimeAnimatorController == Water)//もし　アニメーターがFireなら
            {
                Instantiate(Kin, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Debug.Log("kieta");
                animator.runtimeAnimatorController =Water ;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (animator.runtimeAnimatorController == Grass)//もし　アニメーターがFireなら
            {
                Instantiate(Kin, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Debug.Log("kieta");
                animator.runtimeAnimatorController = Grass;
            }
        }


    }

    void FinishJump()
    {
        animator.SetBool("Jump", false);
    }

}

