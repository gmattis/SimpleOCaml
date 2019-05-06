# SimpleOCaml
A simple OCaml IDE  
v1.1 release is out!  
## Windows :
Simply clone the repository and build the project (tested only with Visual Studio)  
If you just want to try it, check the releases!  
## Linux :
I'm trying to add Linux systems support. You can build the project with msbuild and run it with mono (tested on Debian 8, with mono 5.20.1.19, msbuild 16.0.0.0), but it works partially and there are some bugs. Feel free to post an issue when you encounter one!  
Please note that for the moment, it will only use OCaml executables installed with `apt-get install ocaml` (they are located in /usr/bin/ocaml)  
#
Using:  
* FastColoredTextBox Control: https://github.com/PavelTorgashov/FastColoredTextBox  
* TabControl-Extra Control: https://github.com/tradewright/tabcontrol-extra  
  
You should use included FastColoredTextBox dll instead of compiling it, as it is a modified version of it to enable using it with mono (clone my fork to compile it)  
#
Released under the GNU General Public License v3.0 (GPLv3): [License](https://github.com/gmattis/simpleOcaml/blob/master/LICENSE)
