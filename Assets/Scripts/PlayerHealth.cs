
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float _maxHealth;
    public RectTransform _healthBar;

    public GameObject gamePlayUI;

    public GameObject gameOverScreen;
    // Update is called once per frame
    void Start()
    {
        _maxHealth = health;
    }
    void Update()
    {
        
    }

    public void DestroyEnemyUpdate(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            PlayerIsDead();
        }

        HealthBarController();
    }

    public void Healing()
    {
        health += 10;
        HealthBarController();
    }

    public void HealthBarController()
    {
        _healthBar.anchorMax = new Vector2(health / _maxHealth, 1);
    }

    public void AddHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, _maxHealth);
        HealthBarController();
    }

    public void PlayerIsDead()
    {
        gamePlayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<PlayerAnimation>().enabled = false;
    }
}
