using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Progres Pemain",
    menuName = "Game Kuis/Progres Pemain")]

public class PlayerProgress : ScriptableObject
{
 [System.Serializable]
 
 public struct MainData
 {
    public int koin;
    public Dictionary<string, int> progresLevel;
 }   

 [SerializeField]
 private string _filename = "savefile.txt";

 public MainData progresData = new MainData();

 public void SimpanProgres()
 {
    progresData.koin = 100;
    if (progresData.progresLevel == null)
    progresData.progresLevel = new();
    progresData.progresLevel.Add("Level Pack 1", 3);
    progresData.progresLevel.Add("Level Pack 3", 5);
    
    var directory = Application.dataPath + "/Temporary/";
    var path = directory + "/" + _filename;

    if(!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
        Debug.Log("Directory has been Created:" + directory);
    }

    if (File.Exists(path))
    {
        File.Create(path).Dispose();
        Debug.Log("file created: " + path);
    }

    var fileStream = File.Open(path, FileMode.OpenOrCreate);
    // var formatter = new BinaryFormatter();

    fileStream.Flush();
    // formatter.Serialize(fileStream, progresData);

    var writer = new BinaryWriter (fileStream);

    writer.Write(progresData.koin);
    foreach (var i in progresData.progresLevel)
    {
        writer.Write(i.Key);
        writer.Write(i.Value);
    }

    writer.Dispose();
    fileStream.Dispose();

 Debug.Log($"{_filename} Berhasil Tersimpan");
 }

 public bool MuatProgres()
 {
    string directory = Application.dataPath + "/Temporary/";
    string path = directory + "/" + _filename;

    var fileStream = File.Open(path, FileMode.OpenOrCreate);

    try
        {
            var reader = new BinaryReader(fileStream);

            try
            {
                progresData.koin = reader.ReadInt32();
                if (progresData.progresLevel == null)
                progresData.progresLevel = new();
                while (reader.PeekChar() != -1)
                {
                    var namaLevelPack = reader.ReadString();
                    var levelKe = reader.ReadInt32();
                    progresData.progresLevel.Add(namaLevelPack, levelKe);
                    Debug.Log($"{namaLevelPack}:{levelKe}");
                }

                reader.Dispose();
            }
            catch (System.Exception e)
            {
                Debug.Log($"ERROR: Terjadi kesalahan saat memuat progress\n{e.Message}");

                reader.Dispose();
                fileStream.Dispose();

                return false;
            }
        // var formatter = new BinaryFormatter();

        // progresData = (MainData)formatter.Deserialize(fileStream);

        fileStream.Dispose();

        Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

        return true;
    }
    catch (System.Exception e)
    {
        Debug.Log($"ERROR: Terjadi kesalahan saat memuat progress\n{e.Message}");

        return false;
    }
 }
}
