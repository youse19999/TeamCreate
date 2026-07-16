using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PointCanvas : MonoBehaviour
{
    public TMP_Text ScoreText1P;
    public TMP_Text ScoreText2P;
    [SerializeField] private GameObject OneP;
    [SerializeField] private GameObject TwoP;
    GoalArea OnePlayer;
    GoalArea TwoPlayer;

    //1Pと2Pの値を入れ、それをTEXTで表示
    public void Point(int OneP,int TwoP)
    {
        ScoreText1P.text = OneP + "Point";
        ScoreText2P.text = TwoP + "Point";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnePlayer = OneP.GetComponent<GoalArea>();
        TwoPlayer = TwoP.GetComponent<GoalArea>();
        Debug.Log("Start");//デバック用
    }

    // Update is called once per frame
    void Update()
    {
        Point(OnePlayer.point, TwoPlayer.point);
    }
}
