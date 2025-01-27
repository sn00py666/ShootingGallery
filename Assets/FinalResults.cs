using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalResults : MonoBehaviour
{
    public Image FinalScenes;
    public TextMeshProUGUI scoreDisplay;
    public Sprite Res0_19;
    public Sprite Res20_39;
    public Sprite Res40_50;

    public float TimeFinalScene = 5;
    public string sceneName = "Start";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartFinal(int score)
    {
        transform.gameObject.SetActive(true);
        scoreDisplay.text = scoreDisplay.text = $"{score} {GetScoreSuffix(score)}"; ;
        Debug.Log(scoreDisplay.text);
        if (0 <= score && score <= 19)
        {
            FinalScenes.sprite = Res0_19;
        }
        else if (20 <= score && score <= 39)
        {
            FinalScenes.sprite = Res20_39;
        }
        else
        {
            FinalScenes.sprite = Res40_50;
        }

        // Start the coroutine to wait 5 seconds before loading the "Start" scene
        StartCoroutine(WaitAndLoadStartScene());
    }

    private IEnumerator WaitAndLoadStartScene()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(TimeFinalScene);

        // Load the "Start" scene
        SceneManager.LoadScene(sceneName);
    }
    private string GetScoreSuffix(int value)
    {
        int lastDigit = value % 10;
        int lastTwoDigits = value % 100;

        if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
        {
            return "очков";
        }

        switch (lastDigit)
        {
            case 1:
                return "очко";
            case 2:
            case 3:
            case 4:
                return "очка";
            default:
                return "очков";
        }
    }
}
