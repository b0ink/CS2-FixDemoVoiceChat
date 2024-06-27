# CS2 Fix Demo Voice Chat

Counter-Strike 2's SourceTV currently does not record player's voice chat by default unless the server has `sv_alltalk 1` enabled. This plugin modifies the SourceTV's voice flags to hear the voices of all players.

This should work with any gamemode/config as the player's voice flags are not changed.

## Requirements
- [Metamod](https://www.sourcemm.net/downloads.php/?branch=master)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp) (>v244) (.NET 8)

## Installation
- Download the [latest release](https://github.com/b0ink/CS2-FixDemoVoiceChat/releases)
- Upload the `/FixDemoVoiceChat` folder into `game/csgo/addons/counterstrikesharp/plugins/`
- The SourceTV's voice flag fix is applied on each round start

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
> Going by the descriptions of these convars, you need to enable each bit for the corresponding player slots you want to be able to hear. `tv_listen_voice_indices` would be used to configure player slots 0-31, and `tv_listen_voice_indices_h` for player slots 32-63.

> The confusing part about this is that the CS2 console seems to be treating these variables as signed 32-bit integers. That makes setting up these convars a bit annoying since you need to deal with the two's complement encoding that signed int32's use on x86 platforms.
With this all in mind, I would expect that by setting both of these convars to the decimal value of -1, you should be able to hear everyone.

> If you want to selectively hear players, you can use a 32-bit two's complement integer calculator such as this one: https://www.binaryconvert.com/convert_signed_int.html?hexadecimal=0
> For this calculator in particular, just enable squares at the bottom corresponding to the player slots you want to hear, then click to "convert to decimal", and then use the decimal representation to set the corresponding convar in the game client.

> In CS:GO you would use the either `status` or `voice_player_volume` in console to reveal which slots each player is using, but neither of these work in CS2 demos.
> You can use the `spec_player <slot number>` to spectate the corresponding player and manually figure out which which slot they are using.

> The order of slots represented in the binary converter are reversed, so to hear the player in slot 1, found by using the command `spec_player 1`, you would select the far right box then convert to decimal.
