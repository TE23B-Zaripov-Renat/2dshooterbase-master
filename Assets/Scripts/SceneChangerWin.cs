using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger1 : MonoBehaviour
{
    public void Changescene1()
    {
        SceneManager.LoadScene("GameStart");
    }
}
