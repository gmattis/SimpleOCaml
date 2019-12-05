# SimpleOCaml
A simple OCaml IDE  
v1.2 release is out!  
## Windows :
Simply clone the repository and build the project (tested only with Visual Studio)  
If you just want to try it, check the releases!

You will also need to download Visual C++:
  [Download Visual C++ x86 (32 bits)](https://aka.ms/vs/16/release/vc_redist.x86.exe)
  [Download Visual C++ x64 (64 bits)](https://aka.ms/vs/16/release/vc_redist.x64.exe)
  
## Linux / MacOS :
I'm trying to add Linux systems support. You can build the project with msbuild and run it with mono (tested on Debian 8, with mono 5.20.1.19, msbuild 16.0.0.0), but it works partially and there are some bugs. Feel free to post an issue when you encounter one!  
I'm also trying to add MacOS support. I have not tested the project under MacOS, but it should work like under Linux, with Mono.  
Please note that for the moment, it will only use OCaml executables with the `ocaml` command in the terminal (for both Linux and MacOS).  
#
Using:  
* FastColoredTextBox Control: https://github.com/PavelTorgashov/FastColoredTextBox  
* TabControl-Extra Control: https://github.com/tradewright/tabcontrol-extra  
  
You should use included FastColoredTextBox dll instead of compiling it, as it is a modified version to enable using it with Mono (please clone my fork if you want to compile it)  
#
Released under the GNU General Public License v3.0 (GPLv3): [License](https://github.com/gmattis/simpleOcaml/blob/master/LICENSE)
