
# Endless Runner – Unity 3D Game

A fast-paced endless runner game developed using **Unity (C#)** and deployed via **WebGL on Netlify**. Dodge obstacles, collect points, and challenge your reflexes in a browser-playable 3D game experience!

>  This repository **does not include the player character model or animations** due to licensing and file size. Please import your own 3D character using [Mixamo](https://www.mixamo.com/) or any other animation source.

---

##  Features

- 3D Endless runner mechanics
- Obstacle spawning and dynamic movement
- Scoring and UI updates
- Game over state with restart logic
- WebGL build support for browser play
-  Includes a Windows executable version (`MyProject.exe`) for offline play

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/endless-runner-unity.git
   ```

2. Open the project in Unity (**Unity 2021.3+ recommended**).

3. Replace the placeholder player prefab with your own animated 3D character:
   - Use [Mixamo](https://www.mixamo.com/) to rig and animate a model
   - Import the FBX and animations into Unity
   - Assign the animations to the Animator Controller

4. Press **Play** in the Unity Editor or build using:
   - `File > Build Settings > WebGL > Build and Run` for browser version
   - `File > Build Settings > Windows > Build` to generate `MyProject.exe` for desktop

---

## Dependencies

- Unity (Tested on **2021.3.x LTS**)
- Standard Assets (for environment setup)
- WebGL build module or Windows build support

---

## Play Online

Try the live WebGL version here:  
[https://melodious-concha-017a0e.netlify.app/]

---

## Offline Windows Version

You can run the game offline by executing the included file:  
`MyProject.exe` 

---

## Folder Structure

```
Assets/
├── Animations/           # Player Animations
├── Scripts/              # Core C# scripts
├── Prefabs/              # Game prefabs like obstacles, player (placeholder)
├── Scenes/               # Main Game Scene
```

---

## Credits

- Developed by [Kalla Sanyasinaidu](https://www.linkedin.com/in/kalla-sanyasi-naidu/)
- Character animations recommended from [Mixamo](https://www.mixamo.com/)
- UI and models built using Unity tools

---

## License

This project is open-source under the [MIT License](LICENSE).  
Use freely and modify, but please credit when sharing publicly.

---
