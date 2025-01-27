using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numOfBullets = 5;
    public int bulletCountNow = 5;
    public Image[] bullets;
    public Sprite fullBullet;
    public Sprite emptyBullet;
    public Animator anim;
    [SerializeField] private FinalResults fr;
    private ScoreManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        anim = FindObjectOfType<Animator>();
    }

    private void FixedUpdate()
    {   
        if (bulletCountNow > numOfBullets)
        {
            bulletCountNow = numOfBullets;
        }
        for (int i = 0; i < numOfBullets; i++)
        {
            if (i <  bulletCountNow)
            {
                bullets[i].sprite = fullBullet;
            }
            else
            {
                bullets[i].sprite = emptyBullet;
            }
            if (i < numOfBullets)
            {
                bullets[i].enabled = true;
            }
            else
            {
                bullets[i].enabled = false;
            }
        }   
    }
    public void StopAnim()
    {
        Debug.Log("финал");
        fr.StartFinal(sm.score);
        gameObject.SetActive(false);
    }
}
