using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject PanelSettings;
    public GameObject BT_Song;
    public Sprite SongOn;
    public Sprite SongOff;
    [SerializeField] TextMeshProUGUI HighestRecordText;

    public int PlaySongId = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PanelSettings.SetActive(false);
        HighestRecordText.text = $"Highest score: {PlayerPrefs.GetInt("HighScore")}";

        if (PlaySongId == 1)
        {
            BT_Song.GetComponent<Image>().sprite = SongOn;
        }
        else if (PlaySongId == 0)
        {
            BT_Song.GetComponent<Image>().sprite = SongOff;
        }
    }

    public void OnClickBT_Start()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickBT_Settings_On()
    {
        PanelSettings.SetActive(true);
    }

    public void OnClickBT_Settings_Off()
    {
        PanelSettings.SetActive(false);
    }

    public void OnClickButt_Soung()
    {
        if (PlaySongId == 0)
        {
            PlaySongId = 1;
            BT_Song.GetComponent<Image>().sprite = SongOn;
        }
        else if (PlaySongId == 1)
        {
            PlaySongId = 0;
            BT_Song.GetComponent<Image>().sprite = SongOff;
        }
    }
}