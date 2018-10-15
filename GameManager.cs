using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private TMP_Text _finalText;
    [SerializeField] private Transform _lowerLeftBound;
    [SerializeField] private Transform _upperRightBound;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
    }

    public void AddScore(int amount)
    {
        _score += amount;
    }

    public void OnClickRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Die()
    {
        Time.timeScale = 0;
        _gameoverPanel.SetActive(true);
        _finalText.text = _score.ToString();
    }

    public Vector3 GetLowerLeftBound()
    {
        return _lowerLeftBound.position;
    }

    public Vector3 GetUpperRightBound()
    {
        return _upperRightBound.position;
    }
}