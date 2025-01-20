using TMPro;
using UnityEngine;

public class Logs : MonoBehaviour
{
    [SerializeField] int Hp;
    [SerializeField] GameObject ReplacementObj;
    GameObject AxeHolder;
    ControlerAnimPlayer CAP;
    enum LogsType
    {
        Default,
        Unique,
        Golden
    }
    [SerializeField] LogsType logsType;
    private void Awake()
    {
        CAP = FindFirstObjectByType<ControlerAnimPlayer>();
        AxeHolder = GameObject.Find("AxeHolder");
    }
    private void OnTriggerStay(Collider other)
    {
        CAP.ItteractionSign.SetActive(true);
        TextMeshPro text = CAP.ItteractionSign.GetComponentInChildren<TextMeshPro>();
        text.text = "Press 'E' to cut down";
        if(Input.GetKeyDown(KeyCode.E))
        {
            switch (logsType)
            {
                case LogsType.Default:
                    {
                        if(CAP.IsAxe || CAP.IsUniqueAxe || CAP.IsGoldenAxe)
                        {
                            Hp -= CAP.playerStrength;                       
                        }
                    }
                    break;
                case LogsType.Unique:
                    {
                        if (CAP.IsUniqueAxe || CAP.IsGoldenAxe)
                        {
                            Hp -= CAP.playerStrength;
                        }
                    }
                    break;
                case LogsType.Golden:
                    {
                        if (CAP.IsGoldenAxe)
                        {
                            Hp -= CAP.playerStrength;
                        }
                    }
                    break;
            }
            if (Hp <= 0)
            {
                for (int i = 0; i < 3; i++)
                    AxeHolder.transform.GetChild(i).gameObject.SetActive(false);

                CAP.IsAxe = false;
                CAP.IsUniqueAxe = false;
                CAP.IsGoldenAxe = false;

                Instantiate(ReplacementObj);
                CAP.ItteractionSign.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CAP.ItteractionSign.SetActive(false);
    }
}
