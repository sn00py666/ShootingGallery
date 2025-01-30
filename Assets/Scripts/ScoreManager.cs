using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = $"{score}";
    }

    // Update is called once per frame
    private void Update()
    {
        // Optional: Call UpdateScoreDisplay() only if score changes, for better performance.
    }

    public void UpdateScore(int add_score)
    {
        score += add_score;
        scoreDisplay.text = $"{score}";
    }
    
}
