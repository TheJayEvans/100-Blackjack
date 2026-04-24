using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class CardSprite
{
    public Suit suit;
    public Rank rank;
    public Sprite sprite;
}

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public Deck deck;

    public List<CardSprite> cardSprites;

    public float spawnY = 6f;
    public float minX = -8f;
    public float maxX = 8f;

    public float spawnInterval = 7f;

    void Start()
    {
        //InvokeRepeating(nameof(SpawnCard), 0f, spawnInterval);
        StartCoroutine(cardCoroutine());
    }

    IEnumerator cardCoroutine()
    {
        while (true)
        {
            SpawnCard();
            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    void SpawnCard()
    {
        PlayingCard card = deck.DrawCard();

        Vector2 pos = new Vector2(Random.Range(minX, maxX), spawnY);
        var obj = Instantiate(cardPrefab, pos, Quaternion.identity);
        Destroy(obj,5f);

        CardObject cardObj = obj.GetComponent<CardObject>();

        Sprite sprite = GetSprite(card);
        cardObj.Setup(card, sprite);
    }

    Sprite GetSprite(PlayingCard card)
    {
        foreach (var cs in cardSprites)
        {
            if (cs.suit == card.suit && cs.rank == card.rank)
                return cs.sprite;
        }

        return null;
    }
}
