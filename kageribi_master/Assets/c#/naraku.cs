using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naraku : MonoBehaviour
{
    public GameObject[] Player;
    GameObject Check;
    public GameObject bothHp;
    check point;
    // Start is called before the first frame update
    void Start()
    {
        Check = transform.root.gameObject;
        point = Check.GetComponent<check>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ttt");
            if (Player[0].activeSelf)
            {
                
                bothHp.GetComponent<bothHP>().SmallDamage();
                Player[0].GetComponent<goldfox>().CheckP();
            }
            else
            {
                bothHp.GetComponent<bothHP>().SmallDamage();
                Player[1].GetComponent<silverfox>().CheckP();
            }
        }
    }
}
