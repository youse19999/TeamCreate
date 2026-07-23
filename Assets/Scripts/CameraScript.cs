using UnityEngine;

public class CameraScript : MonoBehaviour
{
    TimeCanvas timecanvas;
    private Animator anim = null;
    [SerializeField] private GameObject UICanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timecanvas = UICanvas.GetComponent<TimeCanvas>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timecanvas.AnimFinish == true)
        {
            anim.SetBool("GameMode", false);
        }
    }
}
