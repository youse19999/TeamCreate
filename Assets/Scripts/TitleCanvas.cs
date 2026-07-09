using UnityEngine;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField] private CanvasScriptableObject canvasParameter;
    [SerializeField] private bool ChangeAnim;
    [SerializeField] private bool StopTitle;
    private Animator anim = null;

    void ChangeAnimation()
    {
        if (ChangeAnim == false) { anim.SetBool("Change", true); }
        if (ChangeAnim == true) { anim.SetBool("Change", false); }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeAnim = false;
        StopTitle = false;
    }

    void Select()
    {
        if (!StopTitle) { return; }

    }

    void Update()
    {
        if (transform.position.y <= 130) { 
            StopTitle = true;
            anim.SetBool("StopTitle", true);
        }
        if (StopTitle) { return; }
        transform.position += new Vector3(0, -canvasParameter.TitleMoveSpeed * Time.deltaTime, 0);
    }
}
