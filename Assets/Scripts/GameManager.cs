using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool isDragging = false;

    public GameObject[] m_Placements;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {

            //if not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame() {
        Debug.Log("Init Game");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isPlaced(GameObject setDownGameObject)
    {
        for (int i = 0; i < m_Placements.Length; i++)
        {
            bool overSprite = setDownGameObject.gameObject.GetComponent<SpriteRenderer>().bounds.Contains(m_Placements[i].transform.position);
            if (overSprite)
            {
                //Debug.Log("On Top Of: " + m_Placements[i].name);
                setDownGameObject.SendMessage("OnPlaced", m_Placements[i], SendMessageOptions.RequireReceiver);
                return true;
            }
        }

        return false;

    }
}
