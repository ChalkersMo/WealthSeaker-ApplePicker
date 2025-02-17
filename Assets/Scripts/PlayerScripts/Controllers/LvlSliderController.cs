using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvlSliderController : MonoBehaviour
{
    public int CurrentLvl;
    Image Slider;
    TextMeshProUGUI LvlText;
    [SerializeField] GameObject LvlUpEffect;

    SpawningTreesController LvlSpawningTrees;
    private void Start()
    {
        Slider = gameObject.GetComponent<Image>();
        LvlText = Slider.GetComponentInChildren<TextMeshProUGUI>();
        LvlSpawningTrees = FindFirstObjectByType<SpawningTreesController>();
    }
    public void AddXp(float Xp)
    {
        Slider.fillAmount += Xp / 100;
        if (Slider.fillAmount >= 1)
        {
            Slider.fillAmount = 0.0001f;
            CurrentLvl++;
            LvlSpawningTrees.NewLvl(CurrentLvl);
            LvlText.text = CurrentLvl.ToString();
            LvlUpEffect.SetActive(true);
        }
    }
}
