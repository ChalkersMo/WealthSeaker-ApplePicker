using TMPro;
using UnityEngine;

public class ShopVisibleling : MonoBehaviour
{
    [SerializeField] private GameObject ShopCanvas;
    [SerializeField] private GameObject TPCObj;
    [SerializeField] private ShopUpgrades _ShopUpgrades;

    private InteractionTablleController InteractionTable;
    private ControlerAnimPlayer CAP;

    private void Start()
    {
        CAP = FindFirstObjectByType<ControlerAnimPlayer>();
        InteractionTable = FindFirstObjectByType<InteractionTablleController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionTable.ShowTip("Press 'E' to shop");
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
                InteractionTable.CloseTip();
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
            InteractionTable.CloseTip();
    }

    public void OffShopCanvas()
    {
        Animator animator = ShopCanvas.GetComponent<Animator>();
        animator.SetBool("On", false);
        CAP.Gathering = false;
        TPCObj.SetActive(true);
        InteractionTable.ShowTip("Press 'E' to shop");
        ShopCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _ShopUpgrades.enabled = false;
    }
}
