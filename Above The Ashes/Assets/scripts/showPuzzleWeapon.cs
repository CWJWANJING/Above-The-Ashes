using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPuzzleWeapon : MonoBehaviour
{
  public Image puzzleImage;

  void Start()
  {
    puzzleImage.gameObject.SetActive(false);
  }

  void OnMouseDown()
  {
    puzzleImage.gameObject.SetActive(true);
  }


}
