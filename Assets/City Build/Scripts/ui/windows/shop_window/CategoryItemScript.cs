using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryItemScript : MonoBehaviour {
	/* prefabs */
	public Sprite ArmySprite;
	public Sprite DefenceSprite;
	public Sprite OtherSprite;
	public Sprite ResourcesSprite;
	public Sprite TreasureSprite;
	public Sprite DecorationsSprite;

	/* references */
	public Button buton;
	public GameObject locked;
	public Text Name;
	public Image Image;
    /* private variables */
    private ShopWindowScript.Category _category;

	public void SetCategory(ShopWindowScript.Category category){
		this._category = category;

		switch (this._category) {
		case ShopWindowScript.Category.ARMY:
            this.buton.enabled = false;
            var tempColor = this.Image.color;
			tempColor.a = 0.3f;
            this.Image.color = tempColor;
            this.locked.SetActive(true);
            this.Name.text = "ARMY";
			this.Image.sprite = this.ArmySprite;
			break;
		case ShopWindowScript.Category.DEFENCE:
				this.buton.enabled = false;
                var tempColor2 = this.Image.color;
                tempColor2.a = 0.3f;
                this.Image.color = tempColor2;
                this.locked.SetActive(true); 
				this.Name.text = "DEFENCE";
			this.Image.sprite = this.DefenceSprite;
			break;
		case ShopWindowScript.Category.OTHER:
                this.buton.enabled = true;
                this.locked.SetActive(false);
                this.Name.text = "OTHER";
			this.Image.sprite = this.OtherSprite;
			break;
		case ShopWindowScript.Category.RESOURCES:
                this.buton.enabled = true;
                this.locked.SetActive(false);
                this.Name.text = "RESOURCES";
			this.Image.sprite = this.ResourcesSprite;
			break;
		case ShopWindowScript.Category.NFT:
                var tempColor3 = this.Image.color;
                tempColor3.a = 0.3f;
				this.Image.color = tempColor3;
                this.buton.enabled = false;
                this.locked.SetActive(true);
                this.Name.text = "NFT MARKET";
			this.Image.sprite = this.TreasureSprite;
			break;
		case ShopWindowScript.Category.DECORATIONS:
                this.buton.enabled = true;
                this.locked.SetActive(false);
                this.Name.text = "DECORATIONS";
			this.Image.sprite = this.DecorationsSprite;
			break;
		}
	}

	public void OnClick(){
		this.GetComponentInParent<ShopWindowScript> ().OnClickCategory (this._category);
	}

}
