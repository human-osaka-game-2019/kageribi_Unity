using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera Main_camera;//カメラを格納する変数。
    [SerializeField] GameObject Main_Camera_Move;//カメラの移動に関するあれこれをやるためにGameObjectとしてカメラを格納する。
    public GameObject Player;
    public GameObject PlayerCollider;

    [SerializeField, Range(0.1f, 10.0f)] float Camera_aspet;//カメラのアスペクトの量を変更できるようにしたもの。

    bool move_side;
    bool move_height;
    bool size;
    void Start()
    {

        Main_camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //以下テストコード
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Main_camera.orthographicSize -= Camera_aspet;
        //}

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Main_camera.orthographicSize += Camera_aspet;
        //}


        //if (Main_camera.orthographicSize <= 4 && Main_Camera_Move.transform.position.x > 20f)
        //{
        //    move = true;
        //}
        //else
        //{
        //    Main_camera.orthographicSize -= Camera_aspet;
        //    Main_Camera_Move.transform.Translate(0.1f, 0, 0);
        //}
        if (move_side != false)
        {
            if (Main_Camera_Move.transform.position.x > 55f)
            {
                move_side = true;
            }
            else
            {
                //Main_camera.orthographicSize += Camera_aspet;
                Main_Camera_Move.transform.Translate(0.1f, 0, 0);
            }
        }
        if (move_height != false)
        {
            if (Main_Camera_Move.transform.position.y > 5f)
            {
                move_height = true;
            }
            else
            {
                Main_Camera_Move.transform.Translate(0, 0.1f, 0);
            }
        }

        //else
        //{
        //    Main_Camera_Move.transform.position = Player.transform.position;
        //}
        if (size != false)
        {
            if (Main_camera.orthographicSize >= 10)
            {
                size = true;
            }
            else
            {
                Main_camera.orthographicSize += 0.1f;

            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move_side = true;
            move_height = true;
            size = true;
            Main_camera.transform.parent = null;
            PlayerCollider.SetActive(true);
        }
    }
}