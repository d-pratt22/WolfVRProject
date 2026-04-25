using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            TowerHealth tower = collision.gameObject.GetComponent<TowerHealth>();

            if (tower != null)
            {
                tower.TakeDamage(damage);
            }
        }

    }
}
