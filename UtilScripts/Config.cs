using Godot;
using System;

public class Config {

    private ConfigFile CF = new ConfigFile();
    string lang;
    string isFullscreen;

    public void Save() {
        CF.SetValue("Main", "Lang", TranslationServer.GetLocale());
        CF.SetValue("Main", "FULLSCREEN_NOTE", "For some reason this is reversed. Remember that when changing it.");
        CF.SetValue("Main", "Fullscreen", OS.WindowFullscreen);
        CF.Save("user://settings.cfg");
    }

    private void setFullscreen() {
        isFullscreen = CF.GetValue("Main", "Fullscreen", "True").ToString();

        if(isFullscreen == "True") {
            OS.WindowFullscreen = false;
        } else {
            OS.WindowFullscreen = true;
        }
    }

    public void Load() {
        //GD.Print(OS.GetUserDataDir()); //C:\Users\<USER>\AppData\Roaming\Godot\app_userdata\C# Platformer\settings.cfg
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
