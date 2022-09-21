using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

    
public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreCounterText;
    public int scoreValue;

    private void Awake()
    {
        Laser.LaserDamageScore += RunCo;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = scoreValue.ToString();

    }

    private IEnumerator Pulse()
    {
        for (float i = 1f; i >= 1.2f; i += 0.05f)
        {
            scoreCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreCounterText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        scoreValue += 200;

        for (float i = 1.2f; i >= 1f; i -= 0.05f)
        {
            scoreCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreCounterText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());
    }

    private void OnDestroy()
    {
        Laser.LaserDamageScore -= RunCo;
    }
}
