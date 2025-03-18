//Author: Small Hedge Games
//Date: 05/04/2024

namespace SHG.AnimatorCoder
{
    /// <summary> Complete list of all animation state names </summary>
    public enum Animations
    {
        //Player Anims
        Idle,
        Run,
        Jump,
        Gathering,
        LeftPunch,
        AxeSwing,
        //Bobr anims
        StandingUp,
        InjuredRun,
        PickingUp,
        SadIdle,
        Death,
        //Axe indicator anims
        NewAxe,
        AxeCrack,
        AxeDestroy,

        RESET  //Keep Reset
    }

    /// <summary> Complete list of all animator parameters </summary>
    public enum Parameters
    {
        //Change the list below to your animator parameters
        GROUNDED,
        FALLING
    }
}


