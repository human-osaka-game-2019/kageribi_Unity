using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{
    public GameObject UI_GameOver;
    public GameObject UI_ReturnTitle;

    public float UI_switch;

    private float UI_seconds;

    public Image ImagePanel;
    public float alpha;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        UI_GameOver.SetActive(true);
        UI_ReturnTitle.SetActive(true);

        ImagePanel = GetComponent<Image>();
        ImagePanel.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha < 1)
        {
            StartFadeOut();
        }

        UI_seconds += 1.0f * Time.deltaTime;

        // Uiの点滅
        if (UI_seconds >= UI_switch)
        {
            if (UI_ReturnTitle.activeSelf == true)
            {
                UI_ReturnTitle.SetActive(false);
            }
            else
            {
                UI_ReturnTitle.SetActive(true);
            }

            UI_seconds = 0.0f;
        }

        if (UI_GameOver.activeSelf == true)
        {
            if (Input.GetButtonDown("XBOXA"))
            {
                SceneManager.LoadScene("Title");
            }

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    void StartFadeOut()
    {
        alpha += speed;
        ImagePanel.color = new Color(0.0f, 0.0f, 0.0f, alpha);
    }
}
