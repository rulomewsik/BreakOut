using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class PersistenceAdministrator : MonoBehaviour
    {
        public List<PersistentScore> objectsToSave;

        public void OnEnable()
        {
            foreach (var so in objectsToSave)
            {
                so.Load();
            }
        }

        public void OnDisable()
        {
            foreach (var so in objectsToSave)
            {
                so.Save();
            }
        }
    }
}
