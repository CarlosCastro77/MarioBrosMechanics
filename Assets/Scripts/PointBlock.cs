using UnityEngine;

public class PointBlock : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isActive = true;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(spriteRenderer.color);
        if (isActive)
        {
            scoreManager.score += 1;
            spriteRenderer.color = new Color(0.5f, 0.32f, 0.0f);
            isActive = false;
        }
    }
}
