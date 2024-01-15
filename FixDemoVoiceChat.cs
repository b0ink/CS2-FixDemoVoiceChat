using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace FixDemoVoiceChat;
public class FixDemoVoiceChat : BasePlugin
{
    public override string ModuleName => "Fix Voice Chat in Demo Recordings";
    public override string ModuleAuthor => "BOINK";
    public override string ModuleVersion => "1.0.0";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundStart>(((@event, info) =>
        {
            Server.NextFrame(() =>
            {
                FixHltvVoiceChat();
            });
            return HookResult.Continue;
        }));
    }

    void FixHltvVoiceChat()
    {
        var HLTV = Utilities.GetPlayers().Where(p => p.IsHLTV).First();

        if (HLTV != null && HLTV.IsValid)
        {
            HLTV.VoiceFlags &= ~VoiceFlags.Normal;
            HLTV.VoiceFlags |= VoiceFlags.All;
            HLTV.VoiceFlags |= VoiceFlags.ListenAll;
        }
    }

}

