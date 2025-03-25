using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvlSliderController : MonoBehaviour
{
    [SerializeField] private GameObject LvlUpEffect;

    private Image Slider;
    private TextMeshProUGUI LvlText;

    private PlayerLvlController playerLvlController;

    private void Start()
    {
        Slider = gameObject.GetComponent<Image>();
        LvlText = Slider.GetComponentInChildren<TextMeshProUGUI>();

        playerLvlController = FindFirstObjectByType<PlayerLvlController>();
        PlayerLvlController.PlayerXpUpAction += AddXp;
        PlayerLvlController.PlayerLvlAction += LvlUp;
    }

    private void AddXp(float Xp)
    {
        Slider.DOFillAmount(Xp / playerLvlController.XpNeedToLvlUp[playerLvlController.PlayerLvl], 1);
    }

    private void LvlUp(int lvl)
    {
        Slider.DOFillAmount(0.0001f, 1);
        LvlText.text = lvl.ToString();
        LvlUpEffect.SetActive(true);
    }
}
