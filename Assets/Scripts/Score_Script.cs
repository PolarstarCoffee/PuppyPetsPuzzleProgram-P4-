using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Score_Script : MonoBehaviour
{
   public static Score_Script instance {  get; private set; }

    private int _score;

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;

            scoreText.SetText($" Score = {_score}");

            if (_score >= 200)
            {
                SceneManager.LoadScene("End Scene");
                Debug.Log("Max Score has been reached");
            }
        }
    }


    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => instance = this;
}
