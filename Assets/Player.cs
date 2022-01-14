using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string MainMenuSceneName;
    public string VictorySceneName;
    public string GameOverSceneName;
    public float maxHealth = 100;
    public float currentHealth;
    public float damagePerTimeInterval = 5;
    public float damageTimeIntervalSeconds = 1;
    private DateTime timeOfLastDamageTick;
    private Collider collider;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        DateTime timeOfLastDamageTick = System.DateTime.Now;
        collider = GetComponent<Collider>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!string.IsNullOrEmpty(MainMenuSceneName))
                SceneManager.LoadScene(MainMenuSceneName);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !string.IsNullOrEmpty(GameOverSceneName))
            SceneManager.LoadScene(GameOverSceneName);

        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "monster")
        {
            
            Physics.IgnoreCollision(collision.collider, collider);
            DateTime currentTime = System.DateTime.Now;
            if (currentTime.Subtract(timeOfLastDamageTick).TotalSeconds > damageTimeIntervalSeconds)
            {
                timeOfLastDamageTick = currentTime;
                TakeDamage(damagePerTimeInterval);
            }
        }
        else if (collision.gameObject.tag == "victory")
        {
            Debug.Log(collision.gameObject.tag);
            if (!string.IsNullOrEmpty(VictorySceneName))
                SceneManager.LoadScene(VictorySceneName);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.name);
    //    if (other.gameObject.tag == "monster")
    //    {
    //        DateTime currentTime = System.DateTime.Now;
    //        if (currentTime.Subtract(timeOfLastDamageTick).TotalSeconds > damageTimeIntervalSeconds)
    //        {
    //            timeOfLastDamageTick = currentTime;
    //            TakeDamage(damagePerTimeInterval);
    //        }
    //    }
    //}
}
