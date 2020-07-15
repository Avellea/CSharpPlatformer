using Godot;
using System;

public class DebugMenu : Control {

    public override void _Ready() {
        
        GetNode("BackToMenu");

        GetNode("LevelSelector/MenuButton");
        GetNode("LevelSelector/PlayerTestButton");
        GetNode("LevelSelector/TestWorld2Button");
        

    }

    //SCENE CHANGE DEBUG BUTTONS

    public void _on_BackToMenu_pressed() {
        GetTree().ChangeScene("res://Scenes/Menu/Menu.tscn");
    }

    public void _on_MenuButton_pressed() {
        GetTree().ChangeScene("res://Scenes/Menu/Menu.tscn");
    }

    public void _on_PlayerTestButton_pressed() {
        GetTree().ChangeScene("res://Scenes/PlayerTest.tscn");
    }

    public void _on_TestWorld2Button_pressed() {
        GetTree().ChangeScene("res://Scenes/TestWorld2.tscn");
        GD.Print("Finally implemented, bitchessss");
    }

    //TRANSLATION DEBUGGING BUTTONS

    public void _on_enbutton_pressed() {
        TranslationServer.SetLocale("en");
    }

    public void _on_jpbutton_pressed() {
        TranslationServer.SetLocale("ja_JP");
    }

    //SOUND TEST BUTTONS

    public void _on_JumpSound_pressed() {
        AudioStreamPlayer music = (AudioStreamPlayer)GetNode("Music");
        AudioStreamPlayer jump = (AudioStreamPlayer)GetNode("Jump");
        music.Stop();
        System.Threading.Thread.Sleep(500);
        jump.Play();
        GD.Print("[DEBUG] Jump sound played");
        System.Threading.Thread.Sleep(500);
        music.Play();
    }

    public void _on_CoinSound_pressed() {
        AudioStreamPlayer music = (AudioStreamPlayer)GetNode("Music");
        AudioStreamPlayer coin = (AudioStreamPlayer)GetNode("Coin");
        music.Stop();
        System.Threading.Thread.Sleep(500);
        coin.Play();
        GD.Print("[DEBUG] Coin sound played");
        System.Threading.Thread.Sleep(500);
        music.Play();
    }

}
