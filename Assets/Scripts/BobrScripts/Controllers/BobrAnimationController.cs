using SHG.AnimatorCoder;
using UnityEngine;

public class BobrAnimationController : AnimatorCoder
{
    public float bobrRunAnimSpeed;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Initialize(animator);
    }

    public void Run()
    {
        Play(new AnimationData(Animations.InjuredRun, false, null, 0.2f));
    }

    public void PickUp()
    {
        Play(new AnimationData(Animations.PickingUp, false, null, 0.2f));
    }

    public void Death()
    {
        Play(new AnimationData(Animations.Death, false, null, 0.1f));
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

    public override void DefaultAnimation(int layer)
    {
        Play(new AnimationData(Animations.StandingUp));
    }
}
