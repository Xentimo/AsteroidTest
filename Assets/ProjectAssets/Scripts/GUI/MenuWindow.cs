using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : MonoBehaviour
{
    public event Action onStartGame;
    public event Action onResume;
    public event Action onExitDesctop;
    
    [SerializeField] Button _startButton;
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _exitButton;
    [SerializeField] TMP_Text _title;

    void Awake()
    {
        _startButton.onClick.AddListener(()=>onStartGame?.Invoke());
        _resumeButton.onClick.AddListener(()=>onResume?.Invoke());
        _exitButton.onClick.AddListener(()=>onExitDesctop?.Invoke());
    }

    public void ShowNew()
    {
        _startButton.gameObject.SetActiveWithCheck(true);
        _resumeButton.gameObject.SetActiveWithCheck(false);
        
        _title.gameObject.SetActiveWithCheck(false);
        gameObject.SetActiveWithCheck(true);
    }
    public void ShowResume()
    {
        _startButton.gameObject.SetActiveWithCheck(false);
        _resumeButton.gameObject.SetActiveWithCheck(true);
        
        _title.gameObject.SetActiveWithCheck(true);
        _title.text = "PAUSE";
        gameObject.SetActiveWithCheck(true);
    }
    public void ShowReplay(int finalScore)
    {
        _startButton.gameObject.SetActiveWithCheck(true);
        _resumeButton.gameObject.SetActiveWithCheck(false);
        
        _title.gameObject.SetActiveWithCheck(true);
        _title.text = $"GAME OVER <br> final score: {finalScore}";
        gameObject.SetActiveWithCheck(true);
    }
    public void Hide()
    {
        gameObject.SetActiveWithCheck(false);
    }
}
