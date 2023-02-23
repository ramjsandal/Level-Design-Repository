using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLerper : MonoBehaviour
{
  public float speed = 1.0f; // Speed of the lerping
  public Vector2 minTiling = new Vector2(1.0f, 1.0f); // Minimum tiling values
  public Vector2 maxTiling = new Vector2(2.0f, 2.0f); // Maximum tiling values

  private Renderer renderer; // Reference to the object's renderer
  private Vector2 currentTiling; // Current tiling values
  private Vector2 targetTiling; // Target tiling values for lerping

  void Start()
  {
    renderer = GetComponent<Renderer>();
    currentTiling = renderer.sharedMaterial.mainTextureScale;
    targetTiling = maxTiling;
  }

  void Update()
  {
    // Lerp the tiling values towards the target
    currentTiling = Vector2.Lerp(currentTiling, targetTiling, Time.deltaTime * speed);
    renderer.sharedMaterial.mainTextureScale = currentTiling;

    // If the current tiling is close enough to the target, switch to the other target
    if (Vector2.Distance(currentTiling, targetTiling) < 0.01f)
    {
      targetTiling = (targetTiling == maxTiling) ? minTiling : maxTiling;
    }
  }
}