using DG.Tweening;
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

    private ItemsStorage storage;
    private ApplePool pool;

    private void Awake()
    {
        transform.DOScale(0, 0);
        storage = FindFirstObjectByType<ItemsStorage>();
        pool = FindFirstObjectByType<ApplePool>();
    }
    private void OnEnable()
    {
        transform.DOScale(1, 0.5f);
    }

    public void PickUp() 
    {
        storage.AddApples(Count);
        transform.DOScale(0, 1f).SetEase(Ease.InElastic);
        Invoke(nameof(ReturnAppleToPool), 1);
    }

    public void BobrPickUp()
    {
        transform.DOScale(0, 1f).SetEase(Ease.InElastic);
        Invoke(nameof(ReturnAppleToPool), 1);
    }

    private void ReturnAppleToPool()
    {
        pool.ReturnBusyApple(gameObject);
    }
}
