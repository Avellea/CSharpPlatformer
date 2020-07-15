using Godot;
using System;

public class Config {

    private ConfigFile CF = new ConfigFile();
    string lang;

    public void Save() {
        CF.SetValue("Main", "Lang", TranslationServer.GetLocale());
        CF.Save("user://settings.cfg");
    }

    public void Load() {
        //GD.Print(OS.GetUserDataDir()); //C:\Users\<USER>\AppData\Roaming\Godot\app_userdata\C# Platformer\settings.cfg
        lang = CF.GetValue("Main", "Lang", "en").ToString();
        TranslationServer.SetLocale(lang);
    }

    public void CheckExist() {
        if(CF.Load("user://settings.cfg") != Error.Ok) {
            Save();
        } else {
            Load();
        }
    }

}
