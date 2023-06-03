using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject optionsMenu;

    public void GameToOptions()
    {
        Time.timeScale = 0.0f;
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OptionsToGame()
    {
        Time.timeScale = 1.0f;
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
