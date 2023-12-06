using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Stat armor;

    public HealthBar healthBar;

    public Animator animator;

    bool alreadyAttacked;
    public float timeBetweenAttacks = 4f;

    private void Start()
    {
        currentHealth = maxHealth - armor.GetValue();
        healthBar.SetMaxHealth(maxHealth);
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }


    public void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("face");

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        GetComponent<Collider>().enabled = false;
        GetComponent<ThirdPersonMovement>().enabled = false;

        this.enabled = false;
    }
    void OnEquipmentChanged(Equipment newItem)
    {
        if (newItem != null)
            armor.AddModifier(newItem.armorModifier);
    }
}
