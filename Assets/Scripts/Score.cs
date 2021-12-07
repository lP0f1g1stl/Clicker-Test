using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _score;

    [SerializeField] private Player _player;
    [SerializeField] private ObjectsData _objectlData;
    [SerializeField] private PlayerData _playerData;

    private int _curScore;

    private void Start()
    {
       _player.OnClick += ChangeScore;
        LoadScore();
        ChangeText();
    }
    public void ChangeScore(int id) 
    {
        _curScore += _objectlData.ObjectData[id].BasePrice;
        SaveScore();
        ChangeText();
    }
    private void SaveScore() 
    {
        _playerData.Score = _curScore;
    }
    private void LoadScore() 
    {
        _curScore = _playerData.Score;
    }
    private void ChangeText() 
    {
        _score.text = "Score: " + _curScore.ToString();
    }
    private void OnDestroy()
    {
        _player.OnClick -= ChangeScore;
    }
}
