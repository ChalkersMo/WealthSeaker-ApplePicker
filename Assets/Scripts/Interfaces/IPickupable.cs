public interface IPickupable
{
    int Count { get; set; }
    bool IsNeedButtonPress { get; set; }

    void PickUp();
}
