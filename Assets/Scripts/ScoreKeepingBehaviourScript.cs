using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// 
/// updates the players score
/// 
public class ScoreKeepingBehaviourScript : MonoBehaviour
{
    /// 
    /// the player's actual score
    /// 
    public float score = 0.0f;

    /// 
    /// the text displayong the score
    /// 
    public Text Scoreboard;

    // Update is called once per frame
    void Update()
    {
        if (Scoreboard)
        {
            Scoreboard.text = score.ToString();
        }
    }
}
