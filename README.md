# PROJECT SETUP

In this **ReadMe**, you find instructions for getting started with Assignment 1 of IVGM, as well as necessary steps to prepare your Unity project for submission. Please read the entire document with your group before you get started. To make sure there are no conflicts on Git, we recommend that you do these steps together.

This Unity project includes the basic FPS Microgame. It does not include any mods from the tutorials. The assets from the base game (e.g., enemies, game objectives, level building components) can be found within `Assets > FPS`. You can use these assets to build your levels and freely add to them as needed. By default, the project also needs the `TextMesh Pro` folder. You don't need to change anything inside of here.

`Assets > 01_Menu > MainMenuScene` is a modified version of the main menu. It can either start the first level in the sequence or you can select a specific level. The `GameManager` included in your individual scenes will automatically load the next level upon completion of your level. You will need to add your levels to the Build Settings in the correct order for the game to load them.

We recommend that you organise your work in `Assets > 02_Student Folders`.


## Setting up

- Copy the `FirstnameLastname_Assets` folder provided within `Assets > 02_Student Folders`.
- Rename it with your own name, following the naming convention for clarity and consistency.
- Rename the scene file within your folder in the same manner.
- After you have renamed your scene file, open it and bake the navigation mesh. At this point, Unity will make a folder to store the navigation mesh with the new scene name. Once you've done this, you can delete the folder with the old scene name.
- Add your level to the Build Settings. Open `File > Build Settings...` in the menu bar. Add your scene by either having it open and selecting `Add Open Scenes`, or drag it into the list from the Project window. **Leave MainMenuScene in the top position (0)!**

### Important!

- By default, your scene file comes with a very simple level geometry, the `ObjectiveReachPoint` win condition, the `Player` prefab, and a modified version of the `GameManager`. Do not remove the `GameManager` or change the `GameFlowManager` script, as it handles loading the next scene.
- The `GameFlowManager` has a new variable added to it: `Replay Scene`. By default, it is unchecked. This means that when you finish your level, the game will load the next scene included in the build. If there is no other scene, it will load the Main Menu. For testing, you'll want to replay your level many times. If you check this variable, the game will reload your own scene instead. **Take care that you uncheck this variable when handing in your levels!**
- Use your folder to organise any assets you use in your scene. You can also use assets directly from the `Assets > FPS`. **Bear in mind that if you make changes to assets, they will affect all scenes that use those assets!** If you plan to make adjustments to an asset or want to prevent others from accidentally changing something you use, copy the asset to your own folder and import it into your scene from there. If you use shared assests and want to make changes, discuss it with the group. For example, if you all decide on the same player parameters, you can all use the existing prefab and change it accordingly.
- Be consistent with keeping your project updated on Git and clearly label your versions. If a mistake is made that affects other people, you can always return to a previous version to fix it.


## Before handing in
- To be able to play your levels in the final game, you need to make sure the order is correct in the Build Settings. Open `File > Build Settings...` in the menu bar.
- Check that all scenes are in the list. If you haven't done so yet, add your scene (see the instructions above).
- Adjust the order of your scenes by dragging them up or down. **Leave the Main Menu scene at the top of the list (position 0)!** You can remove any scene by right-clicking and choosing `Remove Selection`.
- Check that no one has `Replay Scene` checked in their `GameManager`, or you will not be able to advance past that level.
- **Optional:** Depending on how many people are in your group, you can deactivate the level selection buttons you do not need. To do this, open `Assets > 01_Menu > MainMenuScene`. In the Hierarchy, select the button (`Canvas > LevelSelect > SelectLevel_...`) and deactivate it. You'll want to leave the numbers that are used in your Build Settings list and only deactivate buttons with higher numbers that your group doesn't use.
- Test that everything works correctly:
  - If you leave `MainMenuScene` at the top of the Build Settings list (position 0), it will be loaded first when playing the final game.
  - By default, pressing  `Start` will begin playing the second scene on the list (position 1).
  - The numbered buttons should change the starting level to another scene in the Build Settings list. The on-screen text should show the name of the scene that will be loaded. If there is no level to load at that number in the list, the game will send a message to the console and the selected level won't change.
  - When a level is finished, it should advance to the next scene in the list. If there are no more scenes, the game should return to the main menu.
