using Unity.VisualScripting;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;

    private PlayingCard cardData;

    public void Setup(PlayingCard card, Sprite sprite)
    {
        cardData = card;
        spriteRenderer.sprite = sprite;
    }

    public int GetValue()
    {
        return cardData.GetValue();
    }

    public Rank GetRank()
    {
        return cardData.rank;
    }

   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerBlackjack player = collision.gameObject.GetComponent<PlayerBlackjack>();
            if (player != null)
            {
                player.AddCard(cardData);
            }

            Destroy(gameObject);
        }
    }



}
