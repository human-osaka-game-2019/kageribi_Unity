using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int score = 0;
    public static GameObject GetGameObject()
    {
        return GameObject.FindGameObjectWithTag("Enemy");
    }
    public static Transform GetTransform()
    {
        return GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    public static AnimationController GetController()
    {
        return GameObject.FindGameObjectWithTag("Enemy").GetComponent<AnimationController>();
    }
    public static Animator GetAnimator()
    {
        return GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    public RuntimeAnimatorController datara_fire;
    public RuntimeAnimatorController datara_water;
    public RuntimeAnimatorController datara_leaf;

    public RuntimeAnimatorController lentern_fire;
    public RuntimeAnimatorController lentern_water;
    public RuntimeAnimatorController lentern_leaf;

    public GameObject datara_R;
    public GameObject datara_B;
    public GameObject datara_G;

    public GameObject Lentern_R;
    public GameObject Lentern_B;
    public GameObject Lentern_G;

    private Animator red_datara;
    private Animator blue_datara;
    private Animator green_datara;

    private Animator red_lentern;
    private Animator blue_lentern;
    private Animator green_lentern;

    private Vector2 datara_R_position;
    private Vector2 datara_B_position;
    private Vector2 datara_G_position;

    private Vector2 lentern_R_position;
    private Vector2 lentern_B_position;
    private Vector2 lentern_G_position;

    // Start is called before the first elapsed_time update
    void Start()
    {
        red_datara = datara_R.GetComponent<Animator>();
        blue_datara = datara_B.GetComponent<Animator>();
    }

    // Update is called once per elapsed_time
    void Update()
    {
        
    }
}
