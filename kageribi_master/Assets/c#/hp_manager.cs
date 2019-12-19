﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_manager : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject silver;
    private GameObject[] gold_hp = new GameObject[20];
    private GameObject[] silver_hp = new GameObject[20];
    GameObject Player;
    goldfox script;
    public int hp;
    int count = 0;
    int Acount = 0;
    public int damage;
    public float night_timeout;
    public float morning_timeout;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("金狐_光彩エフェクト_右向き_火_03");
        script = Player.GetComponent<goldfox>();
        foreach (Transform gold_child in gold.transform)
        {
            if (count == gold_hp.Length)
            {
                break;
            }
            gold_hp[count] = gold_child.gameObject;
            count += 1;
        }

        count = 0;

        foreach (Transform silver_child in silver.transform)
        {
            if (count == silver_hp.Length)
            {
                break;
            }
            silver_hp[count] = silver_child.gameObject;
            count += 1;
        }
        count = 0;
        for (int i = 0; i < silver_hp.Length; i++) 
        {
            silver_hp[i].SetActive(false);
        }
    }

            // Update is called once per frame
    void Update()
    {
        //int Pdm = Player.hp;
        time += Time.deltaTime;

        if (time > morning_timeout)
        {
            count = 19;
            for (int i = 0; i < hp; i++)
            {               
                gold_hp[count].SetActive(true);
                count--;
            }
            for (int i = 0; i < silver_hp.Length; i++)
            {
                silver_hp[i].SetActive(false);
            }
            time = 0;
        }
        else if (time > night_timeout)
        {
            count = 19;
            for (int i = 0; i < hp; i++)
            {                
                silver_hp[count].SetActive(true);
                count--;
            }
            for(int i = 0; i < gold_hp.Length; i++)
            { 
                gold_hp[i].SetActive(false);
            }


        }
        

    }
    /*void Controle()
    {
        for (hp = hp; hp > Pdm; hp--)
        {
            gold_hp[Acount].SetActive(false);
            silver_hp[Acount].SetActive(false);
            Acount++;
        }       
    }*/

}
