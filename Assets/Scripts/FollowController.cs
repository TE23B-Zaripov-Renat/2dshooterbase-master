using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = target.transform.position.x;

        transform.position = pos;
    }
}
