using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    [SerializeField] private GameObject bgCam;
    [SerializeField] private bool _enforceRatio;
    [SerializeField] private float targetRatioX = 4;
    [SerializeField] private float targetRatioY = 3;
    Rect rect;
    [SerializeField] private float shakeDuration = 1;
    [SerializeField] private float shakeMagnitude = 1;

    void Start()
    {
        cam = GetComponent<Camera>();
        rect = cam.rect;
        // !! REPLACE INVOKE !!
        Invoke("SetUIRenderCamera", 0.01f);
    }
    void Update()
    {
        rect = cam.rect;
        bgCam.GetComponent<Camera>().depth = cam.depth - 1;

        gameObject.transform.position = 
            FindObjectOfType<PlayerMovement>().transform.position;

        if(_enforceRatio)
            scaleRatio();
    }

    //adds black borders on the game window to enforce the defined ratio
    void scaleRatio()
    {
        float targetRatio = targetRatioX / targetRatioY;
        float currentRatio = (float)Screen.width / (float)Screen.height;
        float ratioScale = currentRatio / targetRatio;
        if (ratioScale < 1f)
        {
            rect = cam.rect;
            rect.width = 1f;
            rect.height = ratioScale;
            rect.y = (1f - ratioScale) / 2f;
            rect.x = 0;
            cam.rect = rect;
        }
        else
        {
            cam = GetComponent<Camera>();
            rect = cam.rect;
            float rsInv = 1f / ratioScale;
            rect.width = rsInv;
            rect.height = 1f;
            rect.x = (1f - rsInv) / 2f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
    void SetUIRenderCamera()
    {
        Canvas[] uiCanvasInScene = (Canvas[])FindObjectsOfType(typeof(Canvas));
        foreach (Canvas c in uiCanvasInScene)
        {
            print("canvas found");
            if (c.renderMode != RenderMode.ScreenSpaceCamera)
            {
                print("canvas" + c.gameObject.name + "passes");
                c.worldCamera = gameObject.GetComponent<Camera>();
            }
        }
    }
    public void shakeCam(float dur, float mag)
    {
        StartCoroutine(Shake(dur, mag));

    }
    public void shakeCam()
    {
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
    }

    //shaking camera effect
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        while (magnitude > 0f)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(orignalPosition.x + x, orignalPosition.y + y, -10f);
            magnitude -= Time.deltaTime * duration;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
