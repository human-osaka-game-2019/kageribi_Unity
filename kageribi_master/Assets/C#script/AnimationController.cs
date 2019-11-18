using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public RuntimeAnimatorController Gold_Fire;
    public RuntimeAnimatorController Gold_Water;
    public RuntimeAnimatorController Gold_Grass;

    public RuntimeAnimatorController Silver_Fire;
    public RuntimeAnimatorController Silver_Water;
    public RuntimeAnimatorController Silver_Grass;

    public GameObject goldfox;
    public GameObject silverfox;

    private Animator Player_Animator_01;
    private Animator Player_Animator_02;

    private Vector2 Player_01_position;//位置情報の変数　金狐
    private Vector2 Player_02_position;//位置情報の変数　銀狐

    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;


    // Start is called before the first frame update
    void Start()
    {
        Player_Animator_01 = goldfox.GetComponent<Animator>();
        Player_Animator_02 = silverfox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("DPADH");
        float y = Input.GetAxisRaw("DPADV");

        IsLeft = false;
        IsRight = false;
        IsUp = false;
        IsDown = false;
        
        if(_LastX != x)
        {
            if (x == -1)
                IsLeft = true;
            else if (x == 1)
                IsRight = true;
        }

        if(_LastY != y)
        {
            if (y == -1)
                IsDown = true;
            else if (y == 1)
                IsUp = true;
        }

        _LastX = x;
        _LastY = y;

        if (IsUp == true)
        {
            if(goldfox.activeSelf==true)
            {
                if (Player_Animator_01.runtimeAnimatorController == Gold_Fire)
                {
                    goldfox.SetActive(false);
                    silverfox.SetActive(true);
                    Player_01_position = goldfox.transform.position;
                    silverfox.transform.position = Player_01_position;
                    Player_Animator_02.runtimeAnimatorController = Silver_Fire;

                }
                else if (Player_Animator_01.runtimeAnimatorController == Gold_Water)
                {
                    goldfox.SetActive(false);
                    silverfox.SetActive(true);
                    Player_01_position = goldfox.transform.position;
                    silverfox.transform.position = Player_01_position;
                    Player_Animator_02.runtimeAnimatorController = Silver_Water;

                }
                else if (Player_Animator_01.runtimeAnimatorController == Gold_Grass)
                {
                    goldfox.SetActive(false);
                    silverfox.SetActive(true);
                    Player_01_position = goldfox.transform.position;
                    silverfox.transform.position = Player_01_position;
                    Player_Animator_02.runtimeAnimatorController = Silver_Grass;

                }

            }


            else if(silverfox.activeSelf==true)
            {
                 if (Player_Animator_02.runtimeAnimatorController == Silver_Fire)
                {
                    goldfox.SetActive(true);
                    silverfox.SetActive(false);
                    Player_02_position = silverfox.transform.position;
                    goldfox.transform.position = Player_02_position;
                    Player_Animator_01.runtimeAnimatorController = Gold_Fire;

                }
                else if (Player_Animator_02.runtimeAnimatorController == Silver_Water)
                {
                    goldfox.SetActive(true);
                    silverfox.SetActive(false);
                    Player_02_position = silverfox.transform.position;
                    goldfox.transform.position = Player_02_position;
                    Player_Animator_01.runtimeAnimatorController = Gold_Water;

                }
                else if (Player_Animator_02.runtimeAnimatorController == Silver_Grass)
                {
                    goldfox.SetActive(true);
                    silverfox.SetActive(false);
                    Player_02_position = silverfox.transform.position;
                    goldfox.transform.position = Player_02_position;
                    Player_Animator_01.runtimeAnimatorController = Gold_Grass;

                }

            }

        }
    }
    
}
