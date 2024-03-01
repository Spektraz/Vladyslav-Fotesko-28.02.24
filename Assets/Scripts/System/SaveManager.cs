using UnityEngine;

namespace System
{
   public static class SaveManager 
   {
      public static void Save(string key, string saveData)
      {
         PlayerPrefs.SetString(key, saveData);
      }
  
        public static void Save(string key, int saveData)
      {
         PlayerPrefs.SetInt(key, saveData);       
      }
        public static void Save(string key, float saveData)
        {
            PlayerPrefs.SetFloat(key, saveData);
        }
        public static int LoadInt(string key)
      {
         if (PlayerPrefs.HasKey(key))
         {
            var loadedString = PlayerPrefs.GetInt(key);
            return loadedString;
         }

         return 0;
      }
        public static float LoadFloat(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var loadedString = PlayerPrefs.GetFloat(key);
                return loadedString;
            }

            return 0;
        }
        public static string LoadString(string key)
      {
         if (PlayerPrefs.HasKey(key))
         {
            string loadedString = PlayerPrefs.GetString(key);
            return loadedString;
         }

         return null;
      }
        public static void DeleteData()
        {
            PlayerPrefs.DeleteAll();
        }
        public static void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
        public static void DeleteKeys(string[] strings, Action value)
        {
            foreach(var s in strings)
            {
                PlayerPrefs.DeleteKey(s);            
            }
            value.Invoke();
        }
      
    }
}
