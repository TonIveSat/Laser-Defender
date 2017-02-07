using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text text;
         
    private int score;

	// Use this for initialization
	void Start ()
    {
        Reset();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Score(int points)
    {
        score += points;

        text.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        text.text = "0";
    }
}
