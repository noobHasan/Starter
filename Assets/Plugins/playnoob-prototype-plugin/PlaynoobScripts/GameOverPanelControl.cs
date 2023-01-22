using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelControl : MonoBehaviour
{
    public static GameOverPanelControl Instance;

    public bool useBGColor;
    public bool useFailBanner;
    public bool useBanner;
    public bool useTextUI;
    public bool useButtonUI;

    public Image BGImage;
    public Color BGColor;

    public GameObject HiddenNextButton;
    public TextMeshProUGUI tapToNextText;


    public Button NextButton;
    public Sprite CompleteButtonSprite, FailButtonSprite;
    public TextMeshProUGUI NextButtonText;

    public Image LevelStatePanel;
    public Sprite CompleteBannerSprite, FailBannerSprite;
    public TextMeshProUGUI LevelStateText;

    public GameObject FailBanner;


    private void Start()
    {
    }

    private void Awake()
    {
        Instance = this;
    }


    public void OnNextButtonPressed()
    {
        LevelLoader.Instance.LoadLevel();
    }

    public void EnablePanel(GameState gameState, float appearDelay)
    {

        if (GameCanvasControl.Instance.gameState == GameState.LevelCompleted ||
            GameCanvasControl.Instance.gameState == GameState.LevelFailed) return;


        PlayerPrefs.SetInt(PlaynoobConstants.GamesPlayed, PlayerPrefs.GetInt(PlaynoobConstants.GamesPlayed) + 1);

        if (gameState == GameState.LevelCompleted)
        {
            GameCanvasControl.Instance.gameState = GameState.LevelCompleted;

            //***********If the Game is tested with Voodoo and after Importing TinySauce***********//
            //-------------------------------------------------------------------------------------//

            //TODO: If Game does not have any levels enable the following code block
            //TinySauce.OnGameFinished(0); // Score = 0

            //TODO: If Game has levels enable the following code block
            //TinySauce.OnGameFinished(true, 0, levelNumber: PlayerPrefs.GetInt(Constants.CurrentLevel).ToString()); //Score = 0

            //***********If the Game is tested with Azur and after Importing TinySauce***********//
            //-------------------------------------------------------------------------------------//

            //TODO: Uncomment the folling line


            LevelLoader.Instance.LevelCompleted();
            tapToNextText.text = "tap to continue";
            NextButton.image.sprite = CompleteButtonSprite;
            NextButtonText.text = "next";

            LevelStatePanel.sprite = CompleteBannerSprite;
            LevelStateText.text = "level \n completed!";


        }
        else
        {
            GameCanvasControl.Instance.gameState = GameState.LevelFailed;

            //***********If the Game is tested with Voodoo and after Importing TinySauce***********//
            //-------------------------------------------------------------------------------------//

            //TODO: If Game does not have any levels enable the following code block
            //TinySauce.OnGameFinished(0); // Score = 0

            //TODO: If Game has levels enable the following code block
            //TinySauce.OnGameFinished(false, 0, levelNumber: PlayerPrefs.GetInt(Constants.CurrentLevel).ToString()); //Score = 0

            //***********If the Game is tested with Azur and after Importing TinySauce***********//
            //-------------------------------------------------------------------------------------//

            //TODO: Uncomment the folling line



            tapToNextText.text = "tap to retry";
            NextButton.image.sprite = FailButtonSprite;
            NextButtonText.text = "retry";

            LevelStatePanel.sprite = FailBannerSprite;
            LevelStateText.text = "level \n failed!";

        }


        DOVirtual.DelayedCall(appearDelay, () =>
        {

            GameplayPanelControl.Instance.HidePanel();
            float delay = 0f;

            if (useBGColor)
            {
                BGImage.enabled = true;
            }

            if (useFailBanner && gameState == GameState.LevelFailed)
            {
                FailBanner.transform.DOScale(1f, .5f).SetEase(Ease.Linear);
                FailBanner.SetActive(true);
                delay += .6f;
            }

            else if (useBanner)
            {
                LevelStatePanel.transform.DOScale(1f, .35f).SetEase(Ease.OutBack);
                LevelStatePanel.gameObject.SetActive(true);
                delay += .2f;
            }

            if (useTextUI)
            {
                tapToNextText.DOFade(1f, .25f).SetDelay(delay).OnComplete(() =>
                {
                    HiddenNextButton.SetActive(true);
                });

                tapToNextText.gameObject.SetActive(true);
            }
            else
            {
                NextButton.transform.DOScale(1f, .25f).SetEase(Ease.OutBack).SetDelay(delay);
                NextButton.gameObject.SetActive(true);
            }
        });


        gameObject.SetActive(true);
    }

    public void ResetPanel()
    {
        BGImage.enabled = false;
        BGImage.color = BGColor;

        HiddenNextButton.SetActive(false);
        tapToNextText.DOFade(0f, 0f);
        NextButton.transform.localScale = Vector3.zero;
        NextButton.gameObject.SetActive(false);

        LevelStatePanel.transform.localScale = .7f * Vector3.one;
        LevelStatePanel.gameObject.SetActive(false);

        FailBanner.transform.localScale = Vector3.zero;
        FailBanner.SetActive(false);

    }
}
