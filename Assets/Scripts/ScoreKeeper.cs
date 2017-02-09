using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text text;
         
    public static int TotalScore;

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
        TotalScore += points;

        text.text = TotalScore.ToString();
    }

    public static void Reset()
    {
        TotalScore = 0;
    }
}
