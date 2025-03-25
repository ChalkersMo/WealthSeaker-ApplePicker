using UnityEngine;

public class ObjectActivatorController : MonoBehaviour
{
    [SerializeField] private GameObject Sign;
    [SerializeField] private int lvlToAtivate;

    private LookAtScript signLookAt;
    private void Start()
    {
        PlayerLvlController.PlayerLvlAction += NewLvl;
        if(Sign != null )
            signLookAt = Sign.GetComponent<LookAtScript>();
    }
    private void NewLvl(int currentLvl)
    {
        if(currentLvl == lvlToAtivate)
        {
            gameObject.SetActive(true);
            if(Sign != null)
            {
                Sign.SetActive(true);
                signLookAt.target = transform;
            }
                
        }
    }
}
