using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_manager : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject silver;
    public GameObject player;
    private GameObject[] gold_hp = new GameObject[20];
    private GameObject[] silver_hp = new GameObject[20];
    int hp;
    int count = 0;
    public int[] damage;
    public float night_timeout;
    public float morning_timeout;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        hp = player.GetComponent<gold_hp>().HP;

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

        for (int i = 0; i < silver_hp.Length; i++) 
        {
            silver_hp[i].SetActive(false);
        }
    }

            // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        int Pdm = hp - damage[0];
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (hp = hp; hp > Pdm; hp--)
            {
                gold_hp[count].SetActive(false);
                silver_hp[count].SetActive(false);
                count--;
            }
        }

        if (time >= night_timeout)
        {

            for (int i = 0; i < hp; i++)
            {                
                silver_hp[i].SetActive(true);
            }
            for(int i = 0; i < gold_hp.Length; i++)
            { 
                gold_hp[i].SetActive(false);
            }
            time = 0;

        }
        else if (time >= morning_timeout)
        {
            for (int i = 0; i < hp; i++)
            {               
                gold_hp[i].SetActive(true);
            }
            for (int i = 0; i < silver_hp.Length; i++)
            {
                silver_hp[i].SetActive(false);
            }
        }

    }
    public void juge()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            for (hp = hp; hp > hp - damage; hp--)
            {
                gold_hp[count].SetActive(false);
                silver_hp[count].SetActive(false);
                count--;
            }
        }*/
    }

}
