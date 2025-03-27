using SHG.AnimatorCoder;
using UnityEngine;

public class AxeIndicator : AnimatorCoder
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Initialize(_animator);
    }
    public void RenewAxe()
    {
        Play(new AnimationData(Animations.NewAxe));
    }

    public void CrackAxe()
    {
        Play(new AnimationData(Animations.AxeCrack));
    }

    public void DestroyAxe()
    {
        Play(new AnimationData(Animations.AxeDestroy));
    }

    public override void DefaultAnimation(int layer)
    {
        Play(new AnimationData(Animations.NewAxe));
    }
}
