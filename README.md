# watnote

Quickly setup your daily note markdown file in a sensible directory structure.

Built and tested on Windows with VS 2019 or Rider using .NET 5. Trying to have it work on Linux too.

## Settings

watnote config is store in .watconfig.json in your home directory

``` JSON
{
  "NotesDir": "C:\\notes",
  "BackupDir": "",
  "ShouldStartEditor": true,
  "EditorCmd": "C:\\Users\\USERNAME\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
  "EditorArgs": "%FOLDERPATH% --goto %FILEPATH%"
}
```

`NotesDir` is where your notes are stored in a hirarchy of year/month/YYYY-MM-DD.md
`BackupDir` will be where watdir backs stuff up eventually
`ShouldStartEditor` will set whether or not to open your new notes or config in your editor
`EditorCmd` is your editor
`EditorArgs` is any extra args you want, with two replacement string for you to put the notes dir and file dir in