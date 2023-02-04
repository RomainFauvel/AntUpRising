using UnityEngine;

public class PlayerHeath : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public bool val = false;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealthMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            TakeDamage(2);        
        }
    }

    public void TakeDamage(int damage )
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    public bool IsDead()
    {
        
        if(currentHealth <= 0)
        {
            val = true ;
        }
        return val;
    }
}
