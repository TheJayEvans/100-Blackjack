using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBlackjack : MonoBehaviour
{
    public int target = 100;
    public TMP_Text scoretext;
    public EnemySpawner spawnerRef;

    private List<PlayingCard> hand = new List<PlayingCard>();

    public void AddCard(PlayingCard card)
    {
        hand.Add(card);

        int total = CalculateTotal();
        //Debug.Log("Total: " + total);
        scoretext.text = ("Score: " + total).ToString();
        
        
        spawnerRef.spawnRate -= 0.25f;
        

        if (total == target)
            Win();
        else if (total > target)
            Bust();
    }

    int CalculateTotal()
    {
        int total = 0;
        int aceCount = 0;

        foreach (var card in hand)
        {
            total += card.GetValue();
            if (card.rank == Rank.Ace)
                aceCount++;
        }

        /*
        while (total > target && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }
        */

        return total;
    }

    void Win()
    {
        //Debug.Log("You hit 100!");
        SceneManager.LoadScene("Win Screen", LoadSceneMode.Single);
    }

    void Bust()
    {
        //Debug.Log("Bust!");
        SceneManager.LoadScene("Loss Screen", LoadSceneMode.Single);
    }
}