using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Changescene()
    {
        SceneManager.LoadScene("Main");
    }
}
