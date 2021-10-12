using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card_GameManager : MonoBehaviour
{

    private const int winCardCouples = 6;
    private int curCardCouples = 0;
    private bool canPlayerClick = true;

    public Sprite BackSprite;
    public Sprite SuccessSprite;
    public Sprite[] FrontSprites;

    public GameObject CardPre;
    public Transform CardsView;
    private List<GameObject> CardObjs;
    private List<Card> FaceCards;

    // Use this for initialization
    void Start()
    {

        CardObjs = new List<GameObject>();
        FaceCards = new List<Card>();


        for (int i = 0; i < 6; i++)
        {
            Sprite FrontSprite = FrontSprites[i];
            for (int j = 0; j < 2; j++)
            {

                GameObject go = (GameObject)Instantiate(CardPre);

                Card card = go.GetComponent<Card>();
                card.InitCard(i, FrontSprite, BackSprite, SuccessSprite);
                card.cardBtn.onClick.AddListener(() => CardOnClick(card));

                CardObjs.Add(go);
            }
        }

        while (CardObjs.Count > 0)
        {
            //Ramdom number 
            int ran = Random.Range(0, CardObjs.Count);
            GameObject go = CardObjs[ran];
            
            go.transform.parent = CardsView;
            
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            
            CardObjs.RemoveAt(ran);
        }
    }


    private void CardOnClick(Card card)
    {
        if (canPlayerClick)
        {
            
            card.SetFanPai();
            
            FaceCards.Add(card);
            
            if (FaceCards.Count == 2)
            {
                canPlayerClick = false;
                StartCoroutine(JugdeTwoCards());
            }
        }
    }

    IEnumerator JugdeTwoCards()
    {
        
        Card card1 = FaceCards[0];
        Card card2 = FaceCards[1];
        //Compare Card ID
        if (card1.ID == card2.ID)
        {
            Debug.Log("Success......");

            yield return new WaitForSeconds(0.8f);
            card1.SetSuccess();
            card2.SetSuccess();
            curCardCouples++;
            if (curCardCouples == winCardCouples)
            {
                //winning text
                Debug.Log("Win!");
            }
        }
        else
        {
            Debug.Log("Failure......");
            //losing text, players need to wait longer
            yield return new WaitForSeconds(1.5f);
            card1.SetRecover();
            card2.SetRecover();
        }

        FaceCards = new List<Card>();
        canPlayerClick = true;
    }
}

