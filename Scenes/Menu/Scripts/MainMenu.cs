using Godot;
using System;

public class MainMenu : Node2D {
    
    string GAME_VERSION = "1.0 - DEBUG";


    public override void _Ready() {
        Config config = new Config();
        config.CheckExist();
    }

    public void saveLocale() {
        Config config = new Config();
        config.Save();
    }

    public void _on_en_translate_pressed() {
        TranslationServer.SetLocale("en");
        saveLocale();
    }

    public void _on_jp_translate_pressed() {
        TranslationServer.SetLocale("ja_JP");
        saveLocale();
    }

    public override void _Process(float _delta) {
        if(Input.IsActionJustPressed("debug_menu_key")) {
            GetTree().ChangeScene("res://Scenes/Menu/Debug.tscn");
            GD.Print("[DEBUG] ", OS.GetModelName().ToString(), ", ", OS.GetName().ToString());
            GD.Print("[DEBUG] PID: ", OS.GetProcessId().ToString());
            GD.Print("[DEBUG] ", OS.GetExecutablePath().ToString());
            OS.Alert("Congrats! You found the debug menu. Please don't use this to cheat.\nIf you find a bug, please submit it via Discord or itch.io. Thanks! ", "WARNING");
            OS.SetWindowTitle("C# Platformer " + GAME_VERSION);
        }
    }

}
