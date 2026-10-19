# Sprite Collector — Taster Session Template

A small 2D Unity game for taster sessions. The student draws a character and a
collectible in Aseprite, drops them in, and plays as their own art.

No dying, no falling off the level, no failure state. The only goal is the moment
their drawing starts moving.

\---

## What's in here

```
Scripts/
  PlayerMovement2D.cs    on the Player
  Collectible.cs         on anything you can pick up
  ScoreKeeper.cs         on an empty GameManager object

Sprites/
  player\_placeholder.png        32x32, replaced by the student
  collectible\_placeholder.png   32x32, replaced by the student
```

The placeholders are deliberately plain. The student's own sprite should feel
like an upgrade.

\---

## Building the template (about 30 minutes, once)

### 1\. Create the project

Unity Hub → New Project → **2D (Built-In Render Pipeline)**.
Name it `SpriteCollector\_Template`.

Not URP. It adds setup you don't need here.

### 2\. Import TextMeshPro

**Window → TextMeshPro → Import TMP Essential Resources**

Do this before anything else or the score text won't work.

### 3\. Make your folders

In Assets, create: `Scripts`, `Sprites`, `Prefabs`, `Scenes`.

Drag the three `.cs` files into Scripts and the two `.png` files into Sprites.

### 4\. Fix the sprite import settings

Click each sprite in the Project window and set:

|Setting|Value|
|-|-|
|Texture Type|Sprite (2D and UI)|
|Pixels Per Unit|32|
|Filter Mode|**Point (no filter)**|
|Compression|None|

Press **Apply**.

Point filter is the critical one. Without it pixel art imports blurry, and
students are visibly deflated when their crisp drawing looks like a smudge.

### 5\. Build the Player

1. Drag `player\_placeholder` from Project into the Scene
2. Rename it `Player`
3. Set its **Tag** to `Player` (dropdown at the top of the Inspector)
4. Add Component → **Rigidbody 2D**

   * Gravity Scale → **0**
   * Constraints → tick **Freeze Rotation Z**
5. Add Component → **Box Collider 2D**
6. Add Component → **PlayerMovement2D**
7. Set Position to 0, 0, 0

Gravity Scale 0 stops the player falling off screen. Freeze Rotation Z stops it
spinning when it hits a wall. Both catch people out.

### 6\. Build the Collectible

1. Drag `collectible\_placeholder` into the Scene
2. Rename it `Collectible`
3. Add Component → **Box Collider 2D** → tick **Is Trigger**
4. Add Component → **Collectible**
5. Drag it from the Hierarchy into `Assets/Prefabs` to make it a prefab
6. Place six to eight copies around the level

Is Trigger is what lets the player walk through it and pick it up rather than
bumping into it.

### 7\. Build the walls

1. GameObject → 2D Object → Sprites → **Square**
2. Rename `Wall`, scale it into a long bar
3. Add Component → **Box Collider 2D**
4. Duplicate three times and arrange into a box around the play area
5. Optional: parent all four under an empty object called `Walls`

### 8\. Camera

Select Main Camera. Projection should already be **Orthographic**.
Set **Size** to about 5 and pick a background colour.

### 9\. GameManager and UI

1. GameObject → Create Empty → rename `GameManager`
2. Add Component → **ScoreKeeper**
3. GameObject → UI → **Text - TextMeshPro** (this creates the Canvas for you)

   * Rename it `ScoreText`, anchor top-left, font size about 36
4. Duplicate ScoreText → rename `WellDone`, text "Well done!", centre it, larger
5. Select GameManager and drag:

   * `ScoreText` into the **Score Text** slot
   * `WellDone` into the **Well Done Message** slot

If the score never updates, it's almost always an empty Score Text slot.

### 10\. Save and test

Save the scene as `Assets/Scenes/Game.unity`, press Play, and collect everything.

\---

\---

\---

## Extensions for fast finishers

* Change **Move Speed** in the Inspector and feel the difference. This is usually
the first time they see a number in code change how a game feels
* Tick **Spin** on a collectible and play with **Spin Speed**
* Set **Points Value** to 5 on one rare collectible
* Draw a second frame and make a two-frame walk animation
* Draw an enemy that doesn't do anything yet, and talk through what it would need

\---

## When it goes wrong

|What you see|What it is|
|-|-|
|Player falls off the screen|Gravity Scale isn't 0|
|Player spins when it hits a wall|Freeze Rotation Z not ticked|
|Collectibles don't disappear|Player object isn't tagged `Player`|
|Player bumps into collectibles|Is Trigger not ticked on the collectible|
|Score stays at 0 / 0|Score Text not dragged into the ScoreKeeper slot|
|Sprite looks blurry|Filter Mode isn't Point (no filter)|
|Sprite is huge or tiny|Pixels Per Unit doesn't match the sprite size|
|Player moves through walls|Walls have no Box Collider 2D|



