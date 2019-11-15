using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterGradation : MonoBehaviour
{
    [System.Serializable]
    public class BGFilter
    {
        public GameObject Filter;
        public bool isStart;
        bool isMax;
        public float alpha;

        public void DrawTexture(float second)
        {
            Filter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Filter.SetActive(true);

            ChangeAlphaValue(second);
        }

        void ChangeAlphaValue(float second)
        {
            if (isMax == false)
            {
                alpha += 1.0f / (second * 60);
            }
            else
            {
                alpha -= 1.0f / (second * 60);
            }

            CompareAlphaSize();
        }

        void CompareAlphaSize()
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

    public float second;

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
            Moning.DrawTexture(second);

            if (Moning.alpha <= 0.0f)
            {
                Evening.isStart = true;
            }
        }


        if (Evening.isStart == true)
        {
            Evening.DrawTexture(second);

            if (Evening.alpha >= 1.0f)
            {
                Night.isStart = true;
            }
        }

        if (Night.isStart == true)
        {
            Night.DrawTexture(second);

            if (Night.alpha >= 1.0f)
            {
                Moning.isStart = true;
            }
        }
    }
}
