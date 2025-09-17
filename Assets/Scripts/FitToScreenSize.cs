using UnityEngine;

public class FitToScreenSize : MonoBehaviour
{
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(Vector3.zero)*100;
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.rect.width, mainCamera.rect.height))*100;
        Vector3 screenSize = topRight - bottomLeft;
        float screenRatio = screenSize.x / screenSize.y;
        float desireRatio = transform.localScale.x / transform.localScale.y;

        if (screenRatio >= desireRatio)
        {
            float height = screenSize.y;
            transform.localScale = new Vector3(height * desireRatio, height);
        }
        else
        {
            float width = screenSize.x;
            transform.localScale = new Vector3(width, width / desireRatio);
        }
    }
}
