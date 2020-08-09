# Command Line GLTF <=> GLB Packer/Unpacker
The idea of this tool is to provide a Windows command line tool to Pack GLTF files to GLB and to Unpack GLB file to GLTF.

This need is base on the glTF-Shell-Extensions tool from Gary Hsu (https://github.com/bghgary/glTF-Shell-Extensions)

The original tool is a shell extension with a GUI.
I just made some quick and dirty modification to call the tool on the command line.

The syntax is the following:
## Packing
`gltf.exe Pack name_of_the_gltf_file`

## Unpacking
`gltf.exe Unpack name_of_the_glb_file folder_to_output_the_resulting_gltf_file_into`

# Release
You can find a release with the .exe and its dll in the Release section [Releases](https://github.com/Pseudopode/glTF-Shell-Extensions/releases).

# Changes
The file that has been changed are UnpackWindow.xaml.cs, PackWindow.xaml.cd and App.xaml.cs

The changes are quick and dirty, a proper rewrite, that would remove all the GUI stuff could be a good thing in the future.


-------------------------------
# README from the original project:

# glTF Shell Extensions for Microsoft Windows
Microsoft Windows shell extensions that pack .gltf to .glb and unpack .glb to .gltf

# Installing
1. Download the latest installer `glTF-Shell-Extensions.msi` from [Releases](https://github.com/bghgary/glTF-Shell-Extensions/releases).
2. Unblock the installer file to avoid security warnings.
3. Double-click the installer file.

# Usage
## Packing `.gltf` to `.glb`

Right-click on a `.gltf` file and select `Pack to Binary glTF...`.

![](/Figures/Pack1.png)

Select a name for the new `.glb` file.

![](/Figures/Pack2.png)

## Unpacking `.glb` to `.gltf`

Right-click on a `.glb` file and select `Unpack to glTF...`.

![](/Figures/Unpack1.png)

Select a destination folder for the glTF files and click on the `Unpack` button.

![](/Figures/Unpack2.png)

![](/Figures/Unpack3.png)
