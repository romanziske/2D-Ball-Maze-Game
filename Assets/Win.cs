using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Set WOn");
        Ball.setWon(true);
    }
}
    
