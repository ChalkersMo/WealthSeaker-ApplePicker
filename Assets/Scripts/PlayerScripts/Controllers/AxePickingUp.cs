using UnityEngine;

public class AxePickingUp : MonoBehaviour
{
    enum AxeType
    {
        Default,
        Unique,
        Golden
    };
    PlayerMovementController PlayerControl;

    GameObject AxeHolder;
    [SerializeField] AxeType type;
    private void Awake()
    {
        PlayerControl = FindFirstObjectByType<PlayerMovementController>();
        AxeHolder = GameObject.Find("AxeHolder");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < 3; i++)
                AxeHolder.transform.GetChild(i).gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }
}
