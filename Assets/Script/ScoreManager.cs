using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class ScoreEntry
{
    public string name;
    public int score;
}

public static class ScoreManager
{
    static readonly string fileName = "scores.txt";

    // 保存先フルパス
    public static string FilePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }

    // フォーマット: name|score
    public static bool SaveScore(string playerName, int score)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? Application.persistentDataPath);

            // エスケープしない簡易フォーマット（'|' を名前に使わない前提）
            string line = $"{playerName}|{score}";
            File.AppendAllLines(FilePath, new[] { line });
            Debug.Log($"Saved score to {FilePath}: {line}");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to save score: {ex}");
            return false;
        }
    }

    // ファイルからすべて読み込み、パース、降順ソートして返す
    public static List<ScoreEntry> ReadScores()
    {
        var list = new List<ScoreEntry>();
        try
        {
            if (!File.Exists(FilePath))
            {
                return list;
            }

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length != 2) continue;
                string name = parts[0];
                if (!int.TryParse(parts[1], out int score)) continue;
                list.Add(new ScoreEntry { name = name, score = score });
            }

            // 降順: 高いスコアが上
            list = list.OrderByDescending(e => e.score).ThenBy(e => e.name).ToList();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to read scores: {ex}");
        }
        return list;
    }

    // テスト用: スコアを全部消す
    public static void ClearScores()
    {
        try
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);
            Debug.Log($"Deleted score file at {FilePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to clear scores: {ex}");
        }
    }
}