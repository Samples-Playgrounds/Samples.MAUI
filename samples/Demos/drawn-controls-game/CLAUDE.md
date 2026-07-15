# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

A .NET MAUI demo that implements a sports cognitive-learning game (inspired by NeuroTrackerX) using the [Orbit](https://github.com/bijington/orbit) 2D game engine. Two projects:

- **`Orbit.Engine/`** — local working copy of the Orbit engine, published as `Bijington.Orbit.Engine` on NuGet
- **`AppMAUI.SportsCognitiveLearning/`** — the MAUI app that consumes the engine

Solution file: `drawn-controls-game.slnx` (`.slnx` format, not `.sln`)

## Build & Run

```sh
# Restore
dotnet restore drawn-controls-game.slnx

# Build all
dotnet build drawn-controls-game.slnx

# Run on Mac Catalyst (development target)
dotnet run --project ./AppMAUI.SportsCognitiveLearning/AppMAUI.SportsCognitiveLearning.csproj -f net10.0-maccatalyst

# Watch + run (hot reload)
dotnet watch build \
    --project ./AppMAUI.SportsCognitiveLearning/AppMAUI.SportsCognitiveLearning.csproj \
    -t:Run \
    -f:net10.0-maccatalyst
```

Target frameworks: `net10.0-android`, `net10.0-ios`, `net10.0-maccatalyst`, `net10.0-windows10.0.19041.0`

## Engine vs App Reference

The app currently references the engine via **NuGet package** (`Bijington.Orbit.Engine 0.2.2-preview.1`), not the local project. The `<ProjectReference>` in the app's `.csproj` is commented out. To develop against local engine changes, swap to the project reference:

```xml
<!-- Uncomment this: -->
<ProjectReference Include="..\Orbit.Engine\Orbit.Engine.csproj" />
<!-- And remove or comment out this: -->
<PackageReference Include="Bijington.Orbit.Engine" Version="0.2.2-preview.1" />
```

`orbit-main/` is a snapshot of the upstream orbit repo for reference only — it is not part of the solution.

## Architecture

### Orbit.Engine — Core Abstractions

The engine uses a **game loop driven by `IDispatcher`** at ~62.5 fps (configurable via `GameSceneManager.FrameRate`). Each tick calls `Update(ms)` then `Invalidate()` on the view.

**Class hierarchy:**

```
GameObjectContainer  (IGameObjectContainer, IRender, IUpdate)
├── GameScene        (IGameScene, IDrawable) — one scene/level at a time
└── GameObject       (IGameObject, IDrawable) — individual entities, has Bounds + CurrentScene
```

- `GameObjectContainer` — holds a list of `IGameObject` children; `Update` and `Render` delegate to all children. `LoadImage()` helper loads embedded resources cross-platform.
- `GameObject` — adds `Bounds (RectF)`, `CurrentScene`, and lifecycle hooks `OnAdded()` / `OnRemoved()`. Canvas state is saved/restored around each object's `Render`.
- `GameScene` — base for levels; propagates `CurrentScene` to all children on add.
- `GameSceneView : GraphicsView` — MAUI view that holds the active scene as its `IDrawable`.
- `GameSceneManager` — singleton (`IGameSceneManager`); manages `GameState` transitions and owns the dispatcher loop.

**GameState flow:** `Empty → Loaded → Started ↔ Paused → GameOver | Completed`

Register the engine in `MauiProgram.cs` with `.UseOrbitEngine()` (registers `GameSceneManager` as a singleton `IGameSceneManager`).

### AppMAUI.SportsCognitiveLearning — Game Implementation

Namespace: `HolisticWare.MAUI.OrbitEngine.SportsCognitiveLearning`

- `Scene : GameScene` — the cognitive learning scene; owns a `Target` object
- `Target : GameObject` — the visual target the player tracks
- `PageSportsCognitiveLearningScene : ContentPage` — hosts `GameSceneView`; the DI constructor calls `LoadScene<Scene>()` then `Start()`
- `MauiProgram.cs` — wires up MAUI app + `.UseOrbitEngine()`

To add a new game object: subclass `GameObject`, override `Render(ICanvas, RectF)` and `Update(double ms)`, then `Add()` it inside a `GameScene`.
