using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,
    LevelStarted,
    LevelFailed,
    LevelCompleted
}


public class GameCanvasControl : MonoBehaviour
{
    public static GameCanvasControl Instance;

    public GameplayPanelControl gameplayPanelControl;
    public GameOverPanelControl gameOverPanelControl;

    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        gameOverPanelControl.ResetPanel();
    }


    public void OnTouched()
    {
        //gameplayPanelControl.GameStarted();
    }

    public void OnTouchedWithdraw()
    {

    }

}
