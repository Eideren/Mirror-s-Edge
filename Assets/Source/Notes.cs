#warning Equality comp with class def
#warning TdSwing: Look at StartMove, weird conversion, 'SwingAngle = ((float)(Clamp(((int)(SwingAngle)), ((int)(-1.20f)), ((int)(-0.70f)))));' maybe just dev' error since FClamp exist
#warning fix struct construction
#warning Look into including TdPlayerStart, GameInfo and co to manage player character spawn
#warning Look into array return functions, they should return a copy of the array


/* Notes on reversing:
Unpack *.u files
UEExplorer to rebuild unreal scripts from the unpacked files
    In this case I modified UELib to change the syntax used to output c# files instead

Manually fix the rest of the syntax issues the output contains
Manually rebuild native functions by looking at the exe through IDA or Ghidra
    You can use 'Epic Citadel' for engine stuff, the *.so file contains far more debug information than UE3 games on other platforms






https://wiki.beyondunreal.com/



*/