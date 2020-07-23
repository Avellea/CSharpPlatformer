using Godot;
using System;

public class Config {

    private ConfigFile CF = new ConfigFile();
    string lang;
    string isFullscreen;

    public void Save() {
        //General settings
        CF.SetValue("Main", "Lang", TranslationServer.GetLocale());

        //Display settings
        CF.SetValue("Display", "FULLSCREEN_NOTE", "For some reason this is reversed. Remember that when changing it.");
        CF.SetValue("Display", "Fullscreen", OS.WindowFullscreen);

        CF.SetValue("User", "Score", "NONE");

        //Write to the file
        CF.Save("user://settings.cfg");
    }

    private void setFullscreen() {
        isFullscreen = CF.GetValue("Display", "Fullscreen", "True").ToString();

        if(isFullscreen == "True") {
            OS.WindowFullscreen = true;
        } else {
            OS.WindowFullscreen = false;
        }
    }

    public void Load() {
        //GD.Print(OS.GetUserDataDir()); //C:\Users\<USER>\AppData\Roaming\Godot\app_userdata\C# Platformer\settngs.cfg
        lang = CF.GetValue("Main", "Lang", "en").ToString();
        TranslationServer.SetLocale(lang);
        
        setFullscreen();

    }

    public void CheckExist() {
        if(CF.Load("user://settings.cfg") != Error.Ok) {
            Save();
        } else {
            Load();
        }
    }

}
