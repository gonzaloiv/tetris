using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooler : Singleton<Pooler> {

  #region Fields

  private Dictionary<string, GameObjectPool> pools = new Dictionary<string, GameObjectPool>();

  #endregion

  #region Public Pool Behaviour

  public static GameObjectPool CreateGameObjectPool(GameObject prefab, int initialObjectAmount, Transform parent) {
    return CreateGameObjectPool(prefab.name + "Pool", prefab, initialObjectAmount, parent);
  }

  public static GameObjectPool CreateGameObjectPool(string poolName, GameObject prefab, int initialObjectAmount, Transform parent) {
    GameObjectPool gameObjectPool = GetPoolByName(poolName);
    if(gameObjectPool != null)
      return gameObjectPool;

    gameObjectPool = new GameObjectPool(prefab, initialObjectAmount, parent);
    Instance.pools.Add(poolName, gameObjectPool);
   
    return gameObjectPool;
  }

  public static GameObjectPool GetPoolByName(string poolName) {
    if (!Instance.pools.ContainsKey(poolName))
      return null;
    return Instance.pools[poolName];
  }

  #endregion

  #region Public Object Behaviour

  public static GameObject GetPooledGameObject(string poolName) {
    if(!Instance.pools.ContainsKey(poolName))
      return null;
    return Instance.pools[poolName].PopObject();
  }

  public static GameObject CreatePoolGameObject(GameObject prefab, Transform parent) {
    GameObject obj = Instantiate(prefab, parent) as GameObject;
    return obj;
  }

  #endregion

}
