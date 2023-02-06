using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Player _player;
    [SerializeField] private Finish _finish;
    [SerializeField] private Text _textPoints;

    private void OnEnable()
    {
        _player.Died+= OpenLosePanel;
        _finish.Finished += OpenWinPanel;
    }

    private void OnDisable()
    {
        _player.Died-= OpenLosePanel;
        _finish.Finished -= OpenWinPanel;
    }

    private void OpenLosePanel()
    {
        StopGame();
        _losePanel.SetActive(true);
    }

    private void OpenWinPanel()
    {
        StopGame();
        _victoryPanel.SetActive(true);
    }

    private void StopGame()
    {
        _endGamePanel.SetActive(true);
        Time.timeScale = 0;
        _textPoints.text = _player.Points.ToString();
    }
}
