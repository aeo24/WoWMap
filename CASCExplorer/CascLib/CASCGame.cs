﻿using System.IO;

namespace CASCExplorer
{
    public enum CASCGameType
    {
        Unknown,
        HotS,
        WoW,
        D3,
        S2,
        Agent,
        Hearthstone,
        Overwatch
    }

    public class CASCGame
    {
        public static CASCGameType DetectLocalGame(string path)
        {
            if (Directory.Exists(Path.Combine(path, "HeroesData")))
                return CASCGameType.HotS;

            if (Directory.Exists(Path.Combine(path, "SC2Data")))
                return CASCGameType.S2;

            if (Directory.Exists(Path.Combine(path, "Hearthstone_Data")))
                return CASCGameType.Hearthstone;

            if (Directory.Exists(Path.Combine(path, "Data")))
            {
                if (File.Exists(Path.Combine(path, "Diablo III.exe")))
                    return CASCGameType.D3;

                if (File.Exists(Path.Combine(path, "Wow.exe")))
                    return CASCGameType.WoW;

                if (File.Exists(Path.Combine(path, "WowT.exe")))
                    return CASCGameType.WoW;

                if (File.Exists(Path.Combine(path, "WowB.exe")))
                    return CASCGameType.WoW;

                if (File.Exists(Path.Combine(path, "Agent.exe")))
                    return CASCGameType.Agent;

                if (File.Exists(Path.Combine(path, "Overwatch Launcher.exe")))
                    return CASCGameType.Overwatch;
            }

            return CASCGameType.Unknown;
        }

        public static CASCGameType DetectOnlineGame(string uid)
        {
            if (uid.StartsWith("hero"))
                return CASCGameType.HotS;

            if (uid.StartsWith("hs"))
                return CASCGameType.Hearthstone;

            if (uid.StartsWith("s2"))
                return CASCGameType.S2;

            if (uid.StartsWith("wow"))
                return CASCGameType.WoW;

            if (uid.StartsWith("d3"))
                return CASCGameType.D3;

            if (uid.StartsWith("agent"))
                return CASCGameType.Agent;

            if (uid.StartsWith("pro"))
                return CASCGameType.Overwatch;

            return CASCGameType.Unknown;
        }

        public static string GetDataFolder(CASCGameType gameType)
        {
            if (gameType == CASCGameType.HotS)
                return "HeroesData";

            if (gameType == CASCGameType.S2)
                return "SC2Data";

            if (gameType == CASCGameType.Hearthstone)
                return "Hearthstone_Data";

            if (gameType == CASCGameType.WoW || gameType == CASCGameType.D3)
                return "Data";

            if (gameType == CASCGameType.Overwatch)
                return "data/casc";

            return null;
        }

        public static bool SupportsLocaleSelection(CASCGameType gameType)
        {
            return gameType == CASCGameType.D3 ||
                gameType == CASCGameType.WoW ||
                gameType == CASCGameType.HotS ||
                gameType == CASCGameType.S2 ||
                gameType == CASCGameType.Overwatch;
        }
    }
}
