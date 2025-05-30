using DG.Tweening;
using UnityEngine;

public class AxePickingUp : MonoBehaviour, IPickupable
{
    public int Count { get => Count = 1; set => Count = 1; }
    public bool IsNeedButtonPress { get => true; set => IsNeedButtonPress = true; }

    [SerializeField] private string AxeDamageDealerName;

    private AttacksController attackController;
    private InteractionTablleController interactionTablleController;
    private AxePool axePool;

    private void Awake()
    {
        attackController = FindFirstObjectByType<AttacksController>();
        interactionTablleController = FindFirstObjectByType<InteractionTablleController>();
        axePool = GetComponentInParent<AxePool>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Disappear), 7);
        Invoke(nameof(DisappearAnim), 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionTablleController.ShowTip("[E] Axe");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionTablleController.CloseTip();
        }
    }
    public void PickUp()
    {
        interactionTablleController.CloseTip();
        attackController.ChangeDamageDealer(AxeDamageDealerName);
        axePool.ReturnAxe(gameObject);
    }
    private void DisappearAnim()
    {
        transform.DOMoveY(transform.position.y - 0.35f, 5);
    }
    private void Disappear()
    {
        interactionTablleController.CloseTip();
        axePool.ReturnAxe(gameObject);
    }
}
