using SHG.AnimatorCoder;
using UnityEngine;

public class PlayerAnimationController : AnimatorCoder
{
    private Animator animator;
    private string lastAnimationName;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Initialize(animator);
    }

    public override void DefaultAnimation(int layer)
    {
        Play(new AnimationData(Animations.Idle), layer);
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
        Play(new AnimationData(Animations.Jump, false, null, 0.2f));
    }

    public void PickUp()
    {
        Play(new AnimationData(Animations.Gathering, false, null, 0.2f));
    }

    public void Swing()
    {
        Play(new AnimationData(Animations.AxeSwing, false, new AnimationData(Animations.RESET, false, null, 0.1f), 0.2f), 1);
    }

    public void Punch()
    {
        Play(new AnimationData(Animations.LeftPunch, false, new AnimationData(Animations.RESET, false, null, 0.1f), 0.2f), 1);
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

    public bool CheckAnimationState(string targetAnimationName)
    {
        if (animator == null) return false;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        string currentAnimation = stateInfo.fullPathHash.ToString();

        if (currentAnimation != lastAnimationName)
        {
            lastAnimationName = currentAnimation;
            return stateInfo.IsName(targetAnimationName);
        }

        return false;
    }
}
