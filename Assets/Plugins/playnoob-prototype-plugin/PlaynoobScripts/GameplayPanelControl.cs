using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameplayPanelControl : MonoBehaviour
{
    public static GameplayPanelControl Instance;

    public bool useLevelNumber;
    public bool useProgressBar;
    public bool useTapControlTutorial;
    public bool useHandSliderTutorial;

    public TextMeshProUGUI levelNumberText;
    public GameObject progressBar;
    public Image progressFillBar;
    public TextMeshProUGUI tapToPlayText;
    public GameObject UnloadText;
    public HandTutorialControl handTutorialControl;

    private void Awake()
    {
        Instance = this;

        if (!useLevelNumber) levelNumberText.gameObject.SetActive(false);
        if (!useProgressBar) progressBar.SetActive(false);
        if (!useTapControlTutorial) tapToPlayText.gameObject.SetActive(false);


        if (!LevelLoader.Instance.isInitScene)
        {
            LevelLoader.Instance.SetLevelIndexForDirectPlay();
        }


    }

    private void OnEnable()
    {
        if (useLevelNumber)
        {
            levelNumberText.text = "level " + PlayerPrefs.GetInt(PlaynoobConstants.CurrentLevel).ToString();
        }

        if (useProgressBar)
        {
            progressFillBar.fillAmount = 0f;
        }
        /*
        if (useTapControlTutorial)
        {
            PlaynoobConstants.FadeInOutAnimation(tapToPlayText, .5f, .35f);
        }
        */
        else if (useHandSliderTutorial)
        {
            handTutorialControl.gameObject.SetActive(true);
            handTutorialControl.EnableHandAnimation();
        }
    }


    public void GameStarted()
    {
        if (GameCanvasControl.Instance.gameState == GameState.None)
        {
            GameCanvasControl.Instance.gameState = GameState.LevelStarted;

            //***********If the Game is tested with Voodoo and after Importing TinySauce***********//
            //-------------------------------------------------------------------------------------//

            //TODO: If Game does not have any levels enable the following code block
            //TinySauce.OnGameStarted();

            //TODO: If Game has levels enable the following code block
            //TinySauce.OnGameStarted(levelNumber: PlayerPrefs.GetInt(Constants.CurrentLevel).ToString());



            //***********If the Game is tested with Azur ***********//
            //-------------------------------------------------------------------------------------//

            //TODO: Uncomment the folling line



            DOTween.Kill(tapToPlayText.gameObject.name);
            tapToPlayText.DOFade(0f, .25f).OnComplete(() =>
            {
                tapToPlayText.gameObject.SetActive(false);
            });
            handTutorialControl.DisablePanel();
        }


    }

    public void HidePanel()
    {
        levelNumberText.gameObject.SetActive(false);
        progressBar.SetActive(false);
        tapToPlayText.gameObject.SetActive(false);
        handTutorialControl.gameObject.SetActive(false);

    }

    public void ProgressFillBarControl(float fillAmount)
    {
        //TODO: Write your own code, depending on the game how you want to fill the progress bar

        progressFillBar.fillAmount = fillAmount;
    }
}
