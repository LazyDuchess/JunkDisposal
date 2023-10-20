# JunkDisposal
This is a configurable mod that can remove stuff from levels that might be annoying, such as ground poles you can get caught on, cars, people or physics objects (trash bins, chairs, etc.) or make them way lighter so you can push them out of the way.

# Configuration
By default, the mod will remove ground poles and make physics props extra light. On first launch, a fully documented configuration file will be generated under **"BepInEx/config/com.LazyDuchess.BRC.JunkDisposal.cfg"**. Here you can pick which features to enable and what items to remove from levels.

# Building from source
You will need to provide a publicized version of the **"Assembly-CSharp.dll"** file which can be found in your "Bomb Rush Cyberfunk_Data/Managed" folder. To publicize it, you can use the [BepInEx.AssemblyPublicizer](https://github.com/BepInEx/BepInEx.AssemblyPublicizer) tool, and paste the result into **"lib/Assembly-CSharp-publicized.dll"** in this project's root directory.
