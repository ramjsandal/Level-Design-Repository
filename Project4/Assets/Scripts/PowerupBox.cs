using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerupBox : MonoBehaviour
{
    private string[] _powers = {"Heal", "HighJump", "Slow"};

    private GameObject _player;

    private PlayerHealth _playerHealth;

    private PlayerController _playerController;

    public string _power;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _playerHealth = _player.GetComponent<PlayerHealth>();

        _power = _powers[UnityEngine.Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _activatePower();
        }
    }

    void _activatePower()
    {
        switch (_power)
        {
            case "Heal":
                _playerHealth.currentHealth += 20;
                break;
            case "HighJump":
                _playerController.jumpHeight *= 2;
                Invoke("_deactivatePower", 10);
                break;
            case "Slow":
                _playerController.moveSpeed /= 2;
                Invoke("_deactivatePower", 10);
                break;
        }

        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
    }

    void _deactivatePower()
    {
        switch (_power)
        {
            case "HighJump":
                _playerController.jumpHeight /= 2;
                break;
            case "Slow":
                _playerController.moveSpeed *= 2;
                break;
        }
        Destroy(this.gameObject);
    }
}
