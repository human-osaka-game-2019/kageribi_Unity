using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGradation : MonoBehaviour
{
    [System.Serializable]
    public class BGFilter
    {
        public GameObject Filter;
        public bool isStart;
        bool isMax;
        public float speed;
        public float alpha;

        public void DrawTexture()
        {
            Filter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Filter.SetActive(true);

            ChangeAlphaValue();
        }

        public void ChangeAlphaValue()
        {
            if (isMax == false)
            {
                alpha += speed;
            }
            else
            {
                alpha -= speed;
            }

            CompareAlphaSize();
        }

        public void CompareAlphaSize()
        {
            if (alpha >= 1.0f)
            {
                isMax = true;
                alpha = 1.0f;
            }

            if (alpha <= 0.0f)
            {
                isMax = false;
                isStart = false;
                alpha = 0.0f;
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
            Moning.DrawTexture();

            if (Moning.alpha <= 0.0f)
            {
                Evening.isStart = true;
            }
        }
        

        if (Evening.isStart == true)
        {
            Evening.DrawTexture();

            if (Evening.alpha >= 1.0f)
            {
                Night.isStart = true;
            }
        }

        if (Night.isStart == true)
        {
            Night.DrawTexture();

            if (Night.alpha >= 1.0f)
            {
                Moning.isStart = true;
            }
        }
    }
}
