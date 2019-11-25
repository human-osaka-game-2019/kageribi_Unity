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
    int Pdm = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pdm = hp - damage;
        int dmcount = 0;

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (hp = hp; hp > Pdm; hp--)
            {
                if (gold.activeSelf == true)
                {
                    foreach (Transform childTransform in gold.transform)
                    {
                        if (dmcount == damage)
                        {
                            break;
                        }
                        Transform GHP = childTransform;
                        Debug.Log(GHP.gameObject.name);
                        Destroy(GHP.gameObject);
                        dmcount += 1;


                    }
                }
                else if (silver.activeSelf == true)
                {


                    foreach (Transform childTransform in silver.transform)
                    {
                        if (dmcount == damage)
                        {
                            break;
                        }
                        Transform GHP = childTransform;
                        Debug.Log(GHP.gameObject.name);
                        Destroy(GHP.gameObject);
                        dmcount += 1;


                    }
                }

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
