using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionPreview : MonoBehaviour
{
    /*
     * This script displays the next potion in the queue.
     * Communication to the player so they know what's up next.
     */

    public Image potionPreview;
    
    public void UpdatePotion(GameObject nextPotion)
    {
        potionPreview.GetComponent<Image>().sprite = nextPotion.GetComponent<SpriteRenderer>().sprite;
        potionPreview.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = nextPotion.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        potionPreview.transform.GetChild(0).gameObject.GetComponent<Image>().color = nextPotion.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
    }
}
