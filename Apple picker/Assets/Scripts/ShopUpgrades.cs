using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUpgrades : MonoBehaviour
{
    [SerializeField] int SpeedPrice;
    [SerializeField] int IncomingPrice;
    [SerializeField] int LogsPrice;
    [SerializeField] int StrengthPrice;

    [SerializeField] TextMeshProUGUI SpeedPriceText;
    [SerializeField] TextMeshProUGUI IncomingPriceText;
    [SerializeField] TextMeshProUGUI LogsPriceText;
    [SerializeField] TextMeshProUGUI StrengthPriceText;

    [SerializeField] TextMeshProUGUI ScoreText;

    ControlerAnimPlayer player;
    GameController gameController;
    LvlSliderController lvlSliderController;
    Apples ApplesScr;
    private void OnEnable()
    {
        player = FindObjectOfType<ControlerAnimPlayer>();
        gameController = FindObjectOfType<GameController>();
        lvlSliderController = FindObjectOfType<LvlSliderController>();
        ApplesScr = FindObjectOfType<Apples>();

        SpeedPriceText.text = $"Price: {SpeedPrice}";
        IncomingPriceText.text = $"Price: {IncomingPrice}";
        LogsPriceText.text = $"Price: {LogsPrice}";
        StrengthPriceText.text = $"Price: {StrengthPrice}";

        SpeedPriceText.outlineColor = Color.yellow;
        if (gameController.totalApples >= SpeedPrice) SpeedPriceText.outlineColor = Color.white;
        else SpeedPriceText.outlineColor = Color.black;

        IncomingPriceText.outlineColor = Color.yellow;
        if (gameController.totalApples >= IncomingPrice) IncomingPriceText.outlineColor = Color.white;
        else IncomingPriceText.outlineColor = Color.black;

        ScoreText.text = $"{gameController.totalApples}";

    }
    public void UpgradeSpeed()
    {
        if (gameController.totalApples >= SpeedPrice)
        {
            gameController.totalApples -= SpeedPrice;
            lvlSliderController.AddXp(20);
            SpeedPrice *= 2;
            player.speed += 0.3f;
            if (gameController.totalApples >= SpeedPrice)
                SpeedPriceText.outlineColor = Color.white;
            else
                SpeedPriceText.outlineColor = Color.black;

            SpeedPriceText.text = $"Price: {SpeedPrice}";
        }
        else
        {
                SpeedPriceText.outlineColor = Color.red;
        }
        ScoreText.text = $"{gameController.totalApples}";
    }

    public void UpgradeIncoming()
    {
        if (gameController.totalApples >= IncomingPrice)
        {
            gameController.totalApples -= IncomingPrice;
            lvlSliderController.AddXp(35);
            IncomingPrice *= 2;
            ApplesScr.AppleBoost += 1;
            if (gameController.totalApples >= IncomingPrice)
                IncomingPriceText.outlineColor = Color.white;
            else
                IncomingPriceText.outlineColor = Color.black;

            IncomingPriceText.text = $"Price: {IncomingPrice}";
        }
        else
        {
            IncomingPriceText.outlineColor = Color.red;
        }
        ScoreText.text = $"{gameController.totalApples}";
    }
}

