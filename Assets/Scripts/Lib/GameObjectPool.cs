using System;
using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool {

  #region Fields

  private List<GameObject> objects = new List<GameObject>();
  private GameObject prefab;
  GameObject poolGameObject;

  #endregion

  #region Contructors

  public GameObjectPool(GameObject prefab, int initialObjectAmount, Transform parent) {
    this.prefab = prefab;
    poolGameObject = new GameObject(prefab.name + "Pool");
    poolGameObject.transform.parent = parent;
    for(int i = 0; i < initialObjectAmount; i++)
      PushObject(); 
  }

  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach(GameObject obj in objects) {
      if(!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }
 
  public GameObject PushObject() {
    GameObject obj = Pooler.CreatePoolGameObject(prefab, poolGameObject.transform);
    obj.SetActive(false);
    objects.Add(obj);

    return obj;
  }

  #endregion

}