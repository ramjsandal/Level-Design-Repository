using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public AudioClip deadSFX;
    [SerializeField] private string scene;
    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            PlayerDies();
        }
        
        Debug.Log(currentHealth);
    }

    void PlayerDies()
    {
        Debug.Log("Player is dead");
        AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        transform.Rotate(-90, 0, 0, Space.Self);
        Invoke("_reloadLevel", 3);
        
    }

    private void _reloadLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
