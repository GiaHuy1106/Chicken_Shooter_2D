using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Joystick joystick;        // Tham chiếu đến joystick trong Canvas
    public GameObject playerPrefab;  // Prefab của player
    private GameObject player;       // Player trong scene

    void Awake()
    {
        // Đảm bảo GameManager chỉ có 1
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        joystick = JoyStickMove.Instance.joystick; // Lấy joystick từ JoyStickMove

        DontDestroyOnLoad(gameObject); // Giữ lại khi đổi scene
    }

    void Start()
    {
        // Spawn player tại (0,0)
        if (playerPrefab == null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player prefab chưa được gán trong GameManager!");
        }
    }
}
