using UnityEngine;

// Put this on the Player object.
// The Player needs: Sprite Renderer, Rigidbody 2D, Box Collider 2D.
public class PlayerMovement2D : MonoBehaviour
{
    [Header("How fast the player moves")]
    public float moveSpeed = 5f;

    [Header("Flip the sprite when moving left")]
    public bool flipSprite = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Read the keyboard. WASD and the arrow keys both work.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Stops diagonal movement being faster than straight movement.
        movement = movement.normalized;

        // Face the way we're moving.
        if (flipSprite && sprite != null)
        {
            if (movement.x < 0) sprite.flipX = true;
            if (movement.x > 0) sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // MovePosition moves the player and still respects walls.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
