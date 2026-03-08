using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bootstrap
{
    public class BootstrapManager : MonoBehaviour
    {
        [SerializeField] private float _minSplashTime;
        [SerializeField] private Slider _slider;

        private float _time = 0;
        private bool _isInitialized = false;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            Debug.Log("[Bootstrap] Инициализация запущена...");
        }

        void Update()
        {
            _time += Time.deltaTime;
            _slider.value = _time / _minSplashTime;

            if (!_isInitialized)
            {
                InitializeCriticalSystems();
                _isInitialized = true;
            }

            if (IsReadyToLoadNextScene())
                LoadNextScene();
        }

        private void InitializeCriticalSystems()
        {
            // Пример: инициализация менеджеров

            Debug.Log("[Bootstrap] Все системы инициализированы!");
        }

        private bool IsReadyToLoadNextScene() =>
            _isInitialized && _time >= _minSplashTime;

        private void LoadNextScene()
        {
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        }
    }
}