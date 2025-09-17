using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;

public class JoyStickMove : MonoBehaviour
{
    public static JoyStickMove Instance { get; private set; }
    public Joystick joystick;
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject shipPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Lấy joystick từ GameManager
        joystick = GameManager.Instance.joystick;
        if (joystick == null)
        {
            Debug.LogError("Joystick is not assigned in GameManager!");
        }
    }

    void FixedUpdate()
    {
        if (joystick == null) return;

        // Lấy input từ joystick
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);

        // Di chuyển player
        rb.linearVelocity = direction * speed;
    }
}