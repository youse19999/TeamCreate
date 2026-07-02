using UnityEngine;
using TMPro;

public class TimeCanvas : MonoBehaviour
{
    public TMP_Text ScoreText;
    float TimeLimit;
     bool Finish;

    public void ScoreRender(int time)
    {
        ScoreText.text = "TimeLimit:" + time;
    }

    public void TimeA(int time)
    {
        if (Finish)
        {
            TimeLimit = 0;
        }
        else
        {
            Debug.Log("ŽžŠÔ‚ªŒ¸‚Á‚Ä‚¢‚Ü‚·");

            TimeLimit -= Time.deltaTime;

            if (TimeLimit > 0) { return; }
            Finish = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeLimit = 60;
        Finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreRender((int)TimeLimit);

        TimeA((int)TimeLimit);
    }
}
