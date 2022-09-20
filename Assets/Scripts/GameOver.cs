using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Canvas _ui;

    public void ClickOnButton()
    {
        _ui.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
        _player.ChangeHealth();
    }

    public void StopGame()
    {
        _ui.gameObject.SetActive(false);
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
