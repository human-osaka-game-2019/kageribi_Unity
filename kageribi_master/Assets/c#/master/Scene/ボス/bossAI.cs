using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public RuntimeAnimatorController[] Boss;
    Animator anim;
    float ChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ChangeCount;
        ChangeTime += Time.deltaTime;
        if (ChangeTime >= 1)
        {
            ChangeCount = Random.value;
            if (ChangeCount <= 0.3)
            {
                anim.runtimeAnimatorController = Boss[0];
                ChangeTime = 0;
            }
            else if (ChangeCount >= 0.7)
            {
                anim.runtimeAnimatorController = Boss[2];
                ChangeTime = 0;
            }
            else
            {
                anim.runtimeAnimatorController = Boss[1];
                ChangeTime = 0;
            }
        }
    }
}
