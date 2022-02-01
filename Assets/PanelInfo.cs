using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
   private Text _textName;
   private InputField[] _sizeTripleInput;
   private InputField[] _colorTripleInput;
   private GameObject _currentGameObject;
   private void Awake()
   {
      _textName = gameObject.GetComponentsInChildren<Text>().ToList().Find(x => x.name == "NameText");
      var tripleSize = GameObject.Find("SizeTripleInput");
      _sizeTripleInput = tripleSize.GetComponentsInChildren<InputField>();
      
      var tripleColor = GameObject.Find("ColorTripleInput");
      _colorTripleInput = tripleColor.GetComponentsInChildren<InputField>();

      foreach (var input in _sizeTripleInput)
      {
         input.onEndEdit.AddListener(delegate{LockInput(input);});
      }
      
      foreach (var input in _colorTripleInput)
      {
         input.onEndEdit.AddListener(delegate{LockInput(input);});
      }
      
      gameObject.SetActive(false);
   }
   
   public void SetInfo(GameObject obj, Vector3 size, Color color)
   {
      _currentGameObject = obj;
      _textName.text = obj.name;
      
      _sizeTripleInput[0].text = size.x.ToString();
      _sizeTripleInput[1].text = size.y.ToString();
      _sizeTripleInput[2].text = size.z.ToString();
      
      _colorTripleInput[0].text = (color.r * 255).ToString();
      _colorTripleInput[1].text = (color.g * 255).ToString();
      _colorTripleInput[2].text = (color.b * 255).ToString();
   }

   public void ShowPanel()
   {
      gameObject.SetActive(true);
   }

   public void ClosePanel()
   {
      gameObject.SetActive(false);
   }

   private void LockInput(InputField input)
   {
      if (input.text.Length > 0) 
      {
         if (input.name.Contains("XInput") || input.name.Contains("YInput") || input.name.Contains("ZInput"))
         {
            _currentGameObject.transform.localScale = new Vector3(float.Parse(_sizeTripleInput[0].text),
               float.Parse(_sizeTripleInput[1].text), float.Parse(_sizeTripleInput[2].text));
         }
         else
         {
            var renderer = _currentGameObject.GetComponent<Renderer>();
            renderer.material.color = new Color(float.Parse(_colorTripleInput[0].text) / 255,
               float.Parse(_colorTripleInput[1].text) / 255, float.Parse(_colorTripleInput[2].text) / 255);
         }
      }
   }
}
