using UnityEngine;

public class Apples : MonoBehaviour
{
    public static GameController GameControllerScript;
    PlayerMovementController CAPlayer;
    LvlSliderController LvlsliderController;
    public int AppleBoost;
    Animator animator;
    private void Awake()
    {
        GameControllerScript = FindFirstObjectByType<GameController>();
        animator = transform.parent.GetComponentInChildren<Animator>();
        CAPlayer = transform.parent.GetComponent<PlayerMovementController>();
        LvlsliderController  = FindFirstObjectByType<LvlSliderController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            GameControllerScript.totalApples += 1 + AppleBoost;
            LvlsliderController.AddXp(5);
            Destroy(other.gameObject);
            CAPlayer.Gathering = true;
            animator.SetInteger("State", 4);
            Invoke(nameof(EndOfGathering), 0.1f);
        }
        else if (other.gameObject.CompareTag("UniqueApple"))
        {
            GameControllerScript.totalApples += 5 + AppleBoost;
            LvlsliderController.AddXp(8);
            Destroy(other.gameObject);
            CAPlayer.Gathering = true;
            animator.SetInteger("State", 4);
            Invoke(nameof(EndOfGathering), 0.1f);
        }
    }
    void EndOfGathering()
    {
        CAPlayer.Gathering = false;
    }
}
