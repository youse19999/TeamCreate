using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //アニメーションで呼び出す
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Title"); // Titleへ遷移
    }
}
