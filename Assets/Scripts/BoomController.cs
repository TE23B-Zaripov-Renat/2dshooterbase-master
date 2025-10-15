using UnityEngine;

public class BoomController : MonoBehaviour
{
        void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }
}