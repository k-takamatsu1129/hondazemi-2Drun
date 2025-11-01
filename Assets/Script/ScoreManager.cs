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

    // �ۑ���t���p�X
    public static string FilePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }

    // �t�H�[�}�b�g: name|score
    public static bool SaveScore(string playerName, float score)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? Application.persistentDataPath);

            // �G�X�P�[�v���Ȃ��ȈՃt�H�[�}�b�g�i'|' �𖼑O�Ɏg��Ȃ��O��j
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

    // �t�@�C�����炷�ׂēǂݍ��݁A�p�[�X�A�~���\�[�g���ĕԂ�
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

            // �~��: �����X�R�A����
            list = list.OrderByDescending(e => e.score).ThenBy(e => e.name).ToList();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to read scores: {ex}");
        }
        return list;
    }

    // �e�X�g�p: �X�R�A��S������
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