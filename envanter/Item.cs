using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
       //Yeni
       [SerializeField] string id;
	public string ID { get { return id; } }
       
       //Eski
       public SCitem item;
}
