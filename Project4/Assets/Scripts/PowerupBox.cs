using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerupBox : MonoBehaviour
{
  private string[] _powers = {"Heal", "HighJump", "Slow"};

  private GameObject _player;

  private PlayerHealth _playerHealth;

  private PlayerController _playerController;

  public string _power;

  private bool b;

  [SerializeField] private Text text;
  // Start is called before the first frame update
  void Start()
  {
    _player = GameObject.FindGameObjectWithTag("Player");
    _playerController = _player.GetComponent<PlayerController>();
    _playerHealth = _player.GetComponent<PlayerHealth>();

    _power = _powers[UnityEngine.Random.Range(0, 3)];
    text.text = "No Powers";
  }

  // Update is called once per frame
  void Update()
  {
    if (b)
    {
      Vector3 dest = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
      transform.position = Vector3.MoveTowards(transform.position, dest, 3 * Time.deltaTime);
      transform.Rotate(0, 90 * Time.deltaTime, 0);
      Color orig = GetComponent<Renderer>().material.color;
      GetComponent<Renderer>().material.color = Color.Lerp(orig, Color.red, Time.deltaTime * 1);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      this.GetComponent<Collider>().enabled = false;
      Invoke("_activatePower", 2);
      b = true;
    }
  }

  void _activatePower()
  {
    switch (_power)
    {
      case "Heal":
        _playerHealth.currentHealth += 20;
        Invoke("_deactivatePower", 10);
        text.text = "Heal!";
        break;
      case "HighJump":
        _playerController.jumpHeight *= 2;
        Invoke("_deactivatePower", 10);
        text.text = "Jump!";
        break;
      case "Slow":
        _playerController.moveSpeed /= 2;
        Invoke("_deactivatePower", 10);
        text.text = "Slow!";
        break;
    }
    
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
    text.text = "No Powers";
    Destroy(this.gameObject);
  }
}