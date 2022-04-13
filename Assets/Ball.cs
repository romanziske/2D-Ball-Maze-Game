using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    Rigidbody2D rb;

    public float moveSpeedModifier = 0.02f;

    float dirX, dirY;

    static bool isDead;

    static bool won;
    static bool moveAllowed;

    AssetBundle myLoadedAssetBundle;
    string[] scenePaths;


    int level = 1;

    // Start is called before the first frame update
    void Start() {

        isDead = false;
        won = false;
        moveAllowed= true;

        rb = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update() {
        dirX = Input.acceleration.x * moveSpeedModifier;
        dirY = Input.acceleration.y * moveSpeedModifier;

        if(isDead){
            moveAllowed = false;
            rb.velocity = new Vector2(0, 0);

            restartScene();
        }

        if(won){
            moveAllowed = false;
            rb.velocity = new Vector2(0, 0);

            if (level == 1)
                level = 2;
            else
                level = 1;

            nextScene();
        }
    }

    void FixedUpdate(){
        if(moveAllowed)
            rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y + dirY);
    }

    public static void setDead(bool status){
        isDead = status;
    }

    public static void setWon(bool status){
        won = status;
    }

    void nextScene(){
        SceneManager.LoadScene("Level"+level, LoadSceneMode.Single);
    }

    void restartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
