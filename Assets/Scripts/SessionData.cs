using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance ;
    public string playerName;
    public string bestScorePlayerName;
    public int bestScore;
    
    private void Awake() {
        if(Instance) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Highest score will be saved.
    [System.Serializable]
    class BestScoreData {
        public string playerName;
        public int score;
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if(System.IO.File.Exists(path)) {
            string json = System.IO.File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

            bestScorePlayerName = data.playerName;
            bestScore = data.score;
        }
        else {
            bestScorePlayerName = "Alice";
            bestScore = 10;
        }
    }

    public void SaveScore() {
        BestScoreData data = new BestScoreData();
        data.playerName = bestScorePlayerName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
