using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    public static bool died = false;
    public Stat armor;
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    bool alreadyAttacked;
    public float timeBetweenAttacks = 4f;

    public HealthBar healthBar;

    [SerializeField] private Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.01f;

 


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }


    public void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(HurtFlash());
        FindObjectOfType<AudioManager>().Play("Enemy");
        animator.SetTrigger("face");
        

        


        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }

        if(currentHealth <= 0)
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
        died = true;
        GameMaster.MusicLoad = false;
        animator.SetBool("isDead", true);
        GetComponent<Collider>().enabled = false;
        GetComponent<ThirdPersonMovement>().enabled = false;

        this.enabled = false;

        FindObjectOfType<GameManager>().EndGame();
    }
    void OnEquipmentChanged(Equipment newItem)
    {
        if (newItem != null)
            armor.AddModifier(newItem.armorModifier);
            currentHealth += armor.GetValue();
            currentHealth = Mathf.Clamp(currentHealth, 0, 100);
            healthBar.SetHealth(currentHealth);
    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        yield return new WaitForSeconds(hurtTimer);

        hurtImage.enabled = false;
    }

}

