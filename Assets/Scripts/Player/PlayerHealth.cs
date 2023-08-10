using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public bool IsDead { get; private set; }
    
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private Slider healthSlider;
    
    private int currentHealth;
    private bool canTakeDamage = true;
    
    private Knockback knockback;
    private Flash flash;

    private const string HEALTH_SLIDER_TEXT = "Health Slider";
    private const string REVIVE_SCENE = "Scene_1";
    private readonly int DEATH_HASH = Animator.StringToHash("Death");

    protected override void Awake()
    {
        base.Awake();
        
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        IsDead = false;
        currentHealth = maxHealth;
        
        UpdateHealthSlider();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy)
        {
            TakeDamage(1, other.transform);
        }
    }

    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();   
        }
    }

    public void TakeDamage(int damageAmount, Transform hiTransform)
    {
        if (!canTakeDamage)
        {
            return; 
        }
        
        ScreenShakeManager.Instance.ShakeScreen();
        
        knockback.GetKnockedBack(hiTransform.gameObject.transform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }

    private void CheckIfPlayerDeath()
    {
        if (currentHealth <= 0 && !IsDead) // Don't redo if already dead
        {
            IsDead = true;
            
            // Destroy weapon to disable attacking when dead
            Destroy(ActiveWeapon.Instance.gameObject);
            
            // Force currentHealth to not be below 0
            currentHealth = 0;
            
            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    private IEnumerator DeathLoadSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Stamina.Instance.ReplenishStaminaOnDeath();
        SceneManager.LoadScene(REVIVE_SCENE);
    }    
    
    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_SLIDER_TEXT).GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
