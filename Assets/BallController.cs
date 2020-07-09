using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool gamePaused;
    Rigidbody2D ball;
    int player1Score = 0;
    int player2Score = 0;
    int roundCount = 0;
    GameObject scoreboard;

    Vector3 initialPosition;

    float maxVelocity = 25f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        scoreboard = GameObject.FindWithTag("Scoreboard");
        scoreboard.SetActive(false);
        pushBall();
        gamePaused = false;
    }

    void Update()
    {
        ball.velocity = Vector2.ClampMagnitude(ball.velocity, maxVelocity);

        if (Input.GetKeyDown("space"))
        {
            if (!gamePaused) return;

            scoreboard.SetActive(false);
            pushBall();
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }

    void pushBall()
    {
        if (roundCount % 2 == 0)
        {
            ball.velocity = new Vector3(1f * 8f, 0, 0);
        }
        else
        {
            ball.velocity = new Vector3(-1f * 8f, 0, 0);
        }
    }

    public void changeP1Score(int amount)
    {
        player1Score += amount;
        resetAndPrintCurrentStatus();
    }

    public void changeP2Score(int amount)
    {
        player2Score += amount;
        resetAndPrintCurrentStatus();
    }

    void resetAndPrintCurrentStatus()
    {

        gamePaused = true;

        roundCount++;

        Player1Controller p1 = GameObject.FindWithTag("Player1")
            .GetComponent<Player1Controller>();

        Player2Controlller p2 = GameObject.FindWithTag("Player2")
            .GetComponent<Player2Controlller>();

        p1.resetPos();
        p2.resetPos();

        transform.position = initialPosition;

        Time.timeScale = 0f;
        scoreboard.SetActive(true);
        GameObject.FindWithTag("Score1")
            .GetComponent<UnityEngine.UI.Text>().text = player1Score + "";

        GameObject.FindWithTag("Score2")
            .GetComponent<UnityEngine.UI.Text>().text = player2Score + "";
    }
}
