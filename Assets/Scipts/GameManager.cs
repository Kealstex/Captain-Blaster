using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public int curGunMode = 1;
    
    int _playerScore = 0;

    public void AddScore()
    {
        _playerScore++;
        scoreText.text = _playerScore.ToString();
    }

    public void PlayerDied()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0f;
    }

}
