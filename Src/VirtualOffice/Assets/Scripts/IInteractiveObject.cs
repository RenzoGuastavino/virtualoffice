using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractiveObject
{
   void OnHover();
   void OnBlur();
   void OnSelect();
}
