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

    public bool IsNeedButtonPress { get => false; set => IsNeedButtonPress = false; }

    [SerializeField] private int count;
    [SerializeField] private float xpFromApple;

   private ItemsStorage storage;
    private ApplePool pool;

    private PlayerLvlController playerLvlController;
    private void Awake()
    {
        transform.DOScale(0, 0);
        storage = FindFirstObjectByType<ItemsStorage>();
        pool = FindFirstObjectByType<ApplePool>();
        playerLvlController = FindFirstObjectByType<PlayerLvlController>();
    }
    private void OnEnable()
    {
        transform.DOScale(1, 0.5f);
    }

    public void PickUp() 
    {
        storage.AddApples(Count);
        playerLvlController.XpUp(xpFromApple);
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
