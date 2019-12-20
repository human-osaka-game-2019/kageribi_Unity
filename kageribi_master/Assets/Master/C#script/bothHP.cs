using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bothHP : MonoBehaviour
{
    public int HP = 20;
    public GameObject Gameover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Gameover.SetActive(true);
        }
    }
    public void BigDamage()
    {
        HP = HP - 4;
        Debug.Log(HP);
    }
    public void NormalDamage()
    {
        HP = HP - 2;
    }
    public void SmallDamage()
    {
        HP = HP - 1;
    }
}
