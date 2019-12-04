using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Weapon[] myWeapons;
    // Start is called before the first frame update
    void Awake()
    {
        myWeapons = GetComponentsInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < myWeapons.Length; i++)
        {
            if(myWeapons[i] != null&&myWeapons[i].CanAttack)
            {
                myWeapons[i].Attack(true);
            }
        }
    }
}
