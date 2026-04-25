using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text winText;

    public void Start()
    {
        StartCoroutine(Countdown(300f)); 
    }

    IEnumerator Countdown(float duration)
    {
        float timeRemaining = duration;

        while (timeRemaining > 0f)
        {
            timerText.text = timeRemaining.ToString("F2"); 
            timeRemaining -= Time.deltaTime;
            yield return null; 
        }

        timerText.text = "0.00";
        winText.gameObject.SetActive(true);
        StartCoroutine(PauseBefore());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PauseBefore()
    {
        yield return new WaitForSeconds(3);
    }
}
