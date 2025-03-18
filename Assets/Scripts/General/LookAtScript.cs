using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
        target = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
