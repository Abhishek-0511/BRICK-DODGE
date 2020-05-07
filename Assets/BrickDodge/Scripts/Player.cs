using UnityEngine;

public class Player : MonoBehaviour {

    public float mapwidth;

    public bool gameover;

    void Start()
    {
        gameover = false;
    }
    
	void FixedUpdate()
    {
        
                if (!gameover)
                {
                    if (Input.GetMouseButton(0))
                    {
                
                        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                        if (hit.collider == null)
                        {
                            Move(curPosition.x);
                        }
                    }
                }
       
        
                 
    }

    void Move(float posX)
    {
        if (transform.position.x - 0.3f > posX && transform.position.x > -mapwidth )
        {
            transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, 0);
        }
        else if (transform.position.x + 0.3f < posX && transform.position.x < mapwidth )
        {
            transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, 0);
        }
    }



    void OnCollisionEnter2D()
    {
        gameover = true;
        FindObjectOfType<GameManager>().GetComponent<AudioSource>().Stop();
        GameObject.Find("GameoverSound").GetComponent<AudioSource>().Play();
        FindObjectOfType<GameManager>().EndGame();
    }
}
