using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text myText;



    public void Score(int points)
    {
        score += points;
        myText.text = score.ToString();
    }


    public static void Reset()
    {
        score = 0;
    }



    // Use this for initialization
    void Start () {
        myText = GetComponent<Text>();
        Reset();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
