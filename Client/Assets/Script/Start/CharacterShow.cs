using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShow : MonoBehaviour {

    public void OnMouseUpAsButton()
    {
        StartMenuController.Instance.OnCharacterClick(transform.parent.gameObject);
    }
}
