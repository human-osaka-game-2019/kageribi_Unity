using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldfox : MonoBehaviour
{
    public float speed = 0.1f;

    public RuntimeAnimatorController   Fire;
    public RuntimeAnimatorController  Water;
   public GameObject Gin;

    private Animator animator;


    // Start is called before the first frame update
    void Start() //最初の一回のみ呼び出される
    {
      animator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        //Animator animator = GetComponent<Animator>();
        //float GetAxis ("Horizintal") ←と→　を同時に取得できる。
        if (right==true)
        {
            transform.Translate(speed, 0.0f, 0.0f);//座標の更新　rigidbody .Addforce 
            animator.SetInteger("Speed", 1);
        }
        else if(left==true)
        {
            transform.Translate(-speed, 0.0f, 0.0f);
            animator.SetInteger("Speed", -1);
        }
        //else
        //{
        //animator.SetInteger("Speed", 0);
        //{

        //以下テストコード
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.runtimeAnimatorController = Fire;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            animator.runtimeAnimatorController = Water;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
            Instantiate(Gin, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("kieta");
        }
    }

}

