# Still Alive
A port of Mirror's Edge (2008) in Unity 2022.1.0b7.2715.
For cease and desist or any other inquires, please contact me by email (contact at eideren.com) or over on discord (Eideren 4893).
This is a source-only repo to contribute to this project. You need to download assets from here first: https://mega.nz/folder/xowjjaDZ#j21jt39iwWm-GfIATeVrYA
The repo should be at https://bitbucket.org/Eideren/stillalive/src if you want to contribute your changes.
Here's a video showing it in action https://www.youtube.com/watch?v=W6-_Lgdt0zg

## Work left to do:
- Fix bugs in character controller
	+ Step up is too lenient 
	+ Walking towards inclines is too rigid 
		* compare with source to see whether this is expected behavior 
	+ Heisenbug, random null ref exception in `PawnLink_Unity.Update`, `if( _3pPlayer == null )` branch
- Tooling to import UE3 maps
	+ Some work for UE4 as already been done over here https://github.com/Eideren/Cartographer and could be used as reference
- Material extractor and importer from .upkg
	+ Exporting materials as T3D from editor strips a lot of properties, this is why we'll have to read from the `.upk` itself with https://github.com/Eideren/Unreal-Library
	+ Some work for UE4 to parse those as already been done over on https://github.com/Eideren/UDKImportPlugin and could be used as reference
- Add interact-able elements, buttons in Mirror's Edge, to trigger unity events or something similar.