using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TowerHealth : MonoBehaviour
{
    public int towerHealth;
    public TMP_Text towerHealthText;
    public TMP_Text gameOverText;

    public void Update()
    {
        towerHealthText.text = "Tower Health: " + towerHealth;

        if (towerHealth <= 0){
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(PauseBefore());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(int damage)
    {
        towerHealth -= damage;
    }

    IEnumerator PauseBefore()
    {
        yield return new WaitForSeconds(3);
    }
}
