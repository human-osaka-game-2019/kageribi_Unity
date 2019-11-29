using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_manager : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject silver;
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    private GameObject[] gold_hp = new GameObject[20];
    private GameObject[] silver_hp = new GameObject[20];
    int Pdm = 0;
    int Gcount = 0;
    int Scount = 0;
    int Dcount = 0;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform gold_child in gold.transform)
        {
            if (Gcount == 20)
            {
                break;
            }
            gold_hp[Gcount] = gold_child.gameObject;
            Gcount += 1;
        }
        foreach (Transform silver_child in silver.transform)
        {
            if (Scount == 20)
            {
                break;
            }
            silver_hp[Scount] = silver_child.gameObject;
            Scount += 1;
        }
    }

            // Update is called once per frame
    void Update()
    {
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pdm = hp - damage;
        for (hp = hp; hp > Pdm; hp--)
        {
            Destroy(gold_hp[Dcount]);
            Destroy(silver_hp[Dcount]);
            Dcount += 1;
        }
    }
}
