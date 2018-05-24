using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
    private Text myText;



    public void Score(int points)
    {
        this.score += points;
        myText.text = score.ToString();
    }


    public void Reset()
    {
        this.score = 0;
        myText.text = score.ToString();

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
