Installation:
-You need to copy these files into your Assets\Plugins folder.
-Under Unity 3.5 you need to delete the Plugins/WP8 folder and restart your editor.

TcpClientImplementation.dll
-Windows Phone 8 already provides a .net framwork, so Unity3D uses that.
But in that framework there are no TcpClient implemented, so we need a plugin for that.
The Plugins\TcpClientImplementation.dll has only one class: TcpClient from the mono library.
On the other side the Plugins\WP8\TcpClientImplementation.dll and Plugins\WP8\WPSecureProtocol.dll implements the TcpClient for the Windows Phone platform.
This implementation is based on the SocketEx library (https://github.com/mikoskinen/socketex).