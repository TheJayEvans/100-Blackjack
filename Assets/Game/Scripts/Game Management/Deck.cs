using System.Collections.Generic;
using UnityEngine;

public enum Suit { Hearts, Diamonds, Clubs, Spades }

public enum Rank
{
    Ace = 1, Two, Three, Four, Five, Six,
    Seven, Eight, Nine, Ten, Jack, Queen, King
}

[System.Serializable]
public class PlayingCard
{
    public Suit suit;
    public Rank rank;

    public int GetValue()
    {
        if (rank == Rank.Ace) return 1;
        if (rank == Rank.Jack) return 11;
        if (rank == Rank.Queen) return 12;
        if (rank == Rank.King) return 13;
        //if ((int)rank >= 11) return 10;
        return (int)rank;
    }
}

public class Deck : MonoBehaviour
{
    public List<PlayingCard> cards = new List<PlayingCard>();

    void Awake()
    {
        CreateDeck();
        Shuffle();
    }

    void CreateDeck()
    {
        cards.Clear();

        foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in System.Enum.GetValues(typeof(Rank)))
            {
                PlayingCard card = new PlayingCard
                {
                    suit = suit,
                    rank = rank
                };

                cards.Add(card);
            }
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int rand = Random.Range(0, cards.Count);
            (cards[i], cards[rand]) = (cards[rand], cards[i]);
        }
    }

    public PlayingCard DrawCard()
    {
        if (cards.Count == 0)
        {
            CreateDeck();
            Shuffle();
        }

        PlayingCard card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}