using UnityEngine;

public class AxePickingUp : MonoBehaviour
{
    enum AxeType
    {
        Default,
        Unique,
        Golden
    };
    ControlerAnimPlayer PlayerControl;

    GameObject AxeHolder;
    [SerializeField] AxeType type;
    private void Awake()
    {
        PlayerControl =  FindObjectOfType<ControlerAnimPlayer>();
        AxeHolder = GameObject.Find("AxeHolder");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < 3; i++)
                AxeHolder.transform.GetChild(i).gameObject.SetActive(false);

            PlayerControl.IsAxe = false;
            PlayerControl.IsUniqueAxe = false;
            PlayerControl.IsGoldenAxe = false;
            switch (type)
            {
                case AxeType.Default:
                    {
                        PlayerControl.IsAxe = true;
                        AxeHolder.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;

                case AxeType.Unique:
                    {                  
                        PlayerControl.IsUniqueAxe = true;
                        AxeHolder.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;

                case AxeType.Golden:
                    {            
                        PlayerControl.IsGoldenAxe = true;
                        AxeHolder.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }
}
