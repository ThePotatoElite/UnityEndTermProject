using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    
    public void Pause()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Pause
            : GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
        PauseMenu.SetActive(true);
    }
    public void Resume()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Pause
            : GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
        PauseMenu.SetActive(false);
    }

    public void Settings()
    {

    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
