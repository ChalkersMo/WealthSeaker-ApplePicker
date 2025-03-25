using System;
using UnityEngine;

public class PlayerLvlController : MonoBehaviour
{
    public int PlayerLvl;
    public float[] XpNeedToLvlUp;

    public static Action<int> PlayerLvlAction;
    public static Action<float> PlayerXpUpAction;

    private float currentXp;

    private void LvlUp()
    {
        PlayerLvl++;
        currentXp = 0;
        PlayerLvlAction?.Invoke(PlayerLvl);
    }

    public void XpUp(float xp)
    {
        currentXp += xp;
        PlayerXpUpAction?.Invoke(currentXp);
        if (XpNeedToLvlUp[PlayerLvl] <= currentXp)
        {
            float tempXp = currentXp;
            LvlUp();
            if (tempXp > 0)
                XpUp(tempXp);
        }
    }
}
