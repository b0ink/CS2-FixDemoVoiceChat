# CS2 Fix Demo Voice Chat

Counter-Strike 2's SourceTV currently does not record player's voice chat by default unless the server has `sv_alltalk 1` enabled. This plugin modifies the SourceTV's voice flags to hear the voices of all players.

This should work with any gamemode/config as the player's voice flags are not changed.

## Requirements
- Metamod
- CounterStrikeSharp (>v143)

## Installation
- Download the [latest release](https://github.com/b0ink/CS2-FixDemoVoiceChat/releases)
- Upload the contents of the `/Release` folder into `game/csgo/addons/counterstrikesharp/plugins/FixDemoVoiceChat/`
- The SourceTV's voice flag fix will be applied on each round start

# Demo Playback
To hear all player's voice chat, use the following commands in your console **before** loading up the demo:
```
tv_listen_voice_indices -1
tv_listen_voice_indices_h -1

playdemo yourdemo.dem
```
Per [u/roge-s's comment on reddit](https://www.reddit.com/r/GlobalOffensive/comments/17i3zuc/comment/k6s7fjz), these convars can be used to select specific players to hear in demos:
```
tv_listen_voice_indices 0: Bitfield of playerslots to listen to voice messages from when connected to SourceTV, default is none
tv_listen_voice_indices_h 0: High 32 bits of bitfield of playerslots to listen to voice messages from when connected to SourceTV, default is none
```
> These are both client-side convars, so I don't think they will affect the demo recording. You might be able to use them client-side during demo playback, but I'm not sure. That being said, I would expect them to work for live CSTV spectators (just remember that they need to be set on each of the spectators' game clients).
Going by the descriptions of these convars, you need to enable each bit for the corresponding player slots you want to be able to hear. `tv_listen_voice_indices` would be used to configure player slots 0-31, and `tv_listen_voice_indices_h` for player slots 32-63.

> The confusing part about this is that the CS2 console seems to be treating these variables as signed 32-bit integers. That makes setting up these convars a bit annoying since you need to deal with the two's complement encoding that signed int32's use on x86 platforms.
With this all in mind, I would expect that by setting both of these convars to the decimal value of -1, you should be able to hear everyone.

> If you want to selectively hear players, you can use a 32-bit two's complement integer calculator such as this one: https://www.binaryconvert.com/convert_signed_int.html?hexadecimal=0
> For this calculator in particular, just enable squares at the bottom corresponding to the player slots you want to hear, then click to "convert to decimal", and then u
