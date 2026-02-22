using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapManager : MonoBehaviour
{
    [SerializeField] private float _minSplashTime = 2.0f;

    private float _startTime;
    private bool _isInitialized = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _startTime = Time.time;
        Debug.Log("[Bootstrap] Инициализация запущена...");
    }

    void Update()
    {
        if (!_isInitialized)
        {
            InitializeCriticalSystems();
            _isInitialized = true;
        }

        if (IsReadyToLoadNextScene())
        {
            LoadNextScene();
        }
    }

    private void InitializeCriticalSystems()
    {
        // Пример: инициализация менеджеров

        Debug.Log("[Bootstrap] Все системы инициализированы!");
    }

    private bool IsReadyToLoadNextScene()
    {
        return _isInitialized && (Time.time - _startTime >= _minSplashTime);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        Destroy(gameObject); 
    }
}
