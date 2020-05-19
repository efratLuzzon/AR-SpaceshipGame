using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    //public GameObject paddle;
    //public collison col;
    public int score = 0;
    // the score text
    Text text;
    // Start is called before the first frame update
    void Start()
    {
     
//col = GetComponent<collison>();
    }

    // Update is called once per frame
    void Update()
    {
        // display the score of each player
//score = col.score;
        text.text = score.ToString();
    }
    public void updateScore(int addScore)
    {
        print("method" + addScore);
        score = score + addScore;
    }
}