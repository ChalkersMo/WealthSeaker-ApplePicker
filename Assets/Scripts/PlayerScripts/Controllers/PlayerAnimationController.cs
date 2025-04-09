using SHG.AnimatorCoder;
using UnityEngine;

public class PlayerAnimationController : AnimatorCoder
{
    private Animator _animator;
    private string lastAnimationName;
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        Initialize(_animator);
    }

    public override void DefaultAnimation(int layer)
    {
        Play(new AnimationData(Animations.Idle), layer);
    }

    public void Idle()
    {
        Play(new AnimationData(Animations.Idle, false, null, 0.1f));
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
        Play(new AnimationData(Animations.Gathering, false, null, 0));
    }

    public void Swing()
    {
        Play(new AnimationData(Animations.AxeSwing, false, new AnimationData(Animations.RESET, false, null, 0.1f), 0.2f), 1);
    }

    public void Punch()
    {
        Play(new AnimationData(Animations.LeftPunch, false, new AnimationData(Animations.RESET, false, null, 0.1f), 0.2f), 1);
    }

    public void ChangePickingUpSpeed(float speed)
    {
        _animator.SetFloat("PickingUpSpeed", speed);
    }

    public bool IsAnimationFinished(string name)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        AnimatorTransitionInfo transitionInfo = _animator.GetAnimatorTransitionInfo(0);

        return stateInfo.IsName(name) && stateInfo.normalizedTime >= 1.0f && !transitionInfo.anyState;
    }


    public bool CheckAnimationState(string targetAnimationName)
    {
        if (_animator == null) return false;

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        string currentAnimation = stateInfo.fullPathHash.ToString();

        if (currentAnimation != lastAnimationName)
        {
            lastAnimationName = currentAnimation;
            return stateInfo.IsName(targetAnimationName);
        }

        return false;
    }
}
