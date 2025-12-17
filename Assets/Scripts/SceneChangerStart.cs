using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangerStart : MonoBehaviour
{
    public void Changescene()
    {
        SceneManager.LoadScene("Main");
    }
}
