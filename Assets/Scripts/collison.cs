using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;

public class collison : MonoBehaviour
{
    public int score = 10;
    public bool isCollider;
    public bool islast = false;
   //public Text textScore;
    //public Score scoreObject;
    // Use this for initialization
    void Start()
    {
        //textScore.text = score.ToString();
        // score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
    async void OnTriggerEnter(Collider col)
    {
        isCollider = true;
        print("collison" + isCollider);
        GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        explosion.transform.position = transform.position;
        //ScoreMethod(col.gameObject);
        Destroy(col.gameObject);  
        Destroy(explosion, 2);
       // Destroy(gameObject);

        
        //add Score
        ScoreMethod(col.gameObject.name);
        //convert tags "player" from array to list and delete one player(the enemy)
        GameObject[] flyArray =  GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> flyList = new List<GameObject>();
        flyList.AddRange(flyArray);
        flyList.Remove(col.gameObject);
        print(flyList.Count);
        //if all the enemies die.
        if (flyList.Count <= 9)
        {
            islast = true;
            /*Image image = new Image()
            //wait one seconds until create new enemies
            await Task.Delay(1000);
            GameObject enemy = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
            // GameObject enemy1 = Instantiate(Resources.Load("enemy1", typeof(GameObject))) as GameObject;
            // GameObject enemy2 = Instantiate(Resources.Load("enemy2", typeof(GameObject))) as GameObject;
            // GameObject enemy3 = Instantiate(Resources.Load("enemy3", typeof(GameObject))) as GameObject;*/

        }

    }
    void ScoreMethod(string name)
    {
        int addScore = 10;
        if (name.Contains("ship"))
        {
            addScore = 10;
            score = 10;
        } else if (name.Contains("Air"))
        {
            addScore = 15;
            score = 15;
        }
        else if (name.Contains("FlyingSacuer"))
        {
            addScore = 25;
            score = 25;
        }
        else if (name.Contains("enemy"))
        {
            addScore = 20;
            score = 20;
        }
    }
  }

