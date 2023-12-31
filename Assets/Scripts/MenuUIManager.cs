using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button settingsButton;

    [Space(7)]

    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject settingsImage;

    [Space(7)]

    [SerializeField]
    private Text recordText;

    [SerializeField]
    private AnimationUI animations;

    private void Start()
    {
        ButtonClickAction();

        SetRecordText();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }
        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                animations.Click(settingsButton);
                animations.OpenPanel(settingsPanel, settingsImage);
            });
        }
    }

    private void SetRecordText()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            recordText.text = "Лучший результат: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            recordText.text = "Лучший результат: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
