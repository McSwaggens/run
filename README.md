:octocat: __run__

Run is a simple C# application/script to compile and automatically run your projects using xbuild and mono

__How to use run__

Quite simple, actually, just `cd` into a directory/repository you wish to build and execute and enter the command `run`.

The commands it will use are `xbuild` and `mono` so make sure you have those installed.

__Why not just use the terminal to execute it normally?__

Run shortens the command from, for example, `xbuild example.sln; mono example/bin/Debug/example.exe <args>` to just `run <args>`.

