using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJump : MonoBehaviour
{
    public GameObject GameoverPanel;
    public GameObject NavbarPanel;   
    Rigidbody2D rigidBody;
    public AudioSource GameOverSFX;
    public float JumpForce = 7f;
    public SpriteRenderer spriteRenderer;
    public string currentColor;
    public Color Blue;
    public Color Yellow;
    public Color Purple;
    public Color Pink;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.simulated = true;
        SetRandomColor();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.up * JumpForce;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {
            Time.timeScale = 0;
            GameoverPanel.SetActive(true);
            NavbarPanel.SetActive(false);
            GameOverSFX.Play();      

        }
        if (col.gameObject.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.gameObject.tag == currentColor)
        {
            ScoreSystem.ScoreSystem.ScoreValue += 10;

        }

    }
 

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                spriteRenderer.color = Blue;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = Yellow;
                break;
            case 2:
                currentColor = "Purple";
                spriteRenderer.color = Purple;
                break;
            case 3:
                currentColor = "Pink";
                spriteRenderer.color = Pink;
                break;
        }
    }
    

}
