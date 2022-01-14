using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public void TageDamage(float ammount)
    {
        health -= ammount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
