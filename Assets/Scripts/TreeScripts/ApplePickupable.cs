using TMPro;
using UnityEngine;

public class ApplePickupable : MonoBehaviour, IPickupable
{
    public int Count
    {
        get { return count; }
        set
        {
            Count = count;
        }
    }
    [SerializeField] private int count;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    private ItemsStorage storage;

    private void Awake()
    {
        storage = FindFirstObjectByType<ItemsStorage>();
    }

    public void PickUp() 
    {
        storage.ApplesCount += Count;
        textMeshPro.text = storage.ApplesCount.ToString();
        Destroy(gameObject, 0.5f);
    }

}
