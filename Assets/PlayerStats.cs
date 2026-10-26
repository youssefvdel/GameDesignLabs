using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int lives = 3;

    private float flickerTime = 0.0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immuneTime = 0.0f;
    public float immuneDuration = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isImmune)
        {
            immuneTime += Time.deltaTime;
            SpriteFlicker();
            if (immuneTime >= immuneDuration)
            {
                isImmune = false;
                spriteRenderer.enabled = true;
            }
        }
    }


    void SpriteFlicker()
    {


        if (flickerTime < flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            flickerTime = 0.0f;
            spriteRenderer.enabled = !(spriteRenderer.enabled);
        }
    }


    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            health -= damage;
            if (health <= 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 100;
                lives--;
            }
            else if (lives <= 0 && health <= 0)
            {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + health.ToString());
            Debug.Log("Player Lives:" + lives.ToString());
        }
        isImmune = true;
        immuneTime = 0.0f;
    }


}
