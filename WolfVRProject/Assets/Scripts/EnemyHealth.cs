using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    public void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
}
