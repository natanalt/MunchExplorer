# MunchExplorer
MunchExplorer is a simple tool for viewing LVL files for Star Wars Battlefront 2
from Pandemic Studios and perhaps its other formats seen in the modkit and other
Zero Engine based games, maybe Star Wars Battlefront 1 included (although I made
it for SWBF2, as that's what I happen to be reversing at the moment).

Note, that larger files opened with the tool may take a few hundred megabytes of
memory. That's not much of an issue to me, though, so I didn't try to optimize the
loading process to maybe load node information dynamically. Too bad. Same thing
goes for the hexdumps, which generate large strings, many times larger than the
raw nodes themselves.

## Tree generation
The generated tree that can be seen on the sidebar is generated automatically based
on each nodes' content. If a node contains what seems to be valid child hierarchy
matching the size of its parent, it's accepted.
