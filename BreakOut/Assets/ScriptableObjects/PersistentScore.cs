using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using File = System.IO.File;

namespace ScriptableObjects
{
    public abstract class PersistentScore : ScriptableObject
    {
        public void Save(string fileName = null)
        {
            var formatter = new BinaryFormatter();
            var file = File.Create(GetRoute(fileName));
            var json = JsonUtility.ToJson(this);

            formatter.Serialize(file, json);
            file.Close();
        }

        public virtual void Load(string fileName = null)
        {
            if (!File.Exists(GetRoute(fileName))) return;

            var formatter = new BinaryFormatter();
            var file = File.Open(GetRoute(fileName), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string) formatter.Deserialize(file), this);
            file.Close();
        }

        private string GetRoute(string fileName = null)
        {
            var pathFileName = string.IsNullOrEmpty(fileName) ? name : fileName;
            return $"{Application.persistentDataPath}/{pathFileName}.rulo";
        }
    }
}