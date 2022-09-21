using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToLevel2 : MonoBehaviour
{
    public Score score;

    // Update is called once per frame
    void Update()
    {
        if (score.scoreValue == 1000)
        {
            SceneManager.LoadScene("Level_2");
        }
    }
}
