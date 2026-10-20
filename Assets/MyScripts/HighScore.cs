using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private TMP_Text _UI_TEXT;
    static private int _SCORE = 1000;

    void Awake()
    {
        _UI_TEXT = GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        else 
        {
	    SCORE = 1000; 
        }
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; 
        SCORE = scoreToTry; 
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.DeleteKey("HighScore");            
		PlayerPrefs.Save();
            Debug.LogWarning("High Score reset to 1000");
        }
    }
}