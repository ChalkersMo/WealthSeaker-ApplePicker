using SHG.AnimatorCoder;
using UnityEngine;

public class PlayerAnimationController : AnimatorCoder
{
    private Animator animator;

    void Start()
    {
        animator.GetComponentInChildren<Animator>();
        Initialize(animator);
    }

    public override void DefaultAnimation(int layer)
    {
        Play(new AnimationData(Animations.Idle));
    }

    public void Idle()
    {
        Play(new AnimationData(Animations.Idle, false, null, 0.2f));
    }

    public void Run()
    {
        Play(new AnimationData(Animations.Run, false, null, 0.2f));
    }

    public void Jump()
    {
        Play(new AnimationData(Animations.Jump, true, null, 0.2f));
    }

    public void PickUp()
    {
        Play(new AnimationData(Animations.Gathering, true, null, 0.2f));
    }

    public void Swing()
    {
        Play(new AnimationData(Animations.AxeSwing, true, null, 0.2f), 1);
    }

    public void Punch()
    {
        Play(new AnimationData(Animations.LeftPunch, true, null, 0.2f), 1);
    }
}
