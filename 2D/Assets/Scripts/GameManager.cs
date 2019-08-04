using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float totalTimeLimit;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI gameoverText;

    float timeLimit;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        timeLimit = totalTimeLimit;
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit <= 0)
        {
            gameoverText.text = $"High Score {highScore}s \nPress R to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                timeLimit = totalTimeLimit;
                var zombies = FindObjectsOfType<Zombie>();
                foreach (var z in zombies)
                {
                    Destroy(z.gameObject);
                }
            }
            return;
        }
        gameoverText.text = $"High Score {highScore}s";
        timeLimit -=  Time.deltaTime;
        if (timeLimit <= 0)
        {
            timeLimit = 0;
            textMesh.text = $"You survived ONE minute. YOU WIN";
            var score = (int)(totalTimeLimit - timeLimit);
            if (score > highScore)
                highScore = score;
        }
        else
            textMesh.text = $"Time Left {timeLimit.ToString("#")}s";
    }
    public bool IsRunning()
    {
        return timeLimit > 0f;
    }
    public void PlayerHit()
    {
        textMesh.text = $"You faild to survive ONE minute. GAME OVER";
        var score = (int)(totalTimeLimit - timeLimit);
        if (score > highScore)
            highScore = score;
        timeLimit = 0f;
    }

    

}
