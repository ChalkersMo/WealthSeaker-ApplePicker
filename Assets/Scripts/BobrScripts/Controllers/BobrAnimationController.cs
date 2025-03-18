using SHG.AnimatorCoder;
using UnityEngine;

public class BobrAnimationController : AnimatorCoder
{
    public float bobrRunAnimSpeed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Initialize(_animator);
    }

    public void Run()
    {
        Play(new AnimationData(Animations.InjuredRun, false, null, 0.1f));
    }

    public void PickUp()
    {
        Play(new AnimationData(Animations.PickingUp, false, null, 0.2f));
    }

    public void Death()
    {
        Play(new AnimationData(Animations.Death, false, null, 0.1f));
    }

    public void StandSad()
    {
        Play(new AnimationData(Animations.SadIdle, false, null, 0.1f));
    }

    public void RunAnimSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void StandUpSpeed(float speed)
    {
        _animator.SetFloat("StandingUpSpeed", speed);
    }

    public void StandUp()
    {
        Play(new AnimationData(Animations.StandingUp, false, null, 0.1f));
    }

    public bool IsAnimEnded(string name)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
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
