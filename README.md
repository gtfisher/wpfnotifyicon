# wpfnotifyicon
repository for a WPF windowless app with a notify icon and an iniital UTM URL builder pop-up (this is WIP)
When the app is running if a valid URL is in the Cliboard then the UTM builder popup will launch where 
the uer has a coice of ignoring this url or build a partial UTM uutrl from the drop down selections provided. 
The drop down selections are currently statically populated. The UTM popup can also be launched from the 
context menu from the system tray icon, but the popup will only be populated if htere is a valid url in the clipboard.
 The Show window is a dummy for demo purposes

Shows an icon in the system tray but no windows on start-up.

  * tool tip shows menu options
  * context menu allows show popup/ show window/ hide window / exit
  * Double click will show the winow (if no arleady showing)
  * Exit will exitthe application
  * Closing the main winow will close the window but leave the icon in the tray for relaunch
