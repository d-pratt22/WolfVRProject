using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage = 50;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
