using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayerOnCollision : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      //Destroy(other.gameObject);
      other.gameObject.GetComponent<PlayerController>().canMove = false;
      Invoke(nameof(reloadScene), 10);
    }
  }

  private void reloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
