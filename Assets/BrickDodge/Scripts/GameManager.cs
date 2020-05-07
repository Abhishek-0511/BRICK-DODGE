using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int score;
    public int highScore;

    public int numberOfBlockDestroyed;
    
    public GameObject Block;

    public float SlowMotionTime;

          
    void Start()
    {
        score = 0;
        numberOfBlockDestroyed = 0;
        Block.GetComponent<Transform>();
        GameObject.Find("ScoreHUD").GetComponent<TextMesh>().text = score.ToString();
    }

	public void EndGame()
    {
        HighScore();
        StartCoroutine(SlowMotion());
    }

    IEnumerator SlowMotion()
    {
        Time.timeScale = 1 / SlowMotionTime;

        Time.fixedDeltaTime = Time.fixedDeltaTime / SlowMotionTime;

        yield return new WaitForSeconds(2f / SlowMotionTime);

        Time.timeScale = 1f;

        Time.fixedDeltaTime = Time.fixedDeltaTime * SlowMotionTime;

        SceneManager.LoadScene("Menu");
    }

    public void SetScore()
    {
        numberOfBlockDestroyed += 1;
        if(numberOfBlockDestroyed == 4 && !GameObject.FindObjectOfType<Player>().gameover)
        {
            numberOfBlockDestroyed = 0;
            score += 1;
            GameObject.Find("ScoreHUD").GetComponent<TextMesh>().text = score.ToString();
        }
    }

    public void HighScore()
    {
        PlayerPrefs.SetInt("Score", score);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.Save();
    }

    
}
