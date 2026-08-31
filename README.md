# 🍕 Pizza Hunt — Intergalactic Delivery (3D Platformer)

**Pizza Hunt** is a 3D isometric (*Top-Down*) platformer developed in **Unity 6** (originally developed in Unity 2022 Built-in pipeline versions but refactored to URP - Unity 6) using the **Universal Render Pipeline (URP)**.

Originally created as the final team project for a Unity development course by the **Buenos Aires City Government**, it is currently being refactorized and polished with clean architecture principles for inclusion in a professional game development portfolio.

---

## 🚀 Premise & Story
An intergalactic pizza delivery driver crash-lands his spaceship on an alien planet. To complete his mission, he must navigate through platforming puzzles, traps, and hazards to collect all lost items from his order (pizzas, sodas, and collectibles) and reach the final delivery point.

---

## 🎮 Core Mechanics & Game Loop

* **Isometric Movement & 3D Physics:** Smooth player controls and jump mechanics integrated with scale-adaptive ground detection (*Raycasting*).
* **Power-Up System with URP Post-Processing:**
  * 🍄 **TBD (Scale Up):** Increases player scale and mass while dynamically adjusting physical collision and jump raycasts.
  * 🧪 **TBD -Mini-Pill- (Scale Down):** Reduces player size to navigate tight spaces and narrow passages.
  * ⚡ **Mushroom Super Jump:** Multiplies vertical jump force and triggers visual post-processing effects via **URP Volume Profiles** (Chromatic Aberration, Color Adjustments, and potentially Vignette).
* **Collectibles & Interactables:** Pickup system that drives level progression and win conditions.
* **Complete Game Loop:** Main Menu, Settings (Audio/Video), Credits, Playable Levels, and a Game Win scene with an animation included.

---

## 🛠️ Tech Stack

* **Engine:** Unity 6 (LTS)
* **Render Pipeline:** Universal Render Pipeline (URP)
* **Language:** C# (.NET)
* **Input System:** Unity Input System API
* **Post-Processing:** Native URP Volume Framework

---

## 🏗️ Technical Highlights & Refactoring

* **URP Integration:** Full pipeline migration from Built-in to URP, including material conversion to *URP Lit/Unlit* shaders and UV remapping for texture atlases via *Tiling & Offset* adjustments.
* **Scale-Adaptive Raycasting:** Ground detection dynamically scales with the player’s $Y$-axis transform scale, preventing physics breaking during size-altering power-ups.
* **Post-Processing Control:** Runtime manipulation of URP `Volume Profiles` and `Weight` parameters to handle clean visual transitions without memory overhead.

---

## 📁 Project Structure

```text
Assets/
 ├── Scripts/          # Player movement, Power-Up logic, and scene controllers
 ├── Settings/         # URP Assets, Renderers, and Volume Profiles
 ├── Models/           # 3D prefabs for characters, environment, and collectibles
 ├── Materials/        # URP Lit/Unlit compatible materials
 └── Scenes/           # MainMenu, Settings, Level 1, Level 2, WinScene
