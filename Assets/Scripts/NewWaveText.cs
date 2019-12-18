using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Erik Neuhofer
//Changes the text of the next wave animation when a new wave starts

public class NewWaveText : MonoBehaviour
{
    Text text;
    public GameObject nextWaveUi;

    public string[] currentWaveText = { "", "", "", "", "" };

    public static NewWaveText ins;
    private bool increasing = false;
    bool changingAlpha = false;

    public bool NextWave
    {
        set { increasing = value; }
    }

    public float speed = 0.5f;
    private float t = 0.1f;
    private float time = 0;

    void Start()
    {
        ins = this;
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (changingAlpha)
        {
            if (increasing)
            {
                time += Time.deltaTime;
                if (time > 2)
                {
                    time = 0;
                    increasing = false;
                }
            }

            if (increasing)
            {
                t += Time.deltaTime * speed;
            }

            if (!increasing)
            {
                t -= Time.deltaTime * speed;
            }

            Vector4 color = new Vector4(1, 1, 1, Mathf.Lerp(0, 1, t));
            text.color = color;

            if (!increasing && text.color.a <= 0)
            {
                changingAlpha = false;
                nextWaveUi.SetActive(false);
            }
        }
    }

    public void DoMenuThings(int index)
    {
        changingAlpha = true;
        increasing = true;
        text.text = currentWaveText[index];
    }
}
