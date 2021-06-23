using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRoundInstantiate : MonoBehaviour
{
    public List<Transform> spawnpoints = new List<Transform>();
    public int playerNumber;
    public List<Transform> Players;
    public int[] PlayerScores;

    public Transform playerPrefab;
    public Transform bomb;
    public Transform chestprefab;

    public int playerturn = 0;
    [SerializeField] private int turn = 0;
    [SerializeField] private int timer = 0;
    //public Transform camera;



    void Start()
    {
        PlayerScores = new int[] { 0, 0, 0, 0 };

        for (int i = 0; i < playerNumber; i++)
        {
            Players[i] = Instantiate(playerPrefab, spawnpoints[i].position, Quaternion.identity);
            Players[i].GetChild(0).GetComponent<PlayerMovement>().enabled = false;
        }


        for (int i = 0; i < 4; ++i)
        {
            endTurn();
        }
    }

    void Update()
    {
        //camera.GetComponent<camFllow>().moche(Players[playerturn]);
        if (Input.GetMouseButtonDown(1) && Players[playerturn].GetChild(0).GetComponent<Weapon>().bombs > 0)
        {
            Instantiate(bomb, Players[playerturn].GetChild(0).position, Quaternion.identity);
            Players[playerturn].GetChild(0).GetComponent<Weapon>().bombs--;
            timer = 13500;
        }
        else if (timer == 15000 || Input.GetKeyDown(KeyCode.V))
        {
            endTurn();
        }
        else
        {
            timer++;
        }
    }
    

    public void endTurn()
    {
        timer = 0;
        Players[playerturn].GetChild(0).GetComponent<PlayerMovement>().enabled = false;
        Players[playerturn].GetChild(0).GetComponent<Weapon>().enabled = false;
        Players[playerturn].GetChild(0).GetComponent<dashMove>().enabled = false;

        if (PlayerScores[playerturn] >= 4000)
        {
            endGame();
        }
        else
        {
            if (turn > 0 && turn < 4)
                Instantiate(chestprefab);

            turn += playerturn / 3;
            playerturn = (playerturn + 1) % Players.Count;

            Players[playerturn].GetChild(0).GetComponent<PlayerMovement>().enabled = true;
            Players[playerturn].GetChild(0).GetComponent<Weapon>().enabled = true;
            Players[playerturn].GetChild(0).GetComponent<dashMove>().enabled = true;
        }
    }

    void endGame()
    {
        Debug.Log("EndGame j'ai pas envie de design.");
    }
}
