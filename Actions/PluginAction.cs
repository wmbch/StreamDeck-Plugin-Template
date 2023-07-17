using BarRaider.SdTools;
using Newtonsoft.Json.Linq;

namespace StreamDeckPluginTemplate.Actions
{
    [PluginActionId("$safeprojectname$.pluginaction")]
    internal class PluginAction : KeypadBase
    {
        private readonly PluginSettings _settings;

        public PluginAction(ISDConnection connection, InitialPayload payload)
            : base(connection, payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Constructor called of $safeprojectname$.pluginaction");

            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                _settings = new PluginSettings();
                SaveSettings();
            }
            else
            {
                _settings = payload.Settings.ToObject<PluginSettings>();
            }
        }
        
        public override void Dispose()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"$safeprojectname$.pluginaction disposed");
        }

        public override void KeyPressed(KeyPayload payload)
        {
        }

        public override void KeyReleased(KeyPayload payload)
        {
        }

        public override void OnTick()
        {
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Received global settings for $safeprojectname$.pluginaction");

            Tools.AutoPopulateSettings(_settings, payload.Settings);
            SaveSettings();
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Received settings for $safeprojectname$.pluginaction");
        }

        private Task SaveSettings()
        {
            return Connection.SetSettingsAsync(JObject.FromObject(_settings));
        }
    }
}
