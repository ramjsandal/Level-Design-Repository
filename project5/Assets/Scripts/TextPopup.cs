using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopup : MonoBehaviour
{
    
    public float _timer;
    public Text _respawnTimer;
    public bool _countingDown;
    // Start is called before the first frame update
    void Start()
    {
        _respawnTimer = (Text) FindObjectOfType(typeof(Text));
        _respawnTimer.enabled = false;
        _respawnTimer.text = "You died!";
        _countingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countingDown)
        {
            _timer -= Time.deltaTime;
            _respawnTimer.text = "You died!\n " + (int)_timer;
        }
    }
}
