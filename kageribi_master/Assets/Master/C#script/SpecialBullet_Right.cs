using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet_Right : MonoBehaviour
{
    public float speed=0.1f;
    public float Counts;
    public float MaxCount;

    private bool Hit_Flag=false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Hit_Flag == false)
        {
            transform.Translate(speed, -0.1f, 0.1f);
        }
        if (Hit_Flag == true)
        {
            Counts += Time.deltaTime;
            if (Counts >= MaxCount)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Hit_Flag = true;
            animator.SetBool("Hit", true);
        }
    }
}
