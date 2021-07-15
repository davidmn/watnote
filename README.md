# watnote

Quickly setup your daily note markdown file in a sensible directory structure:

```
notes/
      2020/
            11/
            12/
                2020-12-31.md
      2021/
            01/
                2021-01-01.md

```

Built and tested on Windows with VS 2019 or Rider using .NET 5. Trying to have it work on Linux too.

## Usage

Put the executable in your path. Run `watnote config` to create a default config. Edit it with values of your choosing.

Run `watnote` to make a new file for today. If today's file exists it makes no change.

## Config

watnote config is store in .watconfig.json in your home directory



`NotesDir` is where your notes are stored in a hirarchy of year/month/YYYY-MM-DD.md

`BackupDir` will be where watdir backs stuff up eventually

`ShouldStartEditor` sets whether or not to open your new notes or config in your editor of choice

`EditorCmd` is your editor

`EditorArgs` is the arg string you want to pass into your editor. It has two replacement strings. `%FOLDERPATH%` is the NotesDir path. `%FILEPATH%` is the the path of the new note.

An example Windows config:

``` JSON
{
  "NotesDir": "C:\\notes",
  "BackupDir": "",
  "ShouldStartEditor": true,
  "EditorCmd": "C:\\Users\\USERNAME\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
  "EditorArgs": "%FOLDERPATH% --goto %FILEPATH%"
}
```

An example Linux config:

``` JSON
{
  "NotesDir": "/home/davidmn/notes",
  "BackupDir": "",
  "ShouldStartEditor": true,
  "EditorCmd": "code",
  "EditorArgs": "%FOLDERPATH% --goto %FILEPATH%"
}
```