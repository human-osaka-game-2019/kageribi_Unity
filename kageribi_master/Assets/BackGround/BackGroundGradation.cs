using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundGradation : MonoBehaviour
{
    [System.Serializable]
    public class BGFilter
    {
        public GameObject Filter;
        public bool isStart;
        bool isMax;
        public float speed = 0.01f;
        public float alpha = 0.0f;
        public void ChangeAlphaValue()
        {
            if (isMax == false)
            {
                alpha += speed;
                if (alpha >= 1.0f)
                {
                    isMax = true;
                }
            }
            else
            {
                alpha -= speed;
                if (alpha <= 0.0f)
                {
                    isMax = false;
                    isStart = false;
                    alpha = 0.0f;
                }
            }
        }
    }

    public BGFilter Moning = new BGFilter();
    public BGFilter Evening = new BGFilter();
    public BGFilter Night = new BGFilter();

    // Start is called before the first frame update
    void Start()
    {
        Moning.Filter.SetActive(false);
        Evening.Filter.SetActive(false);
        Night.Filter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Moning.isStart == true)
        {
            Moning.Filter.GetComponent<Renderer> ().material.color = new Color(1.0f, 1.0f, 1.0f, Moning.alpha);
            Moning.Filter.SetActive(true);
            Moning.ChangeAlphaValue();

            if (Moning.alpha <= 0.0f)
            {
                Evening.isStart = true;
            }
        }
        

        if (Evening.isStart == true)
        {
            Evening.Filter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, Evening.alpha);
            Evening.Filter.SetActive(true);
            Evening.ChangeAlphaValue();

            if (Evening.alpha >= 1.0f)
            {
                Night.isStart = true;
            }
        }

        if (Night.isStart == true)
        {
            Night.Filter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, Night.alpha);
            Night.Filter.SetActive(true);
            Night.ChangeAlphaValue();

            if (Night.alpha >= 1.0f)
            {
                Moning.isStart = true;
            }
        }
    }
}
