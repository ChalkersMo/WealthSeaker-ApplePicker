using UnityEngine;

public class SpawningTreesController : MonoBehaviour
{
    [SerializeField] private GameObject[] TreesZoneToActive;
    [SerializeField] private GameObject Sign;

    public void NewLvl(int currentLvl)
    {
        switch (currentLvl)
        {
            case 3:
                {
                    TreesZoneToActive[0].SetActive(true);
                    Sign.SetActive(true);
                    Sign.GetComponent<LookAtScript>().target = TreesZoneToActive[0].transform;
                } 
                break;

            case 7:
                {
                    TreesZoneToActive[1].SetActive(true);
                    Sign.SetActive(true);
                    Sign.GetComponent<LookAtScript>().target = TreesZoneToActive[1].transform;
                }
                break;

            case 15:
                {
                    TreesZoneToActive[2].SetActive(true);
                    Sign.SetActive(true);
                    Sign.GetComponent<LookAtScript>().target = TreesZoneToActive[2].transform;
                }
                break;

            case 30:
                {
                    TreesZoneToActive[3].SetActive(true);
                    Sign.SetActive(true);
                    Sign.GetComponent<LookAtScript>().target = TreesZoneToActive[3].transform;
                }
                break;

            default: break;
        }
    }
}
