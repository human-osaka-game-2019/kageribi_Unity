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
    int Gobj_count = 0;
    int Sobj_count = 0;
    int Dcount = 0;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform gold_child in gold.transform)
        {
            if (Gobj_count == 20)
            {
                break;
            }
            gold_hp[Gobj_count] = gold_child.gameObject;
            Gobj_count += 1;
        }
        foreach (Transform silver_child in silver.transform)
        {
            if (Sobj_count == 20)
            {
                break;
            }
            silver_hp[Sobj_count] = silver_child.gameObject;
            Sobj_count += 1;
        }
    }

            // Update is called once per frame
    void Update()
    {
        Pdm = hp - damage;

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (hp = hp; hp > Pdm; hp--)
            {
                Destroy(gold_hp[Dcount]);
                Destroy(silver_hp[Dcount]);
                Dcount += 1;
            }
            
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*int Pdm=hp-damage;
        int dmcount = 0;
        GameObject gold_control,silver_control;
        for (hp = 20; hp <=Pdm; hp--)
        {
            if (hp <= 4)
            {
                gold_control = gold_hp[0];
                silver_control = silver_hp[0];
                foreach(Transform hp in gold_control.transform)
                {
                    Destroy(hp);
                    dmcount += 1;
                    if (dmcount == damage)
                    {
                        break;
                    }

                }
            }
            else if (hp <= 8)
            {
                gold_control = gold_hp[1];
                silver_control = silver_hp[1];
                foreach (Transform hp in gold_control.transform)
                {
                    Destroy(hp);
                    dmcount += 1;
                    if (dmcount == damage)
                    {
                        break;
                    }

                }
            }
            else if (hp <= 12)
            {
                gold_control = gold_hp[2];
                silver_control = silver_hp[2];
                foreach (Transform hp in gold_control.transform)
                {
                    Destroy(hp);
                    dmcount += 1;
                    if (dmcount == damage)
                    {
                        break;
                    }

                }
            }
            else if (hp <= 16)
            {
                gold_control = gold_hp[3];
                silver_control = silver_hp[3];
                foreach (Transform hp in gold_control.transform)
                {
                    Destroy(hp);
                    dmcount += 1;
                    if (dmcount == damage)
                    {
                        break;
                    }

                }
            }
            else if (hp <= 20)
            {
                gold_control = gold_hp[4];
                silver_control = silver_hp[4];
                foreach (Transform hp in gold_control.transform)
                {
                    Destroy(hp);
                    dmcount += 1;
                    if (dmcount == damage)
                    {
                        break;
                    }

                }
            }
            
            
        }*/
    }
}
