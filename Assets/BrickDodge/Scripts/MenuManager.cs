using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    void Start()
    {
        GameObject.Find("TextScore").GetComponent<TextMesh>().text = PlayerPrefs.GetInt("Score").ToString();
        GameObject.Find("TextHighScore").GetComponent<TextMesh>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void LateUpdate()
    {
        if(Input.GetMouseButtonUp(0) )
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            
            if (!hitInfo)
            {
                SceneManager.LoadScene("Game"); 
            }
        }
    }
}
