using UnityEngine;
using UnityEditor;

public enum OrientationType
{
    Portrait,
    Landscape,
    Fullscreen
}

[ExecuteAlways, DisallowMultipleComponent, HelpURL("https://t.me/chikadev")]
public class ScreenOrientation : MonoBehaviour
{
    [Header("Orientation")]
    [SerializeField, Tooltip("Выберите необходимую ориентацию для ПК")] private OrientationType orientationTypePC;
    [SerializeField, Tooltip("Выберите необходимую ориентацию для Телефонов")] private OrientationType orientationTypeMobile;

    private OrientationType currentOrientationType;

    [Header("Border Color")]
    [SerializeField, Tooltip("Настройте цвет полос по бокам")] private Color backgroundColor = new Color(34f / 255f, 40f / 255f, 73f / 255f);
    private Color previousBackgroundColor;

    [Header("Platform")]
    [SerializeField, Tooltip("Симуляция телефона")] private bool PlatformIsMobile;
    [SerializeField, Tooltip("Автоматическое определение устройства")] private bool PlatformAutoDetection;

    private bool showDebugLog = false;

    private float targetAspectRatioWidth;
    private float targetAspectRatioHeight;

    private int previousScreenWidth;
    private int previousScreenHeight;

    private Camera mainCamera;
    private Camera backgroundCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        PlatformDetection();

        UpdateAspectRatio();
        CreateBackgroundCamera();
    }

    private void CreateBackgroundCamera() 
    {
        if(backgroundCamera != null) {
            return;
        }

        backgroundCamera = mainCamera.transform.Find("BackgroundCamera")?.GetComponent<Camera>();

        if(showDebugLog)
        {
            Debug.Log("Поиск дополнительной камеры");
        }

        if(backgroundCamera == null)
        {
            GameObject createdBackgroundCamera = new GameObject("BackgroundCamera");
            backgroundCamera = createdBackgroundCamera.AddComponent<Camera>();
            createdBackgroundCamera.transform.SetParent(mainCamera.transform);

            backgroundCamera.clearFlags = CameraClearFlags.SolidColor;
            backgroundCamera.renderingPath = RenderingPath.Forward;
            backgroundCamera.cullingMask = 0;
            backgroundCamera.depth = -2;
            backgroundCamera.allowHDR = false;
            backgroundCamera.allowMSAA = false;

            if(showDebugLog)
            {
                Debug.Log("Создание дополнительной камеры");
            }
        }
    }

    private void UpdateBackgroundCamera() 
    {
        if(backgroundCamera != null && backgroundColor != previousBackgroundColor)
        {
            backgroundCamera.backgroundColor = backgroundColor;
            previousBackgroundColor = backgroundColor;

            if(showDebugLog)
            {
                Debug.Log("Изменение цвета");
            }
        }
    }

    private void Update()
    {
        if(ScreenChanged()) {
            UpdateAspectRatio();
            UpdateBackgroundCamera();
            if(showDebugLog)
            {
                Debug.Log("Деформация окна");
            }
        }
    }

    private bool ScreenChanged()
    {
        return Screen.width != previousScreenWidth || Screen.height != previousScreenHeight;
    }

    private void UpdateAspectRatio()
    {
        if(mainCamera == null)
            return;

        Platform();

        previousScreenWidth = Screen.width;
        previousScreenHeight = Screen.height;

        float currentAspectRatio = (float)Screen.width / Screen.height;
        float targetWidth;
        float targetHeight;

        if (currentAspectRatio > (targetAspectRatioWidth / targetAspectRatioHeight))
        {
            targetWidth = (targetAspectRatioWidth / targetAspectRatioHeight) * Screen.height;
            targetHeight = Screen.height;
        }
        else
        {
            targetWidth = Screen.width;
            targetHeight = Screen.width / (targetAspectRatioWidth / targetAspectRatioHeight);
        }

        float widthDiff = Screen.width - targetWidth;
        float heightDiff = Screen.height - targetHeight;
        float leftOffset = widthDiff / 2f;
        float bottomOffset = heightDiff / 2f;

        mainCamera.rect = new Rect(leftOffset / Screen.width, bottomOffset / Screen.height, targetWidth / Screen.width, targetHeight / Screen.height);
    }

    private void Platform()
    {
        if(!PlatformIsMobile)
        {
            currentOrientationType = orientationTypePC;
        }
        else
        {
            currentOrientationType = orientationTypeMobile;
        }

        if(currentOrientationType == OrientationType.Portrait)
        {
            targetAspectRatioWidth = 9f;
            targetAspectRatioHeight = 16f;
        }
        else if(currentOrientationType == OrientationType.Landscape)
        {
            targetAspectRatioWidth = 16f;
            targetAspectRatioHeight = 9f;
        }
        else if(currentOrientationType == OrientationType.Fullscreen)
        {
            targetAspectRatioWidth = (float)Screen.width;
            targetAspectRatioHeight = (float)Screen.height;
        }
    }

    private void PlatformDetection()
    {
        if(PlatformAutoDetection)
        {
            PlatformIsMobile = Application.isMobilePlatform;
        }
        if(showDebugLog)
        {
            Debug.Log("Определение устройства");
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if(!Application.isPlaying)
        {
            UpdateAspectRatio();
            UpdateBackgroundCamera();
            PlatformDetection();
        }
    }

    [MenuItem("Chika/Telegram")]
    static void OpenTelegram()
    {
        Application.OpenURL("https://t.me/chikadev");
    }
#endif
}