# PC Fps Uncapper

![banner](https://raw.githubusercontent.com/elliotvgalacios/pc-fps-uncapper/main/assets/banner.png)

![version](https://img.shields.io/badge/version-2.4.1-blue) ![platform](https://img.shields.io/badge/platform-Windows-lightgrey) ![license](https://img.shields.io/badge/license-MIT-green)

**About**

I built pc-fps-uncapper because too many PC titles still ship with hard 60 or 120 FPS caps that ruin mouse feel and add input latency. After fighting engine-enforced framerate limits in competitive matches where every millisecond counts, I wanted a lightweight tool that removes those artificial ceilings without touching game files or requiring constant config edits.

**Features**
- Removes DirectX and Vulkan framerate caps on the fly
- Per-game profiles that survive driver updates and Windows reinstalls
- Works in both fullscreen exclusive and borderless modes without alt-tabbing issues
- Optional low-latency present mode swap for reduced input lag
- Supports multi-monitor setups and high-refresh-rate displays up to 360 Hz
- Minimal overhead, runs as a small background process only when needed

**Requirements**
- Windows 10 or 11 (64-bit)
- 4 GB RAM
- .NET 6.0 Desktop Runtime

**Installation**
1. Download the latest release from [GitHub Releases](https://github.com/elliotvgalacios/pc-fps-uncapper/releases/latest)
2. Extract the archive to a permanent folder (not Downloads)
3. Run `pc-fps-uncapper.exe` as administrator once to register the overlay driver
4. Add your game executables through the main interface and set desired FPS targets

**Screenshots**

| Main Interface | Setup Wizard |
|----------------|--------------|
| ![main](https://raw.githubusercontent.com/elliotvgalacios/pc-fps-uncapper/main/assets/screenshot_main.png) | ![installer](https://raw.githubusercontent.com/elliotvgalacios/pc-fps-uncapper/main/assets/screenshot_installer.png) |

![app running](https://raw.githubusercontent.com/elliotvgalacios/pc-fps-uncapper/main/assets/screenshot_app.png)

**FAQ**

**Will this get me banned in online games?**  
Most modern anti-cheat systems flag external overlays more than simple framerate patches. I’ve used it for two years in Valorant and Apex without issues, but use at your own risk and disable it before any tournament client.

**Does uncapping FPS increase input lag?**  
Not with the present-mode tweak enabled. The tool forces DXGI flip model when possible, which usually lowers latency compared to the game’s default capped path.

**Why does my game still feel capped after applying a profile?**  
Check that VSync is fully disabled in both the game settings and NVIDIA/AMD control panel. Some titles also require the uncapper to be started before the game executable.

**Disclaimer**

This is a hobby project released under MIT. It is not affiliated with any game publisher. Use responsibly and understand that modifying rendering behavior can cause instability or violate terms of service in some titles.