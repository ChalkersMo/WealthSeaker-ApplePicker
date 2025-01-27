using UnityEngine;

public class BobrAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PickUp()
    {
        animator.SetTrigger("PickUp");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    public void RunAnimSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }
}
