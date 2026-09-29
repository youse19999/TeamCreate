using UnityEngine;

public class ResultPlayer : MonoBehaviour
{
    TimeCanvas timecanvas;
    [SerializeField] private GameObject UICanvas;
    private Animator anim = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timecanvas = UICanvas.GetComponent<TimeCanvas>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timecanvas.AnimFinish==true)
        {
            anim.SetBool("Finish",true);
        }
    }
}
