using UnityEngine;
using TMPro;

public class TimeCanvas : MonoBehaviour
{
    private Animator anim = null;
    public TMP_Text TimeText;
    [SerializeField] public bool Finish;
    [SerializeField] public float timelimit;
    [SerializeField] private CanvasScriptableObject canvasParameter;
    [SerializeField] public bool AnimFinish;

    //Timelimit‚ÌText‚ÌÝ’è
    public void ScoreRender(int time)
    {
        TimeText.text = "TimeLimit:" + time;
    }

    public void FinishAnimation()
    {
        AnimFinish = true;
    }

    //ŽžŠÔ§ŒÀ
    public void TimeA(int time)
    {
        if (Finish)
        {
            //ŽžŠÔ‚ð‚O‚ÉŒÅ’è‚·‚é
            timelimit = 0;
        }
        else
        {
            timelimit-=Time.deltaTime;

            //TimeOut‚É‚È‚Á‚½‚çŽžŠÔ‚ðŽ~‚ß‚é
            if ((int)timelimit >= 1) { return; }
            anim.SetBool("Finish", true);
            Finish = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        Finish = false;
        timelimit=canvasParameter.TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreRender((int)timelimit);

        TimeA((int)timelimit);
    }
}
