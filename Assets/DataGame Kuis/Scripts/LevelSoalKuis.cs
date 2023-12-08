using UnityEngine;

[CreateAssetMenu(
    fileName = "Pertanyaan Baru",
    menuName = "Game Kuis/Level Pertanyaan")]

public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]

    public struct OpsiJawaban
    {
        public string jawabanTeks;
        public bool adalahBenar;
    }
    public string pertanyaan = string.Empty;
    public Sprite petunjukJawaban = null;
    public int levelPackIndex = 0;

    public  OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];
}
