using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;


    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            if(_lives < 1)
            {                
                SceneManager.LoadScene(3);
            }
            if (SceneManager.GetActiveScene().name == "2Level2")
            {
                _lives = PlayerPrefs.GetInt("Lives");
            }
            livesLabel.text = "Lives: " + _lives.ToString();
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            if (_score > 499)
            {
                SceneManager.LoadScene(2);                
            }
            if (SceneManager.GetActiveScene().name == "2Level2")
            {
                _score = PlayerPrefs.GetInt("Score");
            }
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        SceneConfiguration();
       
    }

    private void SceneConfiguration()
    {
        Lives = 5;
        Score = 0;

        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }

        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();
        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }
        Instantiate(island);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("Lives", Lives);       
    } 
}
