using System.Runtime.Serialization;
using System.Text.Json;


namespace Engine
{
    public static class Configuration
    {
        public const string CONFIGFILENAME = "ENGINE_CONFIG.cfg";

        public static readonly ConfigData DEFCONFIG;
        public static readonly JsonSerializerOptions JSONSEROPTION;

        public static bool IsHaveConfigFile { get => File.Exists(CONFIGFILENAME); }
        public static bool ConfigFileIsCorrect { get => ReadConfigFile() != null; }

        static Configuration()
        {
            DEFCONFIG = new ConfigData()
            {
                Resolution = new Vector2u(640, 480),

                FrameRateLimit = 60,

                AllowResize = false,
                AllowDublicateLogInConsole = true,
                VerticalSyncEnabled = true,

                AwakeScene = "Coming soon...",
                WindowName = "FastEngine pre_alpha 0.1v [Scene test]"
            };

            JSONSEROPTION = new JsonSerializerOptions()
            {
                IncludeFields = true,
                WriteIndented = true,
            };
        }

        public static void WriteConfigFile(ConfigData data)
        {
            string json = JsonSerializer.Serialize(data, JSONSEROPTION);

            using (var writer = new StreamWriter(CONFIGFILENAME, false))
            {
                writer.WriteLine(json);
            }
        }

        public static ConfigData? ReadConfigFile()
        {
            if (!IsHaveConfigFile) return null;

            string data;

            using (var reader = new StreamReader(CONFIGFILENAME))
            {
                data = reader.ReadToEnd();
            }

            ConfigData? config;

            try
            {
                config = JsonSerializer.Deserialize<ConfigData>(data, JSONSEROPTION);
            }
            catch
            {
                config = null;
            }

            return config;
        }
    }

    [Serializable]
    public struct ConfigData
    {
        public string WindowName;
        public string AwakeScene;

        public Vector2u Resolution;

        public uint FrameRateLimit;

        public bool AllowResize;
        public bool AllowDublicateLogInConsole;
        public bool VerticalSyncEnabled;
    }
}
