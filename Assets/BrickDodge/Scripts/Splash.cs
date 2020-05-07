using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    bool trigger;


    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update ()
    {
        if(transform.position.y >= 0 )
        {
            float y = transform.position.y;

            transform.position = new Vector2(0, y - 0.1f);
        }
                
        if (transform.position.y <= 0 && !trigger)
        {
            trigger = true;

            StartCoroutine(gotoMenu());
        }
    }

    IEnumerator gotoMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
