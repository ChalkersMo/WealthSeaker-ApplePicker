using UnityEngine;

public class BobrAnimationController : MonoBehaviour
{
    public float bobrRunAnimSpeed;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Run()
    {
        animator.SetTrigger("Run");
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

    public void StandUpSpeed(float speed)
    {
        animator.SetFloat("StandingUpSpeed", speed);
    }

    public bool IsAnimEnded(string name)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f && stateInfo.IsName(name))
        {
            return true;
        }
        else
            return false;
    }
}
