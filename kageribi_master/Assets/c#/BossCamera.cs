using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public Camera Main_camera;//カメラを格納する変数。
    [SerializeField] GameObject Main_Camera_Move;//カメラの移動に関するあれこれをやるためにGameObjectとしてカメラを格納する。
    public GameObject PlayerCollider;
    public GameObject boss;
    public GameObject Boss_range;
    public Vector3 Player_pos;
    Vector3 kotei_pos;


    [SerializeField, Range(0.1f, 10.0f)] float Camera_aspet;//カメラのアスペクトの量を変更できるようにしたもの。

    bool move_side;
    bool move_height;
    bool kotei;
    bool size;
    public bool camera_return;
    public float speed;
    public int enemycount;
    void Start()
    {
        kotei_pos = new Vector3(165f,3f, -10f);
        Main_camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (kotei != false)
        {

            Main_Camera_Move.transform.position = Vector3.MoveTowards(Main_Camera_Move.transform.position, kotei_pos, step);
            if (Main_Camera_Move.transform.position == kotei_pos)
            {
                kotei = false;
            }

        }

 

        if (size == true)
        {
            if (Main_camera.orthographicSize >= 10)
            {
                size = false;
            }
            else
            {
                Main_camera.orthographicSize += 0.1f;

            }
        }


        if (camera_return == true)
        {
            Vector3 Playerpos;
            

            //if (Main_Camera_Move.transform.position.x <= Player.transform.position.x)
            //{
            //    Main_Camera_Move.transform.Translate(0.1f, 0, 0);
            //}
            //if (Main_Camera_Move.transform.position.x >= Player.transform.position.x)
            //{
            //    Main_Camera_Move.transform.Translate(-0.1f, 0, 0);
            //}

            //if (Main_Camera_Move.transform.position.y <= Player.transform.position.y + 3)
            //{
            //    Main_Camera_Move.transform.Translate(0, 0.1f, 0);
            //}
            //if (Main_Camera_Move.transform.position.y >= Player.transform.position.y + 3)
            //{
            //    Main_Camera_Move.transform.Translate(0, -0.1f, 0);
            //}

            if (Main_camera.orthographicSize >= 5)
            {
                Main_camera.orthographicSize -= 0.12f;
            }
            else
            {
                camera_return = false;
                Main_camera.GetComponent<Cameramove>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = false;

            }

            //Main_camera.transform.parent = Player.transform;
            PlayerCollider.SetActive(false);

        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Main_camera.GetComponent<Cameramove>().enabled = false;
            boss.GetComponent<bossAI>().enabled = true;
            Boss_range.GetComponent<tume>().enabled = true;
            move_side = true;
            move_height = true;
            kotei = true;
            size = true;
            //Main_camera.transform.parent = null;
            PlayerCollider.SetActive(true);
        }
    }

    public void CameraReturn()
    {
        camera_return = true;

    }

}