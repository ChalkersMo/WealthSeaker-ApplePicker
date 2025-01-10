using TMPro;
using UnityEngine;

public class ShopVisibleling : MonoBehaviour
{
    [SerializeField] GameObject ShopCanvas;
    [SerializeField] GameObject KeyItteracting;
    [SerializeField] GameObject TPCObj;
    [SerializeField] ShopUpgrades _ShopUpgrades;
    ControlerAnimPlayer CAP;

    private void Start()
    {
        CAP = FindFirstObjectByType<ControlerAnimPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyItteracting.SetActive(true);
            TextMeshPro InteractingText = KeyItteracting.GetComponentInChildren<TextMeshPro>();
            InteractingText.text = "Press 'E' to shop";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                CAP.Gathering = true;
                TPCObj.SetActive(false);
                KeyItteracting.SetActive(false);
                ShopCanvas.SetActive(true);
                _ShopUpgrades.enabled = true;
                Animator animator = ShopCanvas.GetComponent<Animator>();
                animator.SetBool("On", true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            KeyItteracting.SetActive(false);
    }

    public void OffShopCanvas()
    {
        Animator animator = ShopCanvas.GetComponent<Animator>();
        animator.SetBool("On", false);
        CAP.Gathering = false;
        TPCObj.SetActive(true);
        KeyItteracting.SetActive(true);
        ShopCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _ShopUpgrades.enabled = false;
    }
}
