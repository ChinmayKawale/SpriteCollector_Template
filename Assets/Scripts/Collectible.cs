using UnityEngine;

// Put this on anything the player can pick up.
// It needs: Sprite Renderer, Box Collider 2D with "Is Trigger" TICKED.
public class Collectible : MonoBehaviour
{
    [Header("How many points this is worth")]
    public int pointsValue = 1;

    [Header("Make it spin (optional)")]
    public bool spin = false;
    public float spinSpeed = 90f;

    void Start()
    {
        // Tell the scorekeeper we exist, so it knows how many there are to collect.
        if (ScoreKeeper.instance != null)
        {
            ScoreKeeper.instance.Register();
        }
    }

    void Update()
    {
        if (spin)
        {
            transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to the player, not to walls or other collectibles.
        if (other.CompareTag("Player"))
        {
            if (ScoreKeeper.instance != null)
            {
                ScoreKeeper.instance.AddPoints(pointsValue);
            }

            // Remove this collectible from the game.
            Destroy(gameObject);
        }
    }
}
