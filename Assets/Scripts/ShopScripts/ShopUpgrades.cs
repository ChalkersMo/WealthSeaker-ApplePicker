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

    PlayerMovementController player;
    GameController gameController;
    LvlSliderController lvlSliderController;
    private void OnEnable()
    {
        player = FindFirstObjectByType<PlayerMovementController>();
        gameController = FindFirstObjectByType<GameController>();
        lvlSliderController = FindFirstObjectByType<LvlSliderController>();


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
            IncomingPrice *= 2;

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

