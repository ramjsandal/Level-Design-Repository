using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyPlayerOnCollision : MonoBehaviour
{
  private TextPopup t;
  private bool _destroying;

  private void Start()
  {
    _destroying = false;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if (!_destroying)
      {
        other.gameObject.GetComponent<PlayerController>().canMove = false;
        t = other.gameObject.GetComponent<TextPopup>();
        t._timer = 10;
        t._countingDown = true;
        t._respawnTimer.enabled = true;
        _destroying = true;
        Invoke(nameof(reloadScene), 10);
      }
    }
  }

  private void reloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
