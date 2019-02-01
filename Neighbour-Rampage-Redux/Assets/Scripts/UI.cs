using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI : MonoBehaviour
{
    private List<GameObject> itemsNeeded;
    private List<GameObject> lastNeeded;
    [SerializeField]
    private SpriteRenderer spriteSpace;

    bool alreadySet = false;
    
    void Start()
    {
        if (tag == "Player 1_HUD") itemsNeeded = GameObject.FindGameObjectWithTag("House1").GetComponent<HouseState>().itemsToLvl;
        if (tag == "Player 2_HUD") itemsNeeded = GameObject.FindGameObjectWithTag("House2").GetComponent<HouseState>().itemsToLvl;
        lastNeeded = itemsNeeded;
    }

    void Update()
    {
        UpdateNeededItems();
        setSprites();
        if (itemsNeeded != lastNeeded)
        {
            Debug.Log("LIST CHANGED");
            lastNeeded = itemsNeeded;
            //setSprites();
        }
    }
    void setSprites()
    {
        spriteSpace.sprite = itemsNeeded.FirstOrDefault().GetComponent<SpriteRenderer>().sprite;
    }

    void UpdateNeededItems()
    {
        if (tag == "Player 1_HUD" && GameObject.FindGameObjectWithTag("House1").GetComponent<HouseState>().itemsToLvl != itemsNeeded)
        {
            itemsNeeded = GameObject.FindGameObjectWithTag("House1").GetComponent<HouseState>().itemsToLvl;
        }

        if (tag == "Player 2_HUD" && GameObject.FindGameObjectWithTag("House2").GetComponent<HouseState>().itemsToLvl != itemsNeeded)
        {
            itemsNeeded = GameObject.FindGameObjectWithTag("House2").GetComponent<HouseState>().itemsToLvl;
        }
    }
}
