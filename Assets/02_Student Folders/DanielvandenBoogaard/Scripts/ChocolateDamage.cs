using UnityEngine;

public class ChocolateDamage : MonoBehaviour
{
    [Tooltip("Health of Chocolate wall")]
    public int health = 100;
    public GameObject fullChocolate;
    public GameObject halfChocolate;
    public GameObject EmptyChocolate;
    [Tooltip("Hide the Chocolate completely when destroyed")]
    public bool hideAll;

    private float m_maxHealth = 0f;

    void Awake()
    {
        m_maxHealth = health;
    }

    public void InflictDamage(float damage)
    {
        if (health > 0)
        {
            health = (int)Mathf.Clamp(health - Mathf.Round(damage), 0f, m_maxHealth);
            if (health == 0) {
                fullChocolate.SetActive(false);
                EmptyChocolate.SetActive(!hideAll);
                if (halfChocolate != null) {
                    halfChocolate.SetActive(false);
                }
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else if (health < m_maxHealth / 2 && halfChocolate != null) {
                fullChocolate.SetActive(false);
                halfChocolate.SetActive(true);
            }
        }
    }
}
