using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var totalScore = ScoreKeeper.TotalScore;
        GetComponent<Text>().text = "Score:" + totalScore.ToString();
        ScoreKeeper.Reset();
        Debug.Log(totalScore);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
