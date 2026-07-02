using UnityEngine;
using TMPro;

public class PointCanvas : MonoBehaviour
{
    public TMP_Text PointText;

    public void Point(int point)
    {
        PointText.text = point + "Point";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        int kari = 0;

        Point(kari);
    }
}
