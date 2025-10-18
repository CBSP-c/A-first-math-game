## Quick context

This repository is a minimal C# console application (a simple Math game) implemented as a single project. The main program lives in `Program.cs` using top-level statements and local functions. There is no database or external services: game state is kept in-memory in `List<string> gameHistoryPoints` and cleared when the process exits.

Key files
- `Program.cs` — entire application flow (menu loop, `game()` and `displayGameHistory()` local functions).
- `TestProject.csproj` — .NET SDK project targeting `net8.0` with `ImplicitUsings` and `Nullable` enabled.
- `TestProject.sln` — solution file (single project).

Architecture notes for an agent
- Single-exe console app. Keep changes focused to `Program.cs` unless adding new components.
- Code uses C# top-level statements and local functions; do not reintroduce an explicit `Main` unless necessary.
- `ImplicitUsings` is enabled (see `.csproj`), so avoid adding unnecessary global using directives.

Data flow & behavior details
- User interaction is via `Console.ReadLine()`/`Console.WriteLine()`.
- Scores are appended to `gameHistoryPoints` and displayed by `displayGameHistory()`.
- Division problems enforce integer results by re-generating operands until `randomA % randomB == 0`.

Project-specific conventions
- Accept that input parsing is currently done with `Convert.ToInt32(Console.ReadLine())`; if you change it, prefer `int.TryParse` and add a small input loop to avoid exceptions.
- Small, imperative style: functions are local and state is in simple collections. Prefer minimal refactors that keep that style for readability.
- Pauses are implemented with `Thread.Sleep(...)`. Keep or replace with short console prompts if changing UX.

Build / run / debug (PowerShell)
```powershell
dotnet build
dotnet run --project .
dotnet publish -c Release
```
For debugging open the folder in Visual Studio or VS Code with the C# extension. The app is a console app — start it with the debugger attached or use `dotnet run` when not debugging.

When modifying the project
- If adding packages, update `TestProject.csproj` with a `<PackageReference/>` and run `dotnet restore` (or `dotnet build` which restores automatically).
- If adding tests, create a new test project (xUnit/NUnit) and reference this project. Example: `dotnet new xunit -o tests && dotnet add tests reference .` then `dotnet test`.

Examples of safe edits (explicit guidance)
- Input validation: replace `Convert.ToInt32(Console.ReadLine())` with a loop using `int.TryParse` to prompt again on invalid input.
- Preserving division rule: keep the `while (randomA % randomB != 0)` logic or replicate its intent if refactoring the generator into a helper.
- History format: `gameHistoryPoints` stores stringified scores — if you change to a richer type, update `displayGameHistory()` accordingly.

What not to do
- Do not remove top-level statements or implicit usings without a clear reason — they are intentional for this tiny app.
- Don't introduce new runtime services or databases; this app is intentionally in-memory.

If something is unclear
- Read `Program.cs` first — it contains the entire behavior. Ask here which part of the UX or logic you should change before sweeping refactors.

Please review these instructions and tell me any missing parts or sections you want expanded (tests, CI, or coding style rules).
