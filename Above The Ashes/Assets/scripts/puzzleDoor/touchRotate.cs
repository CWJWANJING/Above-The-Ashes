using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchRotate : MonoBehaviour
{

  void Start()
  {
      gameObject.GetComponent<Button>().onClick.AddListener(rotate);
  }
  void rotate()
  {
      if (!puzzleControl.win){
        transform.Rotate(0f, 0f, 90f);
      }
  }
}
