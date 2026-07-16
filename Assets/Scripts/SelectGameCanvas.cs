using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGameCanvas : MonoBehaviour
{
    [SerializeField] private bool ChangeAnim;
    private Animator anim = null;


    void ChoiseGame()
    {
        if (ChangeAnim == true) { SceneManager.LoadScene("main"); }
        if (ChangeAnim == false) { SceneManager.LoadScene("Controls"); }
    }
    void ChangeAnimation()
    {
        //アニメーション関連
        anim.SetBool("StopTitle", true);
        if (ChangeAnim == true) { anim.SetBool("Change", true); }
        if (ChangeAnim == false) { anim.SetBool("Change", false); }
    }

    void Select()
    {
        if (!TitleCanvas.StopTitle) { return; }
        ChangeAnimation();

        if (Input.GetKey(KeyCode.A)) {ChangeAnim = true;}//Gameを選択
        if (Input.GetKey(KeyCode.D)) { ChangeAnim = false; }//Controlsを選択
        if (Input.GetKey(KeyCode.Space)) { ChoiseGame(); }//次の画面へ遷移
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeAnim = true;//最初はGameを選択するようにする
    }

    // Update is called once per frame
    void Update()
    {
       Select();
    }
}
