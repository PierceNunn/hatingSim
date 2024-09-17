using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    public GameObject cam2;
    public float targetRatioX = 4;
    public float targetRatioY = 3;
    Rect rect;
    GameObject bgCam;
    public float shakeDuration = 1;
    public float shakeMagnitude = 1;

    void Start()
    {
        bgCam = cam2;
        scaleRatio();
        Invoke("SetUIRenderCamera", 0.01f);

    }
    void Update()
    {

        float margin = 0.2f;
        rect = cam.rect;
        // setup the rectangle
        //cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
        bgCam.GetComponent<Camera>().depth = cam.depth - 1;
        scaleRatio();
    }
    void scaleRatio()
    {
        float targetRatio = targetRatioX / targetRatioY;
        float currentRatio = (float)Screen.width / (float)Screen.height;
        float ratioScale = currentRatio / targetRatio;
        if (ratioScale < 1f)
        {
            cam = GetComponent<Camera>();
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
        if (true)//PlayerPrefs.GetInt("ShakeCamEnabled") == 1)
        {
            StartCoroutine(Shake(dur, mag));
        }

    }
    public void shakeCam()
    {
        if (PlayerPrefs.GetInt("ShakeCamEnabled") == 1)
        {
            StartCoroutine(Shake(shakeDuration, shakeMagnitude));
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

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
