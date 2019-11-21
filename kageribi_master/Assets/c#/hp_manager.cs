using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_manager : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject silver;
    [SerializeField] private int hp = 20;
    GameObject[] gold_hp;
    GameObject[] silver_hp;
    // Start is called before the first frame update
    void Start()
    {
        gold_hp[0] = GameObject.Find("HP1");
        gold_hp[1] = GameObject.Find("HP2");
        gold_hp[2] = GameObject.Find("HP3");
        gold_hp[3] = GameObject.Find("HP4");
        gold_hp[4] = GameObject.Find("HP5");
        silver_hp[0] = GameObject.Find("HP1");
        silver_hp[1] = GameObject.Find("HP2");
        silver_hp[2] = GameObject.Find("HP3");
        silver_hp[3] = GameObject.Find("HP4");
        silver_hp[4] = GameObject.Find("HP5");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
