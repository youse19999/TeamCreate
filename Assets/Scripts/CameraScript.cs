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
        Debug.Log("Œ»İ‚Ìanim‚Í"+anim);
    }

    // Update is called once per frame
    void Update()
    {
        if(timecanvas.AnimFinish == true)
        {
            Debug.Log("ƒJƒƒ‰‚ğ•ÏX‚µ‚Ü‚·");
            anim.SetBool("GameMode", false);

            Debug.Log("¡‚ÌGameMode‚Í" + anim.GetBool("GameMode"));
        }
    }
}
