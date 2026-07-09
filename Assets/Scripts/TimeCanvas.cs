using UnityEngine;
using TMPro;

public class TimeCanvas : MonoBehaviour
{
    public TMP_Text ScoreText;
    [SerializeField] bool Finish;
    [SerializeField] private CanvasScriptableObject canvasParameter;

    public void ScoreRender(int time)
    {
        ScoreText.text = "TimeLimit:" + time;
    }

    public void TimeA(int time)
    {
        if (Finish)
        {
            canvasParameter.TimeLimit = 0;
        }
        else
        {
            Debug.Log("ŽžŠÔ‚ªŒ¸‚Á‚Ä‚¢‚Ü‚·");

            canvasParameter.TimeLimit -= Time.deltaTime;

            if ((int)canvasParameter.TimeLimit >= 1) { return; }
            Finish = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreRender((int)canvasParameter.TimeLimit);

        TimeA((int)canvasParameter.TimeLimit);
    }
}
