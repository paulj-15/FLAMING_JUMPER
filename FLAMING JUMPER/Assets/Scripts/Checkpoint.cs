using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite redf;// drag red sprite in this var
    public Sprite greenf;// drag green sprite
    private SpriteRenderer CheckpointSpriteRenderer;
    public bool CheckpoiReac;

    // Start is called before the first frame update
    void Start()
    {
        CheckpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
            CheckpointSpriteRenderer.sprite = greenf;
        CheckpoiReac = true;
    }

}
