# Getting VS Code Unity Autocomplete Working

Follow these steps in order. Skipping the .NET SDK step is the most common
reason this setup fails.

## 1. Install prerequisites

- **Unity Hub and Unity** 
- **VS Code**
- **.NET SDK 9.0.200 or newer.** This is required even though Unity itself
  doesn't need it. Unity's project generator now produces `.slnx` solution
  files instead of `.sln`, and reading a `.slnx` requires SDK 9.0.200+.
  Check what you have in a terminal with:
  ```
  dotnet --list-sdks
  ```
  If nothing shows 9.0.200 or higher, install one (extra SDKs install
  side-by-side and don't remove older ones):
  ```
  (I'm on Mac, but you can get dotnet SDK's directly from Microsoft's website)
  brew install --cask dotnet-sdk
  ```

## 2. Install the VS Code extensions

Install these three:

- C# -- `ms-dotnettools.csharp`
- C# Dev Kit -- `ms-dotnettools.csdevkit`
- Unity -- `visualstudiotoolsforunity.vstuc`
- I use Unity Code Snippets as well, but this one isn't required.

C# Dev Kit is what actually loads the Unity project
and resolves `UnityEngine`/`UnityEditor` types. Without it, you only get
generic C# syntax help and not Unity API completions.

## 3. Point Unity at VS Code

In Unity: **Preferences -> External Tools -> External Script Editor** -> select your VS Code install.

Then click **Regenerate project files**. Do this again any time the Unity
version, VS Code install, or installed packages change.

## 4. Open the project and verify the solution actually loaded

Open the project from Unity (double-click a script) or open the project
folder directly in VS Code.

**Do not assume it worked just because C# looks like it's working.** Plain
syntax highlighting, red squiggles, and generic snippets (e.g. from the Unity
snippets extension) all work even when the  Unity project never loaded.
Confirm everything loaded:

- Open the **Solution Explorer** view. It should show your project name (e.g. 
  `F26-IntroGameDev`), `Assembly-CSharp`, and your scripts.
- The **status bar** at the bottom of the window should show a project name
  (e.g. `Assembly-CSharp`) when a script is focused.
- Open a script and type `transform` or hover over `MonoBehaviour` and
  you should get  Unity API suggestions/tooltips, not just snippets.

### If the solution doesn't auto-load

Sometimes C# Dev Kit detects the project's default solution
(`.vscode/settings.json` -> `dotnet.defaultSolution`) but doesn't actually open
it on startup. Fix it manually:

Command Palette (`Cmd+Shift+P`) -> **".NET: Switch Solution"** -> select the
`.slnx` file.

If instead you get a popup saying something like *"...slnx is unable to open,
please ensure your .NET SDK version is 9.0.200 or higher"* and go back to step 1, your SDK is too old.