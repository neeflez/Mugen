# Mugen

A compact desktop productivity app for Windows, written in C# with WPF. It puts three tools
on one screen: task tiles, a focus timer and a deadline list, and remembers them between sessions.

Built as the final project for an Object-Oriented Programming course at university (2024).

![Mugen main window](https://github.com/neeflez/Mugen/assets/121773353/c5d731ab-6da3-4722-8b4c-09012b0f9240)

## Features

- **Task tiles**: add up to six colour-coded tiles, each with a task title and a short description;
  delete a tile with its *Delete* button. When all slots are taken the app nudges you to finish
  what you started.
- **Focus timer**: a 45-minute Pomodoro-style countdown with Start / Stop, which resets automatically
  when it reaches zero.
- **Deadline list**: add up to five deadlines with a date picker, sort them by date
  (each click toggles ascending / descending), and remove one with a double-click.
- **Persistence**: tiles and deadlines are saved to JSON when the app is closed and loaded again on startup.
- **Custom window**: borderless, dark-themed 900 x 600 window that can be dragged by its header,
  with its own close button.

## Tech stack

- C# (`LangVersion` preview), WPF, XAML with custom control templates and styles
- .NET Framework 4.7.2
- [Newtonsoft.Json](https://www.newtonsoft.com/json) 13.0.3 for serialisation
- Visual Studio 2022

Object-oriented design highlights:

- Domain classes `Tile` and `Deadline`, kept separate from the serialisable DTOs
  `TileToJson` and `DeadlinesToJson`
- `Deadline` implements `IComparable<Deadline>`; sorting uses a hand-written bubble sort over that comparison
- A generic `ICloneable<T>` interface
- MVVM building blocks in `Core/`: `ObservableObject` (`INotifyPropertyChanged`) and `RelayCommand` (`ICommand`)

## Build and run

Requirements: Windows, **Visual Studio 2022** (17.7 or newer) with the *.NET desktop development*
workload and the .NET Framework 4.7.2 targeting pack. The NuGet dependency is included in
`Mugen/packages/`, so no restore step is needed.

1. Open `Mugen/Mugen.sln` in Visual Studio.
2. Select the **Release** configuration.
3. Press **F5** to build and run.

From a *Developer PowerShell for VS 2022*:

```powershell
msbuild Mugen\Mugen.sln -p:Configuration=Release
cd Mugen\Mugen\bin\Release
.\Mugen.exe
```

This is a classic (non-SDK-style) .NET Framework project, so use Visual Studio or MSBuild
rather than `dotnet build`.

> **Note:** the app looks for its data in `Mugen/Mugen/JsonFiles/`, resolved relative to the
> `bin\Release` working directory, so run the Release build from that folder (Visual Studio does
> this automatically). The repository ships with neutral sample data in `JsonFiles/Tiles` and
> `JsonFiles/Deadlines`; closing the app overwrites these files with your own tiles and deadlines.

## Project structure

```
Mugen/
├── Mugen.sln
├── Mugen/
│   ├── App.xaml(.cs)            # Application entry point and shared resources
│   ├── MainWindow.xaml          # UI layout, styles and control templates
│   ├── MainWindow.xaml.cs       # Tiles, timer, deadlines, JSON load/save
│   ├── Tile.cs                  # Task tile model
│   ├── Deadline.cs              # Deadline model (IComparable)
│   ├── TileToJson.cs            # Serialisable DTO for tiles
│   ├── DeadlinesToJson.cs       # Serialisable DTO for deadlines
│   ├── Core/                    # ObservableObject, RelayCommand
│   ├── JsonFiles/               # Sample data: Tiles, Deadlines
│   └── Properties/              # Assembly info, resources, settings
└── packages/                    # Newtonsoft.Json 13.0.3 (packages.config)
```

## License

Released under the MIT License. See [LICENSE](LICENSE).
