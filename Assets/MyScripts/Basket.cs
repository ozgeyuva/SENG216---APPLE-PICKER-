using UnityEngine;

public class Basket : MonoBehaviour
{

                 //public ScoreCounter scoreCounter;
   
    void Start()
    {
        GameObject ScoreGO = GameObject.Find("ScoreCounter");

              //scoreCounter = ScoreGO.GetComponent<ScoreCounter>();
    }

    
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;   

        mousePos2D.z = -Camera.main.transform.position.z; 



        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;   
        this.transform.position = pos;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            
            Destroy(other.gameObject);
        }
    

            //scoreCounter.score += 100;
            //HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        }
    }


